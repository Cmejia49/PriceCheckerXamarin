using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.Media;
using Plugin.Media.Abstractions;
using PriceChecker.MODEL;
using PriceChecker.SERVICE;
using PriceChecker.VIEW.ADMIN_VIEW;
using Xamarin.Forms;

namespace PriceChecker.VIEWMODEL.ADMIN_VIEWMODEL
{
    public class ProductDetailViewModel:BaseProductViewModel
    {
        public ICommand UpdateProductCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }
        public ICommand BarCodeGeneratorCommand { get; set; }
        public ICommand TakePhotoProductImgCommand { get; set; }
        public ICommand DeleteImgProductCommand { get; set; }
        private static string ShopCode = "^[D,A,N,T,E,M,O,J,I,S]{1,10}$";

        public ProductDetailViewModel(INavigation navigation, int selectedProductID, bool iseditable)
        {
            IsEditable = iseditable;
            Regex rgx = new Regex(ShopCode);
            PropertyChanged += OnPersonEditPropertyChanged;
            Navigation = navigation;
            ProductRepository = new ProductRepository();
            ProductInfo = new ProductInfo();
            ProductInfo.ProductID = selectedProductID;
            UpdateProductCommand = new Xamarin.Forms.Command(
                execute: async () => {
                    PropertyChanged -= OnPersonEditPropertyChanged;
                    await UpdateProduct();
                }, 
                canExecute: () =>
                {
                    return ProductCode != null &&
                            ProductName != null &&
                             ProductPrice != null &&
                              ProductImagePath !=null &&
                               ProductCode.Length > 0 &&
                                ProductName.Length > 2 &&
                                 ProductPrice.Length > 0 &&
                                  rgx.IsMatch(ProductCode);

                });
            DeleteProductCommand = new Command(async () => await DeleteProduct());
            BarCodeGeneratorCommand = new Command(async () => await ShowBarCodeGenerator());


            DeleteImgProductCommand = new Command(
            execute: () =>
            {
                DeleteImage();
            },
            canExecute: () =>
            {
                   return ProductImagePath != null;
            });

            TakePhotoProductImgCommand = new Command(execute: async () => {
                PropertyChanged -= OnPersonEditPropertyChanged;
                await TakePhotos();
            },
                canExecute: () =>
                {
                    return ProductCode != null &&
                            ProductName != null &&
                             ProductPrice != null &&
                              ProductCode.Length > 0 &&
                               ProductName.Length > 2 &&
                                ProductPrice.Length > 0 &&
                                 rgx.IsMatch(ProductCode);

                });

            GetProductData();
        }

        void GetProductData()
        {
            ProductInfo = ProductRepository.GetProduct(ProductInfo.ProductID);
        }
        async Task UpdateProduct()
        {
            ProductRepository.UpdateProduct(ProductInfo);
            await Navigation.PopAsync();
        }
        private async Task DeleteProduct()
        {
            PropertyChanged -= OnPersonEditPropertyChanged;
            ProductRepository.DeleteProduct(ProductInfo.ProductID);
            await Navigation.PopAsync();
        }

        private async Task ShowBarCodeGenerator()
        {
            await Navigation.PushAsync(new BarCodeGeneratorPage(ProductInfo.ProductID, IsEditable));
        }

        private async Task TakePhotos()
        {
            var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Directory = "ProductImage",
                SaveToAlbum = true,
                PhotoSize = new Plugin.Media.Abstractions.PhotoSize()
            }).ConfigureAwait(false);


            try
            {
      
                var path = photo.Path;
                DependencyService.Get<IPhotoManager>().DeletePhoto(ProductImagePath);
                ProductImagePath = photo.AlbumPath;
                ProductRepository.UpdateProduct(ProductInfo);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                await Application.Current.MainPage.DisplayAlert("Canceled", "Photo Canceled", "OK");
            }

        }

        void DeleteImage()
        {
            DependencyService.Get<IPhotoManager>().DeletePhoto(ProductImagePath);
        }

        void OnPersonEditPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            (UpdateProductCommand as Command).ChangeCanExecute();
        }


    }
}

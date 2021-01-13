using PriceChecker.SERVICE;
using System.Collections.Generic;
using System.Threading.Tasks;
using PriceChecker.MODEL;
using Xamarin.Forms;
using PriceChecker.VIEW;
using System.Windows.Input;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Android.Telephony.Mbms;
using System;
using Android.Views;

namespace PriceChecker.VIEWMODEL.ADMIN_VIEWMODEL
{
    public class NewProductViewModel : BaseProductViewModel
    {
        public ICommand AddProductCommand { get; set; }
        public ICommand TakeProductImgCommand { get; set; }
        public ICommand DeleteImgProductCommand { get; set; }
        private List<ProductInfo> _CheckedProductList;
        private static string ShopCode = "^[D,A,N,T,E,M,O,J,I,S]{1,10}$";
        public NewProductViewModel(INavigation navigation,bool iseditable)
        {

            TakeProductImgCommand = new Command(async()=> await TakePhotosCommand().ConfigureAwait(false));
            IsEditable = iseditable;
            Regex rgx = new Regex(ShopCode);
            PropertyChanged += OnProductAddPropertyChanged;
            Navigation = navigation;
            ProductRepository = new ProductRepository();
            ProductInfo = new ProductInfo();
            AddProductCommand = new Command(
               execute:async () => 
               {
                       PropertyChanged -= OnProductAddPropertyChanged;
                        await AddProduct();
               },
               canExecute: () =>
               {
                _CheckedProductList = ProductRepository.CheckProductDuplicateInsert(ProductName);
                return ProductCode != null &&
                         ProductName != null &&
                          ProductPrice != null &&
                           ProductImagePath !=null&&
                            ProductCode.Length > 0 &&
                             ProductName.Length > 2 &&
                              ProductPrice.Length > 0 &&
                              _CheckedProductList.Count == 0 &&
                               rgx.IsMatch(ProductCode);                         
               });

               DeleteImgProductCommand = new Command(execute: () =>
               {
                    DeletePhotos();
               },
               canExecute: ()=>
               {
                    return ProductImagePath != null;
               });
        }  

        private  async Task TakePhotosCommand()
        {
            var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Directory = "ProductImage",
                SaveToAlbum = true,
                    PhotoSize = new Plugin.Media.Abstractions.PhotoSize()
            }) ;
            try
            {
                var path = photo.Path;
                ProductImagePath = photo.AlbumPath;         
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                 await Application.Current.MainPage.DisplayAlert("Canceled", "Photo Canceled", "OK");
            }

        }
        private void DeletePhotos()
        {

            DependencyService.Get<IPhotoManager>().DeletePhoto(ProductImagePath);
        }

        private async Task AddProduct()
        {
            ProductRepository.InsertProduct(ProductInfo);
            await Navigation.PushAsync(new AdminPage());
        }

    

        void OnProductAddPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            (AddProductCommand as Command).ChangeCanExecute();
        }


    }
}

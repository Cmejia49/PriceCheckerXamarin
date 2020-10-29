using PriceChecker.SERVICE;
using System.Collections.Generic;
using System.Threading.Tasks;
using PriceChecker.MODEL;
using Xamarin.Forms;
using PriceChecker.VIEW;
using System.Windows.Input;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Android.Webkit;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace PriceChecker.VIEWMODEL.ADMIN_VIEWMODEL
{
    public class NewProductViewModel : BaseProductViewModel
    {
        private ImageSource _imageSource;
        public ImageSource ImageSource
        {
            get { return _imageSource; }
            set
            {
                _imageSource = value;
                OnpropertyChanged();
            }
        }
        public ICommand AddProductCommand { get; set; }
        public ICommand TakePhotos { get; set; }
        private List<ProductInfo> _CheckedProductList;
        private static string ShopCode = "^[D,A,N,T,E,M,O,J,I,S]{1,10}$";
       


        public NewProductViewModel(INavigation navigation,bool iseditable)
        {
            TakePhotos = new Command(async()=> await TakePhotosCommand());
     
            IsEditable = iseditable;
            Regex rgx = new Regex(ShopCode);
            PropertyChanged += OnProductAddPropertyChanged;
            _Navigation = navigation;
            ProductRepository = new ProductRepository();
            _ProductInfo = new ProductInfo();
           AddProductCommand = new Command(
               execute:async () => 
                   {
                       PropertyChanged -= OnProductAddPropertyChanged;
#pragma warning disable CA2007 // Consider calling ConfigureAwait on the awaited task
                        await AddCommand();
#pragma warning restore CA2007 // Consider calling ConfigureAwait on the awaited task
                   },
            canExecute: () =>
            {
                _CheckedProductList = ProductRepository.CheckProductDuplicateInsert(ProductName);
                return ProductCode != null &&
                         ProductName != null &&
                          ProductPrice != null &&
                           ProductCode.Length > 0 &&
                            ProductName.Length > 2 &&
                             ProductPrice.Length > 0 &&
                             _CheckedProductList.Count == 0 &&
                              rgx.IsMatch(ProductCode);
                           
            });

        }
       
        public async Task TakePhotosCommand()
        {
            var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                SaveToAlbum = true
            });
            //Get the public album path
            var aPpath = file.AlbumPath;

            //Get private path
            var path = file.Path;
            if (photo != null)
                ImageSource = ImageSource.FromStream(() => photo.GetStream());
        }
       
        public async Task AddCommand()
        {
           
            ProductRepository.InsertProduct(_ProductInfo);
#pragma warning disable CA2007 // Consider calling ConfigureAwait on the awaited task
            await _Navigation.PushAsync(new AdminPage());
#pragma warning restore CA2007 // Consider calling ConfigureAwait on the awaited task
        }

    

        void OnProductAddPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            (AddProductCommand as Command).ChangeCanExecute();
        }


    }
}

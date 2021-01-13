using PriceChecker.SERVICE;
using PriceChecker.VIEW;
using PriceChecker.VIEW.ADMIN_VIEW;
using PriceChecker.VIEWMODEL.ADMIN_VIEWMODEL;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PriceChecker.VIEWMODEL
{
    public class LogInViewModel: INotifyPropertyChanged
    {
        private INavigation Navigation;
        private string UserName { get; set; }
        private string PassWord { get; set; }
        private string ErrorMessage { get; set; }
        public ICommand LogInCommand { get; private set; }

        ProductRepository productRepository = new ProductRepository();
        public LogInViewModel(INavigation navigation)
        {
            Navigation = navigation;
            AdminPageViewModel adminpage = new AdminPageViewModel(navigation);
            
            LogInCommand = new Xamarin.Forms.Command(
                execute: async () =>
                {

                    await LogIn().ConfigureAwait(false);
                });
        }

        public string Username
        {
            get
            {
                return UserName;
            }
            set
            {
                UserName = value;
                OnPropertyChanged(nameof(Username));
            }
        }


        public string Password
        {
            get
            {
                return PassWord;
            }
            set
            {
                PassWord = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string Errormessage
        {
            get
            {
                return ErrorMessage;
            }
            set
            {
                ErrorMessage = value;
                OnPropertyChanged(nameof(Errormessage));
            }
        }

         async Task LogIn()
        {
            var GetCountDB = productRepository.GetAllProductInfos();
            if (UserName == "OWNER" && PassWord == "123")
            {
                if (GetCountDB.Count > 0)
                {
                    await Navigation.PushAsync(new AdminPage());
                    await PopupNavigation.Instance.PopAsync(true);
                    RefreshCanExecutes();
                }
                else
                {
                    await Navigation.PushAsync(new NewProduct(false));
                    await PopupNavigation.Instance.PopAsync(true);
                }
            }
            else
            {
                ErrorMessage = "Wrong Password OR Username";
            }



        }

        void RefreshCanExecutes()
        {
            (LogInCommand as Command).ChangeCanExecute();
         
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

      
    }
}

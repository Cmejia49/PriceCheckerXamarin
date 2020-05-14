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
    public class AdminViewModel: INotifyPropertyChanged
    {
        public INavigation _Navigation;
        private string userName { get; set; }
        private string passWord { get; set; }
        private string errorMessage { get; set; }

        public ICommand _logInCommand { get; private set; }
        ProductRepository productRepository = new ProductRepository();
        public AdminViewModel(INavigation navigation)
        {
            _Navigation = navigation;
            AdminPageViewModel adminpage = new AdminPageViewModel(navigation);
            
            _logInCommand = new Xamarin.Forms.Command(
                execute: async () =>
                {
                    await LogIn();
                });
        }

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnpropertyChanged("UserName");
            }
        }


        public string PassWord
        {
            get
            {
                return passWord;
            }
            set
            {
                passWord = value;
                OnpropertyChanged("PassWord");
            }
        }

        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }
            set
            {
                errorMessage = value;
                OnpropertyChanged("ErrorMessage");
            }
        }

        public async Task LogIn()
        {
            var GetCountDB = productRepository.GetAllProductInfos();
            if (UserName == "OWNER" && PassWord == "123")
            {
                if (GetCountDB.Count > 0)
                {
                    await _Navigation.PushAsync(new AdminPage());
                    await PopupNavigation.Instance.PopAsync(true);
                    RefreshCanExecutes();
                }
                else
                {
                    await _Navigation.PushAsync(new NewProduct(false));
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
            (_logInCommand as Command).ChangeCanExecute();
         
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnpropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

      
    }
}

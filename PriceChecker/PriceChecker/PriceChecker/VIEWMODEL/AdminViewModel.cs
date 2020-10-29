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
#pragma warning disable CA1051 // Do not declare visible instance fields
        public INavigation _Navigation;
#pragma warning restore CA1051 // Do not declare visible instance fields
#pragma warning disable IDE1006 // Naming Styles
        private string userName { get; set; }
#pragma warning restore IDE1006 // Naming Styles
#pragma warning disable IDE1006 // Naming Styles
        private string passWord { get; set; }
#pragma warning restore IDE1006 // Naming Styles
#pragma warning disable IDE1006 // Naming Styles
        private string errorMessage { get; set; }
#pragma warning restore IDE1006 // Naming Styles

#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable CA1707 // Identifiers should not contain underscores
        public ICommand _logInCommand { get; private set; }
#pragma warning restore CA1707 // Identifiers should not contain underscores
#pragma warning restore IDE1006 // Naming Styles
        ProductRepository productRepository = new ProductRepository();
        public AdminViewModel(INavigation navigation)
        {
            _Navigation = navigation;
            AdminPageViewModel adminpage = new AdminPageViewModel(navigation);
            
            _logInCommand = new Xamarin.Forms.Command(
                execute: async () =>
                {
#pragma warning disable CA2007 // Consider calling ConfigureAwait on the awaited task
                    await LogIn();
#pragma warning restore CA2007 // Consider calling ConfigureAwait on the awaited task
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
                OnpropertyChanged(nameof(UserName));
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
                OnpropertyChanged(nameof(PassWord));
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
                OnpropertyChanged(nameof(ErrorMessage));
            }
        }

        public async Task LogIn()
        {
            var GetCountDB = productRepository.GetAllProductInfos();
            if (UserName == "OWNER" && PassWord == "123")
            {
                if (GetCountDB.Count > 0)
                {
#pragma warning disable CA2007 // Consider calling ConfigureAwait on the awaited task
                    await _Navigation.PushAsync(new AdminPage());
#pragma warning restore CA2007 // Consider calling ConfigureAwait on the awaited task
#pragma warning disable CA2007 // Consider calling ConfigureAwait on the awaited task
                    await PopupNavigation.Instance.PopAsync(true);
#pragma warning restore CA2007 // Consider calling ConfigureAwait on the awaited task
                    RefreshCanExecutes();
                }
                else
                {
#pragma warning disable CA2007 // Consider calling ConfigureAwait on the awaited task
                    await _Navigation.PushAsync(new NewProduct(false));
#pragma warning restore CA2007 // Consider calling ConfigureAwait on the awaited task
#pragma warning disable CA2007 // Consider calling ConfigureAwait on the awaited task
                    await PopupNavigation.Instance.PopAsync(true);
#pragma warning restore CA2007 // Consider calling ConfigureAwait on the awaited task
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

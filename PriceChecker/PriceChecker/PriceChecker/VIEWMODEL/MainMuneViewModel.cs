using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using PriceChecker.VIEW.ADMIN_VIEW;
using PriceChecker.VIEW.USER_VIEW;
using PriceChecker.sqliteHELPER;
using PriceChecker.VIEW;
using PriceChecker.SERVICE;
using PriceChecker.VIEWMODEL.ADMIN_VIEWMODEL;
using Rg.Plugins.Popup.Services;

namespace PriceChecker.VIEWMODEL
{
    public class MainMuneViewModel:BaseProductViewModel
    {

        public ICommand ShowAdminPageCommand { get; set; }
        public ICommand ShowUserPageCommand { get; set; }

        public MainMuneViewModel(INavigation navigation)
        {
            ProductRepository = new ProductRepository();
            Navigation = navigation;
            ShowAdminPageCommand = new Command(async () => await ShowAdminPage().ConfigureAwait(false));

            ShowUserPageCommand = new Command(async () => await ShowUserPage().ConfigureAwait(false));
              
        }

        private async Task ShowAdminPage()
        {
            await PopupNavigation.Instance.PushAsync(new LogInPage(Navigation));
        }
        private async Task ShowUserPage()
        {
            await Navigation.PushAsync(new UserPage(""));
        }

       private void RefreshCanExecutes()
        {
            (ShowUserPageCommand as Command).ChangeCanExecute();
        }

    }
}

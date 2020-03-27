using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using PriceChecker.VIEW.ADMIN_VIEW;
using PriceChecker.VIEW.USER_VIEW;
using PriceChecker.sqliteHELPER;
using PriceChecker.VIEW;
using PriceChecker.SERVICE;
using PriceChecker.VIEWMODEL.ADMIN_VIEWMODEL;
namespace PriceChecker.VIEWMODEL
{
    public class TheViewModel:BaseProductViewModel
    {

        public ICommand _ShowAdminPage { get; set; }
        public ICommand _ShowUserPage { get; set; }

        public AdminPageViewModel adminpage;
        public TheViewModel(INavigation navigation)
        {
            AdminPageViewModel adminPage = new AdminPageViewModel(navigation);
             ProductRepository = new ProductRepository();
            _Navigation = navigation;
            _ShowAdminPage = new Xamarin.Forms.Command(
                execute: async () =>
                {
                await ShowAdminPage();
                    RefreshCanExecutes();
                });

            _ShowUserPage = new Xamarin.Forms.Command(
                execute: async () => 
                {
                    await ShowUserPage();
                });
        }

        public async Task ShowAdminPage()
        {
               var getLocalDB = ProductRepository.GetAllProductInfos();
            if (getLocalDB.Count > 0)
            {
                await _Navigation.PushAsync(new AdminPage());
            }
            else
            {
                await _Navigation.PushAsync(new NewProduct());
            }
        }
        public async Task ShowUserPage()
        {
            await _Navigation.PushAsync(new UserPage());
        }


        void RefreshCanExecutes()
        {
            (_ShowAdminPage as Command).ChangeCanExecute();
            (_ShowUserPage as Command).ChangeCanExecute();
        }

    }
}

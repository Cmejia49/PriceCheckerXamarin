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
    public class TheViewModel:BaseProductViewModel
    {
#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable CA1707 // Identifiers should not contain underscores
        public ICommand _ShowAdminPage { get; set; }
#pragma warning restore CA1707 // Identifiers should not contain underscores
#pragma warning restore IDE1006 // Naming Styles

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>")]
#pragma warning disable IDE1006 // Naming Styles
        public ICommand _ShowUserPage { get; set; }
#pragma warning restore IDE1006 // Naming Styles

#pragma warning disable CA1051 // Do not declare visible instance fields
        public AdminPageViewModel adminpage;
#pragma warning restore CA1051 // Do not declare visible instance fields
        public TheViewModel(INavigation navigation)
        {
            AdminPageViewModel adminPage = new AdminPageViewModel(navigation);
             ProductRepository = new ProductRepository();
            _Navigation = navigation;
            _ShowAdminPage = new Xamarin.Forms.Command(
                execute: async () =>
                {
#pragma warning disable CA2007 // Consider calling ConfigureAwait on the awaited task
                    await ShowAdminPage();
#pragma warning restore CA2007 // Consider calling ConfigureAwait on the awaited task

                });

            _ShowUserPage = new Xamarin.Forms.Command(
                execute: async () => 
                {
#pragma warning disable CA2007 // Consider calling ConfigureAwait on the awaited task
                    await ShowUserPage();
#pragma warning restore CA2007 // Consider calling ConfigureAwait on the awaited task
                });
        }

        public async Task ShowAdminPage()
        {
#pragma warning disable CA2007 // Consider calling ConfigureAwait on the awaited task
            await PopupNavigation.Instance.PushAsync(new LogInPage(_Navigation));
#pragma warning restore CA2007 // Consider calling ConfigureAwait on the awaited task
        }
        public async Task ShowUserPage()
        {
#pragma warning disable CA2007 // Consider calling ConfigureAwait on the awaited task
            await _Navigation.PushAsync(new UserPage(""));
#pragma warning restore CA2007 // Consider calling ConfigureAwait on the awaited task
        }


        void RefreshCanExecutes()
        {
            (_ShowUserPage as Command).ChangeCanExecute();
        }

    }
}

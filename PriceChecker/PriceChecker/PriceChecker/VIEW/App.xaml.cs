using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PriceChecker.VIEW;
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PriceChecker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            OnAppStart();
        }


        public void OnAppStart()
        {

            MainPage = new NavigationPage(new MainMenuPage());


        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

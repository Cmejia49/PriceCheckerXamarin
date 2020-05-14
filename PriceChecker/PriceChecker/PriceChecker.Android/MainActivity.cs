


using Android.App;
using Android.Content.PM;
using Android.OS;
using SQLite.Net.Platform.XamarinAndroid;
namespace PriceChecker.Droid
{

    [Activity(Label = "PriceChecker", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
           

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
           
            ZXing.Net.Mobile.Forms.Android.Platform.Init();
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);


            LoadApplication(new App());
        }



        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
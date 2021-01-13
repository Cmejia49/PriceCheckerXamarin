using Plugin.Media;
using Android.App;
using Android.Content.PM;
using Android.OS;
using System.Linq;
using Android.Views;
using PriceChecker.VIEW.Custom;
using Xamarin.Forms;
namespace PriceChecker.Droid
{

	[Activity(Label = "PriceCheck", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        protected override async void OnCreate(Bundle savedInstanceState)
        {
           

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
			Xamarin.Essentials.Platform.Init(this, savedInstanceState);
			await CrossMedia.Current.Initialize();
            ZXing.Net.Mobile.Forms.Android.Platform.Init();
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);


            LoadApplication(new App());

			Android.Support.V7.Widget.Toolbar toolbar
			= this.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
			SetSupportActionBar(toolbar); 
		}



        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			if (item.ItemId == 16908332)
			{

				// retrieve the current xamarin forms page instance
				var currentpage = (CustomContentPage)
				Xamarin.Forms.Application.
				Current.MainPage.Navigation.
				NavigationStack.LastOrDefault();

				// check if the page has subscribed to 
				// the custom back button event

				if (currentpage?.CustomBackButtonAction != null)
				{
					// invoke the Custom back button action
					currentpage?.CustomBackButtonAction.Invoke();
					// and disable the default back button action
					return false;
				}

				// if its not subscribed then go ahead 
				// with the default back button action
				return base.OnOptionsItemSelected(item);
			}
			else
			{
				// since its not the back button 
				//click, pass the event to the base
				return base.OnOptionsItemSelected(item);
			}
	
		
		}

		public override void OnBackPressed()
		{
			// this is not necessary, but in Android user 
			// has both Nav bar back button and
			// physical back button its safe 
			// to cover the both events

			// retrieve the current xamarin forms page instance
			var currentpage = (CustomContentPage)
			Xamarin.Forms.Application.
			Current.MainPage.Navigation.
			NavigationStack.LastOrDefault();

			// check if the page has subscribed to 
			// the custom back button event
			if (currentpage?.CustomBackButtonAction != null)
			{
				currentpage?.CustomBackButtonAction.Invoke();
			}
			else
			{
				base.OnBackPressed();
			}
		}
	}
}
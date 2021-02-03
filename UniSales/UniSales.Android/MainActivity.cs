using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;

namespace UniSales.Droid
{
    [Activity(Label = "UniSales", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        internal static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            Instance = this;
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);
            UserDialogs.Init(this);

            LoadApplication(new Core.App());
        }
    }
}
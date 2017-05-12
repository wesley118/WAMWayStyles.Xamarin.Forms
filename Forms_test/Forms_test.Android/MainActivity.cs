
using Android.App;
using Android.Content.PM;
using Android.OS;
using Serilog;
using Serilog.Core;

namespace Forms_test.Droid
{
    [Activity(Label = "Forms_test", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            Log.Logger = new LoggerConfiguration()
                        .WriteTo.AndroidLog()
                        .Enrich.WithProperty(Constants.SourceContextPropertyName, "WAMWAY_STYLES_TEST_ANDROID") //Sets the Tag field.
                        .CreateLogger();

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
        protected override void OnDestroy()
        {
            Log.CloseAndFlush();
            base.OnDestroy();
        }
    }
}


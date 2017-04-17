using Newtonsoft.Json;
using Serilog;
using WAMWayStyles;
using WAMWayStyles.ColorTools;
using WAMWayStyles.Themes.Options;
using Xamarin.Forms;

namespace Forms_test
{
    public class App : Application
    {
        public MasterStyle IAmMaster;
        public static App CurrrentApp;
        private NavigationPage NavPage;
        public App()
        {
            CurrrentApp = this;
            
            var c = Color.FromHex("#79B342");
            Log.Information(JsonConvert.SerializeObject(c));
            var cOptions = new AnalagousColorOptions(c);
            //var cOptions = new WholeScheme(c);
            Log.Information(JsonConvert.SerializeObject(cOptions));
            var style = new WAMWayStyles.MasterStyle(cOptions);
            Log.Information(JsonConvert.SerializeObject(style));
            
            IAmMaster = style;
            NavPage = new NavigationPage(new StyleTestPage()); ;
            NavigationPage.SetHasNavigationBar(NavPage, false);
            MainPage = NavPage;
        }

        public void UpdateStyle(string hex)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                
                NavPage = new NavigationPage(new StyleTestPage());
                NavigationPage.SetHasNavigationBar(NavPage, false);
            });
        }

        public void OnCreate()
        {

        }
        
    }

    public class main : ContentPage
    {
        public main()
        {
            
            //var b1 = new BoxView();
            //var b2 = new BoxView();
            //var b3 = new BoxView();
            //var b4 = new BoxView();
            //var b5 = new BoxView();
            //var baseColor = "#79B342";
            //var colfun = new ColorFunctions();
            //var pal = colfun.GetPallete(baseColor);
            //b1.Color = pal[0];
            //b2.Color = pal[1];
            //b3.Color = pal[2];
            //b4.Color = pal[3];
            //b5.Color = pal[4];
            //var stackLayout = new StackLayout()
            //{
            //    Orientation = StackOrientation.Vertical,
            //    HorizontalOptions = LayoutOptions.Fill,
            //    VerticalOptions = LayoutOptions.Fill,
            //};
            //stackLayout.Children.Add(b1);
            //stackLayout.Children.Add(b2);
            //stackLayout.Children.Add(b3);
            //stackLayout.Children.Add(b4);
            //stackLayout.Children.Add(b5);
            //this.Content = stackLayout;
        }
    }
}

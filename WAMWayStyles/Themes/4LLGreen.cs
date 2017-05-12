using Xamarin.Forms;

namespace WAMWayStyles.Themes
{
    public class _4LLGreen : WAMWayStyles.Infrastructure.WAMWayStyles
    {
        public void Init()
        {
            Application.Current.Resources = new ResourceDictionary()
            {
                ViewStyle,
                ContentViewStyle,
                PageStyle,
                ContentPageStyle,
                MasterDetailPageStyle,
                InputViewStyle,
                ListViewStyle,
                ScrollViewStyle,
                WebViewStyle,
                TableViewStyle,
                ViewCellStyle,
                LayoutStyle,
                StackLayoutStyle,
                RelativeLayoutStyle,
                LayoutStyle,
                GridStyle,
                ButtonStyle,
                ActivityIndicatorStyle,
                CellStyle,
                PickerStyle,
                DatePickerStyle,
                TimePickerStyle,
                EntryStyle,
                EditorStyle
            };
        }
        public override Style ViewStyle => new Style(typeof(View))
        {
            BasedOn = base.ViewStyle,
            Setters =
            {
                new Setter { Property = View.BackgroundColorProperty, Value = Color.Transparent }

            }

        };
        public override Style ContentViewStyle => new Style(typeof(ContentView))
        {
            BasedOn = ViewStyle,
            Setters =
            {
                new Setter { Property = ContentView.HorizontalOptionsProperty , Value = LayoutOptions.Fill },
                new Setter { Property = ContentView.VerticalOptionsProperty, Value = LayoutOptions.Fill },
            }
        };
        public override Style PageStyle => new Style(typeof(Page))
        {
            BasedOn = ViewStyle,
            Setters =
            {
                new Setter { Property = Page.BackgroundColorProperty, Value = Color.FromHex("#79B342")},
                new Setter { Property = Page.PaddingProperty, Value = new Thickness(5) },
            }
        };
        public override Style ContentPageStyle => new Style(typeof(ContentPage))
        {
            BasedOn = PageStyle,
        };
        public override Style MasterDetailPageStyle => new Style(typeof(MasterDetailPage))
        {
            BasedOn = PageStyle,
        };
        public override Style InputViewStyle => new Style(typeof(InputView))
        {
            BasedOn = ViewStyle,
            Setters =
            {
                new Setter{ Property = InputView.KeyboardProperty, Value = Keyboard.Default },
                new Setter { Property = InputView.MarginProperty, Value = new Thickness(5) },
            }
        };
        public override Style ListViewStyle => new Style(typeof(ListView))
        {
            BasedOn = ViewStyle,
            Setters =
            {
                new Setter { Property = ListView.HorizontalOptionsProperty, Value = LayoutOptions.Fill },
                new Setter { Property = ListView.SeparatorColorProperty, Value = Color.FromHex("#3D720A") },
                new Setter { Property = ListView.SeparatorVisibilityProperty, Value = SeparatorVisibility.Default },
                new Setter { Property = ListView.VerticalOptionsProperty, Value = LayoutOptions.Fill },
            }
        };
        public override Style ScrollViewStyle => new Style(typeof(ScrollView))
        {
            BasedOn = ViewStyle,
            Setters =
            {
                new Setter { Property = ScrollView.OrientationProperty, Value = ScrollOrientation.Vertical },
                new Setter { Property = ScrollView.HorizontalOptionsProperty, Value = LayoutOptions.Fill },
                new Setter { Property = ScrollView.VerticalOptionsProperty, Value = LayoutOptions.Fill },
                new Setter { Property = ScrollView.PaddingProperty, Value = new Thickness(5) },
            }
        };
        public override Style WebViewStyle => new Style(typeof(WebView))
        {
            BasedOn = ViewStyle,
            Setters =
            {
                new Setter { Property = WebView.HorizontalOptionsProperty, Value = LayoutOptions.Fill },
                new Setter { Property = WebView.VerticalOptionsProperty, Value = LayoutOptions.Fill },
            }
        };
        public override Style TableViewStyle => new Style(typeof(TableView))
        {
            BasedOn = ViewStyle,
            Setters =
            {
                new Setter { Property = TableView.HasUnevenRowsProperty, Value = false },
                new Setter { Property = TableView.HorizontalOptionsProperty, Value = LayoutOptions.Fill },
                new Setter { Property = TableView.VerticalOptionsProperty, Value = LayoutOptions.Fill },
            }
        };
        public override Style ViewCellStyle => new Style(typeof(ViewCell))
        {
            BasedOn = ViewStyle,
        };
        public override Style LayoutStyle => new Style(typeof(Layout))
        {
            BasedOn = ViewStyle,
            Setters =
            {
                new Setter { Property = Layout.HorizontalOptionsProperty, Value = LayoutOptions.Fill },
                new Setter { Property = Layout.VerticalOptionsProperty, Value = LayoutOptions.Fill },
            }
        };
        public override Style StackLayoutStyle => new Style(typeof(StackLayout))
        {
            BasedOn = LayoutStyle,
            Setters =
            {
                new Setter { Property = StackLayout.OrientationProperty, Value = StackOrientation.Vertical },
            }
        };
        public override Style RelativeLayoutStyle => new Style(typeof(RelativeLayout))
        {
            BasedOn = LayoutStyle,
        };
        public override Style LabelStyle => new Style(typeof(Label))
        {
            BasedOn = ViewStyle,
            Setters =
            {
                new Setter { Property = Label.TextColorProperty, Value = Color.FromHex("#C6ECA1") },
                new Setter { Property = Label.HorizontalTextAlignmentProperty, Value = TextAlignment.Start },
                new Setter { Property = Label.VerticalTextAlignmentProperty, Value = TextAlignment.Center },
            }
        };
        public override Style GridStyle => new Style(typeof(Grid))
        {
            BasedOn = ViewStyle,
            Setters =
            {
                new Setter { Property = Grid.HorizontalOptionsProperty , Value = LayoutOptions.Fill },
                new Setter { Property = Grid.VerticalOptionsProperty, Value = LayoutOptions.Fill },
            }
        };
        public override Style ButtonStyle => new Style(typeof(Button))
        {
            BasedOn = ViewStyle,
            Setters =
            {
                new Setter { Property = Button.BackgroundColorProperty, Value = Color.FromHex("#5D9625") },
                new Setter { Property = Button.BorderColorProperty, Value = Color.FromHex("#A1DD66F") },
                new Setter { Property = Button.TextColorProperty, Value = Color.FromHex("#C6ECA1") },
                new Setter { Property = Button.BorderRadiusProperty, Value = 7 },
                new Setter { Property = Button.BorderWidthProperty, Value = 1 },
            }
        };
        public override Style ActivityIndicatorStyle => new Style(typeof(ActivityIndicator))
        {
            BasedOn = ViewStyle,
            Setters =
            {
                new Setter { Property = ActivityIndicator.ColorProperty, Value = Color.FromHex("#3D720A") },
            }
        };
        public override Style CellStyle => new Style(typeof(Cell))
        {
            BasedOn = ViewCellStyle,
        };
        public override Style PickerStyle => new Style(typeof(Picker))
        {
            BasedOn = ViewStyle,
            Setters =
            {
                new Setter { Property = Picker.BackgroundColorProperty, Value = Color.FromHex("#C6ECA1") },
                new Setter { Property = Picker.TextColorProperty, Value = Color.FromHex("#3D720A") },
                new Setter { Property = Picker.HorizontalOptionsProperty, Value = LayoutOptions.Fill },
            }
        };
        public override Style DatePickerStyle => new Style(typeof(DatePicker))
        {
            BasedOn = PickerStyle,
        };
        public override Style TimePickerStyle => new Style(typeof(TimePicker))
        {
            BasedOn = PickerStyle,
        };
        public override Style EntryStyle => new Style(typeof(Entry))
        {
            BasedOn = ViewStyle,
            Setters =
            {
                new Setter { Property = Entry.TextColorProperty, Value = Color.FromHex("#3D720A") },
                new Setter { Property = Entry.PlaceholderColorProperty, Value = Color.FromHex("#0FC6ECA1") },
            }
        };
        public override Style EditorStyle => new Style(typeof(Editor))
        {
            BasedOn = ViewStyle,
            Setters =
            {
                new Setter { Property = Editor.TextColorProperty, Value = Color.FromHex("#3D720A") },
                new Setter { Property = Editor.BackgroundColorProperty, Value = Color.FromHex("#0F5D9625") },
            }
        };
        
    }
}

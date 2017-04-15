////using System;
////using Newtonsoft.Json;
////using Serilog;
////using WAMWayStyles.Controls;
////using WAMWayStyles.Infrastructure;
////using Xamarin.Forms;

////namespace WAMWayStyles
////{
////    class MasterStyle_r : Infrastructure.WAMWayStyles
////    {
////        protected IBasicColorOptions ColorOptions;
////        protected void Init(IBasicColorOptions colorOptions)
////        {
////            ColorOptions = colorOptions;
////            Log.Information(string.Format("ColorOptions: \r\n\t{0}", JsonConvert.SerializeObject(ColorOptions)));
////            //var colorformatstring = "R:{0} G:{1} B:{2} A:{3}\r\nColorToJson: {4}\r\n\r\n";
////            //var pallete = new ColorTools.ColorFunctions().GetPallete(hexColor);
////            //DarkestShade = pallete[0];
////            //Log.Information(string.Format(colorformatstring, DarkestShade.R, DarkestShade.G, DarkestShade.B, DarkestShade.A, JsonConvert.SerializeObject(DarkestShade)));
////            //DarkerShade = pallete[1];
////            //Log.Information(string.Format(colorformatstring, DarkerShade.R, DarkerShade.G, DarkerShade.B, DarkerShade.A, JsonConvert.SerializeObject(DarkerShade)));
////            //MediumShade = pallete[2];
////            //Log.Information(string.Format(colorformatstring, MediumShade.R, MediumShade.G, MediumShade.B, MediumShade.A, JsonConvert.SerializeObject(MediumShade)));
////            //LighterShade = pallete[3];
////            //Log.Information(string.Format(colorformatstring, LighterShade.R, LighterShade.G, LighterShade.B, LighterShade.A, JsonConvert.SerializeObject(LighterShade)));
////            //LightestShade = pallete[4];
////            //Log.Information(string.Format(colorformatstring, LightestShade.R, LightestShade.G, LightestShade.B, LightestShade.A, JsonConvert.SerializeObject(LightestShade)));
////            try
////            {
////                Application.Current.Resources = new ResourceDictionary()
////                {
////                    ViewStyle,
////                    ContentViewStyle,
////                    PageStyle,
////                    ContentPageStyle,
////                    MasterDetailPageStyle,
////                    InputViewStyle,
////                    ListViewStyle,
////                    ScrollViewStyle,
////                    WebViewStyle,
////                    TableViewStyle,
////                    //ViewCellStyle,
////                    //LayoutStyle,
////                    StackLayoutStyle,
////                    RelativeLayoutStyle,
////                    LayoutStyle,
////                    GridStyle,
////                    ButtonStyle,
////                    ActivityIndicatorStyle,
////                    CellStyle,
////                    PickerStyle,
////                    DatePickerStyle,
////                    TimePickerStyle,
////                    EntryStyle,
////                    EditorStyle,
////                    LabelStyle,
////                    AbsoluteLayoutStyle,
////                    NavigationPageStyle,
////                    HeaderLabelStyle,
////                };
////            }
////            catch (Exception ex)
////            {
////                Log.Information(ex.ToExceptionDetailString());
////                Log.Information(string.Format("{0} Styles", Application.Current.Resources.Count));
////                throw ex;
////            }
////        }

////        public Style NavigationPageStyle => new Style(typeof(NavigationPage))
////        {
////            Setters =
////            {
////                //new Setter { Property = NavigationPage.BackgroundColorProperty, Value = ColorOptions.DefaultBackgroundColor },
////                new Setter { Property = NavigationPage.HasNavigationBarProperty, Value = false },
////            }
////        };

////        public override Style ViewStyle => new Style(typeof(View))
////        {
////            BasedOn = base.ViewStyle,
////            Setters =
////            {
////                new Setter { Property = View.BackgroundColorProperty, Value = Color.Transparent }

////            }

////        };
////        public override Style ContentViewStyle => new Style(typeof(ContentView))
////        {
////            BasedOn = ViewStyle,
////            Setters =
////            {
////                new Setter { Property = ContentView.HorizontalOptionsProperty , Value = LayoutOptions.Fill },
////                new Setter { Property = ContentView.VerticalOptionsProperty, Value = LayoutOptions.Fill },
////            }
////        };
////        public override Style PageStyle => new Style(typeof(Page))
////        {
////            //BasedOn = ViewStyle,
////            Setters =
////            {
////                //new Setter { Property = Page.BackgroundColorProperty, Value = ColorOptions.DefaultBackgroundColor},
////                new Setter { Property = Page.PaddingProperty, Value = new Thickness(5,5,5,5) },
////            }
////        };
////        public override Style ContentPageStyle => new Style(typeof(ContentPage))
////        {
////            BasedOn = PageStyle,
////            Setters =
////            {
////                //new Setter { Property = Page.BackgroundColorProperty, Value = ColorOptions.DefaultBackgroundColor},
////                new Setter { Property = Page.PaddingProperty, Value = new Thickness(5,5,5,5) },
////            }
////        };
////        public override Style MasterDetailPageStyle => new Style(typeof(MasterDetailPage))
////        {
////            BasedOn = PageStyle,
////            Setters =
////            {
////                new Setter { Property = Page.BackgroundColorProperty, Value = ColorOptions.DefaultBackgroundColor},
////                new Setter { Property = Page.PaddingProperty, Value = new Thickness(5,5,5,5) },
////            }
////        };
////        public override Style InputViewStyle => new Style(typeof(InputView))
////        {
////            BasedOn = ViewStyle,
////            Setters =
////            {
////                new Setter{ Property = InputView.KeyboardProperty, Value = Keyboard.Default },
////                new Setter { Property = InputView.MarginProperty, Value = new Thickness(5) },
////            }
////        };
////        public override Style ListViewStyle => new Style(typeof(ListView))
////        {
////            BasedOn = ViewStyle,
////            Setters =
////            {
////                new Setter { Property = ListView.HorizontalOptionsProperty, Value = LayoutOptions.Fill },
////                new Setter { Property = ListView.SeparatorColorProperty, Value = ColorOptions.DefaultAccentColor },
////                new Setter { Property = ListView.SeparatorVisibilityProperty, Value = SeparatorVisibility.Default },
////                new Setter { Property = ListView.VerticalOptionsProperty, Value = LayoutOptions.Fill },
////            }
////        };
////        public override Style ScrollViewStyle => new Style(typeof(ScrollView))
////        {
////            BasedOn = ViewStyle,
////            Setters =
////            {
////                new Setter { Property = ScrollView.OrientationProperty, Value = ScrollOrientation.Vertical },
////                new Setter { Property = ScrollView.HorizontalOptionsProperty, Value = LayoutOptions.Fill },
////                new Setter { Property = ScrollView.VerticalOptionsProperty, Value = LayoutOptions.Fill },
////                new Setter { Property = ScrollView.PaddingProperty, Value = new Thickness(5) },
////            }
////        };
////        public override Style WebViewStyle => new Style(typeof(WebView))
////        {
////            BasedOn = ViewStyle,
////            Setters =
////            {
////                new Setter { Property = WebView.HorizontalOptionsProperty, Value = LayoutOptions.Fill },
////                new Setter { Property = WebView.VerticalOptionsProperty, Value = LayoutOptions.Fill },
////            }
////        };
////        public override Style TableViewStyle => new Style(typeof(TableView))
////        {
////            BasedOn = ViewStyle,
////            Setters =
////            {
////                new Setter { Property = TableView.HasUnevenRowsProperty, Value = false },
////                new Setter { Property = TableView.HorizontalOptionsProperty, Value = LayoutOptions.Fill },
////                new Setter { Property = TableView.VerticalOptionsProperty, Value = LayoutOptions.Fill },
////            }
////        };
////        //public override Style ViewCellStyle => new Style(typeof(ViewCell))
////        //{
////        //    BasedOn = ViewStyle,
////        //};
////        public override Style LayoutStyle => new Style(typeof(Layout))
////        {
////            BasedOn = ViewStyle,
////            Setters =
////            {
////                new Setter { Property = Layout.HorizontalOptionsProperty, Value = LayoutOptions.Fill },
////                new Setter { Property = Layout.VerticalOptionsProperty, Value = LayoutOptions.Fill },
////            }
////        };
////        public override Style AbsoluteLayoutStyle => new Style(typeof(AbsoluteLayout))
////        {
////            BasedOn = LayoutStyle,
////            Setters =
////            {
////                new Setter { Property = AbsoluteLayout.BackgroundColorProperty, Value = ColorOptions.DefaultBackgroundColor }
////            }

////        };
////        public override Style StackLayoutStyle => new Style(typeof(StackLayout))
////        {
////            BasedOn = LayoutStyle,
////            Setters =
////            {
////                new Setter { Property = StackLayout.OrientationProperty, Value = StackOrientation.Vertical },
////            }
////        };
////        public override Style RelativeLayoutStyle => new Style(typeof(RelativeLayout))
////        {
////            BasedOn = LayoutStyle,
////        };
////        public override Style LabelStyle => new Style(typeof(Label))
////        {
////            BasedOn = ViewStyle,
////            Setters =
////            {
////                new Setter { Property = Label.TextColorProperty, Value = ColorOptions.DefaultTextColor },
////                new Setter { Property = Label.HorizontalTextAlignmentProperty, Value = TextAlignment.Start },
////                new Setter { Property = Label.VerticalTextAlignmentProperty, Value = TextAlignment.Center },
////            }
////        };
////        public Style HeaderLabelStyle => new Style(typeof(HeaderLabel))
////        {
////            BasedOn = LabelStyle,
////            Setters =
////            {
////                new Setter { Property = HeaderLabel.FontSizeProperty, Value = 28 },
////                new Setter { Property = HeaderLabel.HorizontalOptionsProperty, Value = LayoutOptions.Fill },
////                new Setter { Property = HeaderLabel.FontAttributesProperty, Value = FontAttributes.Bold },
////                new Setter {Property = HeaderLabel.TextColorProperty, Value = ColorOptions.HeaderTextColor },
////                new Setter { Property = HeaderLabel.HorizontalTextAlignmentProperty, Value = TextAlignment.Center },
////                new Setter { Property = HeaderLabel.MarginProperty, Value = new Thickness(5,10,5,10) },
////            }
////        };
////        public override Style GridStyle => new Style(typeof(Grid))
////        {
////            BasedOn = ViewStyle,
////            Setters =
////            {
////                new Setter { Property = Grid.HorizontalOptionsProperty , Value = LayoutOptions.Fill },
////                new Setter { Property = Grid.VerticalOptionsProperty, Value = LayoutOptions.Fill },
////            }
////        };
////        public override Style ButtonStyle => new Style(typeof(Button))
////        {
////            BasedOn = ViewStyle,
////            Setters =
////            {
////                new Setter { Property = Button.BackgroundColorProperty, Value = ColorOptions.ButtonColor },
////                new Setter { Property = Button.BorderColorProperty, Value = ColorOptions.ButtonTextColor },
////                new Setter { Property = Button.TextColorProperty, Value = ColorOptions.ButtonTextColor },
////                new Setter { Property = Button.BorderRadiusProperty, Value = 7 },
////                new Setter { Property = Button.BorderWidthProperty, Value = 1 },
////            }
////        };
////        public override Style ActivityIndicatorStyle => new Style(typeof(ActivityIndicator))
////        {
////            BasedOn = ViewStyle,
////            Setters =
////            {
////                new Setter { Property = ActivityIndicator.ColorProperty, Value = ColorOptions.DefaultAccentColor },
////            }
////        };
////        //public override Style CellStyle => new Style(typeof(Cell))
////        //{
////        //    BasedOn = ViewCellStyle,
////        //};
////        public override Style PickerStyle => new Style(typeof(Picker))
////        {
////            BasedOn = ViewStyle,
////            Setters =
////            {
////                new Setter { Property = Picker.BackgroundColorProperty, Value = ColorOptions.EntryBackgroundColor },
////                new Setter { Property = Picker.TextColorProperty, Value = ColorOptions.DefaultTextColor },
////                new Setter { Property = Picker.HorizontalOptionsProperty, Value = LayoutOptions.Fill },
////            }
////        };
////        public override Style DatePickerStyle => new Style(typeof(DatePicker))
////        {
////            //BasedOn = PickerStyle,
////            Setters =



////            {
////                new Setter { Property = DatePicker.BackgroundColorProperty, Value = ColorOptions.EntryBackgroundColor },
////                new Setter { Property = DatePicker.TextColorProperty, Value = ColorOptions.DefaultTextColor },
////                new Setter { Property = DatePicker.HorizontalOptionsProperty, Value = LayoutOptions.Fill },
////            }
////        };
////        public override Style TimePickerStyle => new Style(typeof(TimePicker))
////        {
////            //BasedOn = PickerStyle,
////            Setters =
////            {
////                new Setter { Property = TimePicker.BackgroundColorProperty, Value = ColorOptions.EntryBackgroundColor },
////                new Setter { Property = TimePicker.TextColorProperty, Value = ColorOptions.DefaultTextColor },
////                new Setter { Property = TimePicker.HorizontalOptionsProperty, Value = LayoutOptions.Fill },
////            }
////        };
////        public override Style EntryStyle => new Style(typeof(Entry))
////        {
////            BasedOn = ViewStyle,
////            Setters =
////            {
////                new Setter { Property = Entry.HorizontalOptionsProperty, Value = LayoutOptions.Fill },
////                new Setter { Property = Entry.TextColorProperty, Value = ColorOptions.EntryBackgroundColor },
////                new Setter { Property = Entry.PlaceholderColorProperty, Value = ColorOptions.DefaultPlaceholderTextColor, }// Color.FromHex("#0FC6ECA1") },
////            }
////        };
////        public override Style EditorStyle => new Style(typeof(Editor))
////        {
////            BasedOn = ViewStyle,
////            Setters =
////            {
////                new Setter { Property = Editor.TextColorProperty, Value = ColorOptions.DefaultTextColor },
////                new Setter { Property = Editor.BackgroundColorProperty, Value = ColorOptions.EntryBackgroundColor, }// Color.FromHex("#0F5D9625") },
////            }
////        };
////    }
////}

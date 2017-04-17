using System;
using Xamarin.Forms;

namespace WAMWayStyles.Infrastructure
{
    public abstract class WAMWayStyles : IWAMWayStyle
    {
        public virtual ResourceDictionary Resources { get; set; }
        public virtual Style ViewStyle => new Style(typeof(View)) { Setters = { new Setter { Property = View.BackgroundColorProperty , Value = Color.Default }, new Setter { Property = View.HorizontalOptionsProperty , Value = LayoutOptions.Center }, } };
        public virtual Style ActivityIndicatorStyle => new Style(typeof(ActivityIndicator)) { BasedOn = ViewStyle, CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style ButtonStyle => new Style(typeof(Button)) { BasedOn = ViewStyle, CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style DatePickerStyle => new Style(typeof(DatePicker)) { CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style ContentViewStyle => new Style(typeof(ContentView)) { CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style ContentPageStyle => new Style(typeof(ContentPage)) { CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style EntryStyle => new Style(typeof(Entry)) { CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style EditorStyle => new Style(typeof(Editor)) { CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style GridStyle => new Style(typeof(Grid)) { CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style InputViewStyle => new Style(typeof(InputView)) { CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style LabelStyle => new Style(typeof(Label)) { CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style KeyboardStyle => new Style(typeof(Keyboard)) { CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style LayoutStyle => new Style(typeof(Layout)) { CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style ListViewStyle => new Style(typeof(ListView)) { CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style MasterDetailPageStyle => new Style(typeof(MasterDetailPage)) { CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style NavigationMenuStyle => new Style(typeof(NavigationPage)) { CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style PageStyle => new Style(typeof(Page)) { CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style PickerStyle => new Style(typeof(Picker)) { CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style ProgressBarStyle => new Style(typeof(ProgressBar)) { CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style RelativeLayoutStyle => new Style(typeof(RelativeLayout)) { CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style ScrollViewStyle => new Style(typeof(ScrollView)) { CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style SliderStyle => new Style(typeof(Slider)) { CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style StackLayoutStyle => new Style(typeof(StackLayout)) { CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style SwitchStyle => new Style(typeof(Switch)) { CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style TableViewStyle => new Style(typeof(TableView)) { CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style TextCellStyle => new Style(typeof(TextCell)) { CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style ViewCellStyle => new Style(typeof(ViewCell)) { CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style CellStyle => new Style(typeof(Cell)) { CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style WebViewStyle => new Style(typeof(WebView)) { CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style TimePickerStyle => new Style(typeof(TimePicker)) { CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style AbsoluteLayoutStyle => new Style(typeof(AbsoluteLayout)) { CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style TabbedPageStyle => new Style(typeof(TabbedPage)) { CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style LabelStyle_LargeFont => new Style(typeof(Label)) { CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style LabelStyle_SmallFont => new Style(typeof(Label)) { CanCascade = true, ApplyToDerivedTypes = true };
        public virtual Style LabelStyle_Bold => new Style(typeof(Label)) { CanCascade = true, ApplyToDerivedTypes = true };
    }
}
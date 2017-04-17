using Xamarin.Forms;

namespace WAMWayStyles.Infrastructure
{
    interface IWAMWayStyle
    {
       
        Style ActivityIndicatorStyle { get; }
        Style ButtonStyle { get; }
        /// <summary>
        /// if you set the background here it is applied to everything. (Buttons, labels, etc... each have the background separately
        /// Only Set backgroundColor
        /// </summary>
        Style ViewStyle { get; }
        Style DatePickerStyle { get; }
        Style ContentViewStyle { get; }
        Style ContentPageStyle { get; }
        Style EntryStyle { get; }
        Style EditorStyle { get; }
        Style GridStyle { get; }
        Style InputViewStyle { get; }
        Style LabelStyle { get; }
        Style KeyboardStyle { get; }
        Style LayoutStyle { get; }
        Style ListViewStyle { get; }
        Style MasterDetailPageStyle { get; }
        Style NavigationMenuStyle { get; }
        Style PageStyle { get; }
        Style PickerStyle { get; }
        Style ProgressBarStyle { get; }
        Style RelativeLayoutStyle { get; }
        Style ScrollViewStyle { get; }
        Style SliderStyle { get; }
        Style StackLayoutStyle { get; }
        Style SwitchStyle { get; }
        Style TableViewStyle { get; }
        Style TextCellStyle { get; }
        Style ViewCellStyle { get; }
        Style CellStyle { get; }
        Style WebViewStyle { get; }
        Style TimePickerStyle { get; }
        Style AbsoluteLayoutStyle { get; }
        Style TabbedPageStyle { get; }
        Style LabelStyle_LargeFont { get; }
        Style LabelStyle_SmallFont { get; }
        Style LabelStyle_Bold { get; }
    }
}

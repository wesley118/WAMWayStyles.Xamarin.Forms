using WAMWayStyles.ColorTools;
using WAMWayStyles.Infrastructure;
using Xamarin.Forms;

namespace WAMWayStyles.Themes.Options
{
    public class AnalagousColorOptions : IBasicColorOptions
    {
        public AnalagousColorOptions(Color baseColor)
        {
            var Colors = new AnalogusColors(baseColor);
            ButtonColor = Colors.A1Color;
            DefaultTextColor = Colors.A3Color;
            HeaderTextColor = Colors.A2Color;
            ButtonTextColor = Colors.A3Color;
            DefaultBackgroundColor = Colors.BaseColor;
            DefaultAccentColor = Colors.A3Color;
            DefaultPlaceholderTextColor = Colors.A3Color.MultiplyAlpha(.5);
            EntryBackgroundColor = Colors.A2Color.MultiplyAlpha(.7);
        }
        public Color ButtonColor { get; private set; }
        public Color DefaultTextColor { get; private set; }
        public Color HeaderTextColor { get; private set; }
        public Color ButtonTextColor { get; private set; }
        public Color DefaultBackgroundColor { get; private set; }
        public Color DefaultAccentColor { get; private set; }
        public Color DefaultPlaceholderTextColor { get; private set; }
        public Color EntryBackgroundColor { get; private set; }
    }
}

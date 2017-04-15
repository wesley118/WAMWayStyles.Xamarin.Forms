using WAMWayStyles.ColorTools;
using WAMWayStyles.Infrastructure;
using Xamarin.Forms;

namespace WAMWayStyles.Themes.Options
{
    public class WholeScheme : IBasicColorOptions
    {

        public WholeScheme(Color color)
        {
            var colors = new ColorSchemes(color);
            DefaultBackgroundColor = colors.BaseColor;
            ButtonColor = colors.Analogous.A1Color;
            DefaultTextColor = colors.TetriadicColors.T2Color;
            ButtonTextColor = colors.Triadic.T2Color;
            EntryBackgroundColor = colors.NegativeAnalogous.A2NegColor.MultiplyAlpha(.75);
            DefaultAccentColor = colors.Complementary.ComplementaryColor;
            DefaultPlaceholderTextColor = colors.Analogous.A1Color.MultiplyAlpha(.75);
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

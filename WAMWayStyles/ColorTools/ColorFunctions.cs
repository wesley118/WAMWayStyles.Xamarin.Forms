using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace WAMWayStyles.ColorTools
{
    public class ColorFunctions
    {

        public Color[] GetPallete(string basehex)
        {
            var color = Color.FromHex(basehex);
            var lighter = conv(color, -60);
            var lightest = conv(lighter, -50);
            var darker = conv(color, 50);
            var darkest = conv(darker, 60);
            var neutral = color;
            return new Color[] { lightest, lighter, neutral, darker, darkest };
        }

        Color conv(Color color, double lum)
        {

            var R = color.R;
            var G = color.G;
            var B = color.B;
            double _R = (R / 255f);
            double _G = (G / 255f);
            double _B = (B / 255f);
            Debug.WriteLine(string.Format("###########\r\n\r\n\r\n\r\nR:{0}  G:{1} B:{2}\r\n\r\n\r\n##################", R, G, B));
            double _Min = Math.Min(Math.Min(_R, _G), _B);
            double _Max = Math.Max(Math.Max(_R, _G), _B);
            double _Delta = _Max - _Min;
            var lumin = color.AddLuminosity(lum * _Delta);

            Debug.WriteLine(string.Format("###########\r\n\r\n\r\n####ADD Luminosity: d:{3} lum:{4}\r\nR:{0}  G:{1} B:{2}\r\n\r\n\r\n##################", lumin.R, lumin.G, lumin.B, _Delta, lum));
            var sat = color.WithSaturation(color.Saturation * 2);
            Debug.WriteLine(string.Format("##########Saturation: R:{0} G:{1} B:{2} \r\nSaturationArgument:{3}", sat.R, sat.G, sat.B, color.Saturation * 2));
            var wlum = color.WithLuminosity(color.Luminosity * 2 * lum);
            Debug.WriteLine(string.Format("##########Luminosity: R:{0} G:{1} B:{2} \r\nLuminosityArgument:{3}", sat.R, sat.G, sat.B, color.Luminosity * 2 * lum));
            var hue = color.WithHue(color.Hue * 2);
            Debug.WriteLine(string.Format("##########Hue: R:{0} G:{1} B:{2} \r\nHueArgument:{3}", sat.R, sat.G, sat.B, color.Hue * 2));
            var n = wlum.WithSaturation(color.Saturation * 2 * lum);
            n = n.WithHue(color.Hue * 2 * lum);
            lumin = lumin.WithSaturation(lumin.Saturation + .2);
            lumin = lumin.WithHue(lumin.Hue + (_Delta *
                (lum > 0 ? 1 : -1) * 10));
            return lumin;//lumin.WithSaturation(.5);
        }

        public Color Complementary(Color color)
        {
            var h = Math.Abs((color.Hue + .5) - 1);
            return color.WithHue(h);
        }

        public Color[] Triadic(Color color)
        {
            var h1 = Math.Abs((color.Hue + (150 / 360)) - 1);
            var h2 = Math.Abs((color.Hue + (210 / 360)) - 1);
            return new Color[] { color, color.WithHue(h1), color.WithHue(h2) };
        }

        public Color[] Tetriadic(Color color)
        {
            var h1 = Math.Abs((color.Hue + (90 / 360)) - 1);
            var h2 = Math.Abs((color.Hue + (180 / 360)) - 1);
            var h3 = Math.Abs((color.Hue + (270 / 360)) - 1);
            return new Color[] { color, color.WithHue(h1), color.WithHue(h2), color.WithHue(h3) };
        }

        public Color[] Analogous(Color color)
        {
            var h1 = Math.Abs((color.Hue + (30 / 360)) - 1);
            var h2 = Math.Abs((color.Hue + (60 / 360)) - 1);
            var h3 = Math.Abs((color.Hue + (90 / 360)) - 1);
            return new Color[] { color, color.WithHue(h1), color.WithHue(h2), color.WithHue(h3) };
        }

        public Color[] NegativeAnalogous(Color color)
        {
            var h1 = Math.Abs((color.Hue + (330 / 360)) - 1);
            var h2 = Math.Abs((color.Hue + (300 / 360)) - 1);
            var h3 = Math.Abs((color.Hue + (270 / 360)) - 1);
            return new Color[] { color, color.WithHue(h1), color.WithHue(h2), color.WithHue(h3) };
        }



    }

    public class ColorSchemes
    {
        public ColorSchemes(Color baseColor)
        {
            basecolor = baseColor;
        }
        private Color basecolor;
        public Color BaseColor
        {
            get { return basecolor; }
        }
        private ComplementaryColors complementary;
        public ComplementaryColors Complementary
        {
            get
            {
                if (complementary == null)
                    complementary = new ComplementaryColors(BaseColor);
                return complementary;
            }
        }

        private TriadicColors triadColors;
        public TriadicColors Triadic
        {
            get
            {
                if (triadColors == null)
                    triadColors = new TriadicColors(BaseColor);
                return triadColors;
            }
        }

        private TetriadicColors tetriadicColors;
        public TetriadicColors TetriadicColors
        {
            get
            {
                if (tetriadicColors == null)
                    tetriadicColors = new TetriadicColors(BaseColor);
                return tetriadicColors;
            }
        }

        private AnalogusColors analogous;
        public AnalogusColors Analogous
        {
            get
            {
                if (analogous == null)
                    analogous = new AnalogusColors(BaseColor);
                return analogous;
            }
        }

        private NegativeAnalogusColors neg;
        public NegativeAnalogusColors NegativeAnalogous
        {
            get
            {
                if (neg == null)
                    neg = new NegativeAnalogusColors(BaseColor);
                return neg;
            }
        }
    }

    public class ComplementaryColors
    {
        public ComplementaryColors(Color baseColor)
        {
            BaseColor = baseColor;
        }
        private Color baseColor;
        public Color BaseColor
        {
            get { return baseColor; }
            set
            {
                baseColor = value;
                getComplentary();
            }
        }
        private Color complementaryColor;
        public Color ComplementaryColor { get { return complementaryColor; } }

        private void getComplentary()
        {
            complementaryColor = new ColorFunctions().Complementary(BaseColor);
        }
    }

    public class TriadicColors
    {
        public TriadicColors(Color baseColor)
        {
            var colors = new ColorFunctions().Triadic(baseColor);
            baseColor = colors[0];
            t1Color = colors[1];
            t2Color = colors[2];
        }
        private Color baseColor;
        public Color BaseColor
        {
            get { return baseColor; }
        }
        private Color t1Color;
        public Color T1Color
        {
            get { return t1Color; }

        }
        private Color t2Color;
        public Color T2Color
        {
            get { return t2Color; }
        }
    }

    public class TetriadicColors
    {
        public TetriadicColors(Color baseColor)
        {
            var colors = new ColorFunctions().Tetriadic(baseColor);
            baseColor = colors[0];
            t1Color = colors[1];
            t2Color = colors[2];
            t3Color = colors[3];
        }
        private Color baseColor;
        public Color BaseColor
        {
            get { return baseColor; }
        }
        private Color t1Color;
        public Color T1Color
        {
            get { return t1Color; }

        }
        private Color t2Color;
        public Color T2Color
        {
            get { return t2Color; }
        }
        private Color t3Color;
        public Color T3Color
        {
            get { return t3Color; }
        }
    }

    public class AnalogusColors
    {
        public AnalogusColors(Color baseColor)
        {
            var colors = new ColorFunctions().Analogous(baseColor);
            baseColor = colors[0];
            a1Color = colors[1];
            a2Color = colors[2];
            a3Color = colors[3];
        }
        private Color baseColor;
        public Color BaseColor
        {
            get { return baseColor; }
        }
        private Color a1Color;
        public Color A1Color
        {
            get { return a1Color; }
        }
        private Color a2Color;
        public Color A2Color
        {
            get { return a2Color; }
        }
        private Color a3Color;
        public Color A3Color
        {
            get { return a3Color; }
        }
    }

    public class NegativeAnalogusColors
    {
        public NegativeAnalogusColors(Color baseColor)
        {
            var colors = new ColorFunctions().NegativeAnalogous(baseColor);
            baseColor = colors[0];
            a1Color = colors[1];
            a2Color = colors[2];
            a3Color = colors[3];
        }
        private Color baseColor;
        public Color BaseColor
        {
            get { return baseColor; }
        }
        private Color a1Color;
        public Color A1NegColor
        {
            get { return a1Color; }
        }
        private Color a2Color;
        public Color A2NegColor
        {
            get { return a2Color; }
        }
        private Color a3Color;
        public Color A3NegColor
        {
            get { return a3Color; }
        }
    }



}

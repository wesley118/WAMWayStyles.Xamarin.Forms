using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace WAMWayStyles.ColorTools
{
    internal class ColorFunctions
    {
        /* Hue values --Color.Hue value is 0-1 inclusive so 1/360 = 1 degree by my logic
         * 0 = Red 0 * (1/360) = 0 
         * 60 = yellow 60 * (1/360) = 0.16666666666666
         * 120 = Green 120 * (1/360) = 1/3 == 0.33333333333333333333333
         * 240 = Blue 240 * (1/360) = 2/3 == 0.66666666666666666
         */
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
            var h = Math.Abs((color.Hue + .5f) - 1f);
            return color.WithHue(h);
        }

        public Color[] Triadic(Color color)
        {
            var h1 = Math.Abs((color.Hue + (150f / 360f)) - 1f);
            var h2 = Math.Abs((color.Hue + (210f / 360f)) - 1f);
            return new Color[] { color, color.WithHue(h1), color.WithHue(h2) };
        }

        public Color[] Tetriadic(Color color)
        {
            var h1 = Math.Abs((color.Hue + (90f / 360f)) - 1f);
            var h2 = Math.Abs((color.Hue + (180f / 360f)) - 1f);
            var h3 = Math.Abs((color.Hue + (270f / 360f)) - 1f);
            return new Color[] { color, color.WithHue(h1), color.WithHue(h2), color.WithHue(h3) };
        }

        public Color[] Analogous(Color color)
        {
            var hslc = HSLColor.FromRGB(color.R, color.G, color.B);
            var basec = color;
            var h1 = hslc.HueDegrees + 30;
            if (h1 > 360)
                h1 = Math.Abs(h1 - 360);
            var h2 = hslc.HueDegrees + 60;
            if (h2 > 360)
                h2 = Math.Abs(h2 - 360);
            var h3 = hslc.HueDegrees + 90;
            if (h3 > 360)
                h3 = Math.Abs(h3 - 360);
            var c1 = new HSLColor(h1 / 360, hslc.Saturation, hslc.Luminosity);
            var c2 = new HSLColor(h2 / 360, hslc.Saturation, hslc.Luminosity);
            var c3 = new HSLColor(h3 / 360, hslc.Saturation, hslc.Luminosity);
            return new Color[] { basec, c1.ToRGB(), c2.ToRGB(), c3.ToRGB() };
            //var hue = color.Hue;
            //Log.Information(string.Format("{0}:{1}", "Original Hue", hue.ToString()));
            //var hueDegree = (int)(hue * 360);
            //var h1add = hueDegree + 30;
            //var h1degree = Math.Abs(h1add - 360);
            //var h2degree = Math.Abs((hueDegree + 60) - 360);
            //var h3degree = Math.Abs((hueDegree + 90) - 360);
            //Log.Information("hdegrees:\r\nh:{0}\r\nh1:{1}\r\nh2:{2}\r\nh3:{3}", hueDegree, h1degree, h2degree, h3degree);
            //var h1 = Math.Abs((hue + (30f / 360f)) - 1f);
            //Log.Information(string.Format("{0}:{1}", "h1", h1));
            //var h2 = Math.Abs((hue + (60f / 360f)) - 1f);
            //Log.Information(string.Format("{0}:{1}", "h2", h2));
            //var h3 = Math.Abs((hue + (90f / 360f)) - 1f);
            //Log.Information(string.Format("{0}:{1}", "h2", h2));
            //return new Color[] { color, Color.FromHsla(h1degree, color.Saturation, color.Luminosity), Color.FromHsla(h2degree, color.Saturation, color.Luminosity), Color.FromHsla(h3degree, color.Saturation, color.Luminosity) };
        }

        public Color[] NegativeAnalogous(Color color)
        {
            var hslc = HSLColor.FromRGB(color.R, color.G, color.B);
            var basec = color;
            var h1 = hslc.HueDegrees - 30;
            if (h1 < 0)
                h1 = Math.Abs(h1 + 360);
            var h2 = hslc.HueDegrees - 60;
            if (h2 < 0)
                h2 = Math.Abs(h2 + 360);
            var h3 = hslc.HueDegrees - 90;
            if (h3 < 0)
                h3 = Math.Abs(h3 + 360);
            var c1 = new HSLColor(h1 / 360, hslc.Saturation, hslc.Luminosity);
            var c2 = new HSLColor(h2 / 360, hslc.Saturation, hslc.Luminosity);
            var c3 = new HSLColor(h3 / 360, hslc.Saturation, hslc.Luminosity);
            return new Color[] { basec, c1.ToRGB(), c2.ToRGB(), c3.ToRGB() };
            //var h1 = Math.Abs((color.Hue + (330f / 360f)) - 1f);
            //var h2 = Math.Abs((color.Hue + (300f / 360f)) - 1f);
            //var h3 = Math.Abs((color.Hue + (270f / 360f)) - 1f);
            //return new Color[] { color, color.WithHue(h1), color.WithHue(h2), color.WithHue(h3) };
        }





    }
    internal class HSLColor
    {
        public float Hue { get; set; }
        public float Saturation { get; set; }
        public float Luminosity { get; set; }
        public float HueDegrees
        {
            get
            {

                var H = Hue * 60;
                if (H < 0)
                    H += 360;
                return H;
            }
        }
        public float SatPercentage
        {
            get
            {
                return Saturation * 100;
            }
        }
        public float LumPercentage
        {
            get { return Luminosity * 100; }
        }
        public HSLColor(float H, float S, float L)
        {
            Hue = H;
            Saturation = S;
            Luminosity = L;
        }

        public static HSLColor FromRGB(double R, double G, double B)
        {
            float _R = ((float)R / 255f);
            float _G = ((float)G / 255f);
            float _B = ((float)B / 255f);

            float _Min = Math.Min(Math.Min(_R, _G), _B);
            float _Max = Math.Max(Math.Max(_R, _G), _B);
            float _Delta = _Max - _Min;

            float H = 0;
            float S = 0;
            float L = (float)((_Max + _Min) / 2.0f);

            if (_Delta != 0)
            {
                if (L < 0.5f)
                {
                    S = (float)(_Delta / (_Max + _Min));
                }
                else
                {
                    S = (float)(_Delta / (2.0f - _Max - _Min));
                }


                if (_R == _Max)
                {
                    H = (_G - _B) / _Delta;
                }
                else if (_G == _Max)
                {
                    H = 2f + (_B - _R) / _Delta;
                }
                else if (_B == _Max)
                {
                    H = 4f + (_R - _G) / _Delta;
                }
            }

            return new HSLColor(H, S, L);
        }
        public Color ToRGB()
        {
            byte r, g, b;
            if (Saturation == 0)
            {
                r = (byte)Math.Round(Luminosity * 255d);
                g = (byte)Math.Round(Luminosity * 255d);
                b = (byte)Math.Round(Luminosity * 255d);
            }
            else
            {
                double t1, t2;
                double th = Hue;

                if (Luminosity < 0.5d)
                {
                    t2 = Luminosity * (1d + Saturation);
                }
                else
                {
                    t2 = (Luminosity + Saturation) - (Luminosity * Saturation);
                }
                t1 = 2d * Luminosity - t2;

                double tr, tg, tb;
                tr = th + (1.0d / 3.0d);
                tg = th;
                tb = th - (1.0d / 3.0d);

                tr = ColorCalc(tr, t1, t2);
                tg = ColorCalc(tg, t1, t2);
                tb = ColorCalc(tb, t1, t2);
                r = (byte)Math.Round(tr * 255d);
                g = (byte)Math.Round(tg * 255d);
                b = (byte)Math.Round(tb * 255d);
            }
            return Color.FromRgb(r, g, b);
        }
        private static double ColorCalc(double c, double t1, double t2)
        {

            if (c < 0) c += 1d;
            if (c > 1) c -= 1d;
            if (6.0d * c < 1.0d) return t1 + (t2 - t1) * 6.0d * c;
            if (2.0d * c < 1.0d) return t2;
            if (3.0d * c < 2.0d) return t1 + (t2 - t1) * (2.0d / 3.0d - c) * 6.0d;
            return t1;
        }
    }

    internal class ColorSchemes
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

    internal class ComplementaryColors
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

    internal class TriadicColors
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

    internal class TetriadicColors
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

    internal class AnalogusColors
    {
        internal AnalogusColors(Color baseColor)
        {
            var colors = new ColorFunctions().Analogous(baseColor);
            this.basecolor = baseColor;
            a1Color = colors[1];
            a2Color = colors[2];
            a3Color = colors[3];
        }
        private Color basecolor;
        internal Color BaseColor
        {
            get { return this.basecolor; }
        }
        private Color a1Color;
        internal Color A1Color
        {
            get { return a1Color; }
        }
        private Color a2Color;
        internal Color A2Color
        {
            get { return a2Color; }
        }
        private Color a3Color;
        internal Color A3Color
        {
            get { return a3Color; }
        }
    }

    internal class NegativeAnalogusColors
    {
        internal NegativeAnalogusColors(Color baseColor)
        {
            var colors = new ColorFunctions().NegativeAnalogous(baseColor);
            baseColor = colors[0];
            a1Color = colors[1];
            a2Color = colors[2];
            a3Color = colors[3];
        }
        private Color baseColor;
        internal Color BaseColor
        {
            get { return baseColor; }
        }
        private Color a1Color;
        internal Color A1NegColor
        {
            get { return a1Color; }
        }
        private Color a2Color;
        internal Color A2NegColor
        {
            get { return a2Color; }
        }
        private Color a3Color;
        internal Color A3NegColor
        {
            get { return a3Color; }
        }
    }

    internal class TranslateColor
    {
        internal static void RGBtoHSL(double r, double g, double b)
        {
            ////            //R, G and B input range = 0 ÷ 255
            ////            //H, S and L output range = 0 ÷ 1.0

            ////            var_R = (R / 255)
            ////var_G = (G / 255)
            ////var_B = (B / 255)

            ////var_Min = min(var_R, var_G, var_B)    //Min. value of RGB
            ////var_Max = max(var_R, var_G, var_B)    //Max. value of RGB
            ////del_Max = var_Max - var_Min             //Delta RGB value

            ////L = (var_Max + var_Min) / 2

            ////if (del_Max == 0)                     //This is a gray, no chroma...
            ////            {
            ////                H = 0
            ////    S = 0
            ////}
            ////            else                                    //Chromatic data...
            ////            {
            ////                if (L < 0.5) S = del_Max / (var_Max + var_Min)
            ////                else S = del_Max / (2 - var_Max - var_Min)
            
            ////   del_R = (((var_Max - var_R) / 6) + (del_Max / 2)) / del_Max
            ////               del_G = (((var_Max - var_G) / 6) + (del_Max / 2)) / del_Max
            ////               del_B = (((var_Max - var_B) / 6) + (del_Max / 2)) / del_Max
            
            ////   if (var_R == var_Max) H = del_B - del_G
            ////   else if (var_G == var_Max) H = (1 / 3) + del_R - del_B
            ////   else if (var_B == var_Max) H = (2 / 3) + del_G - del_R
            
            ////    if (H < 0) H += 1
            ////                if (H > 1) H -= 1
            ////            }



            var R = (r / 255d);
            var G = (g / 255d);
            var B = (b / 255d);
        }


                    ///HSL to RGB
                    /////H, S and L input range = 0 ÷ 1.0
            //////R, G and B output range = 0 ÷ 255

            ////if (S == 0 )
            ////{

            ////   R = L* 255
            ////   G = L* 255
            ////   B = L* 255
            ////}
            ////else
            ////{
            ////   if (L< 0.5 ) var_2 = L* ( 1 + S )
            ////   else           var_2 = (L + S ) - (S* L )

            ////  var_1 = 2 * L - var_2

            ////   R = 255 * Hue_2_RGB(var_1, var_2, H + ( 1 / 3 ) )
            ////   G = 255 * Hue_2_RGB(var_1, var_2, H )
            ////   B = 255 * Hue_2_RGB(var_1, var_2, H - ( 1 / 3 ) )
            ////}

            ////Hue_2_RGB(v1, v2, vH )             //Function Hue_2_RGB
            ////{
            ////    if (vH < 0) vH += 1
            ////   if (vH > 1) vH -= 1
            ////   if ((6 * vH) < 1) return (v1 + (v2 - v1) * 6 * vH)
            ////   if ((2 * vH) < 1) return (v2)
            ////   if ((3 * vH) < 2) return (v1 + (v2 - v1) * ((2 / 3) - vH) * 6)
            ////   return (v1)
            ////}
   }



}

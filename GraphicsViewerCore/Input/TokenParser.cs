using System;
using System.Drawing;

namespace GraphicsViewer.Core.Input
{
    /// <summary>
    /// Simple token parser. As it is mentioned in the challenge, we are not validating an input data
    /// </summary>
    public class TokenParser
    {
        private const char Delimiter = ';';

        public static float ParseFloat(string input)
        {
            input = input.Replace(',', '.');

            return Convert.ToSingle(input);
        }

        public static PointF ParsePoint(string input)
        {
            input = input.Replace(',', '.');
            var splitted = input.Split(Delimiter, StringSplitOptions.RemoveEmptyEntries);

            var x = Convert.ToSingle(splitted[0]);
            var y = Convert.ToSingle(splitted[1]);

            return new PointF(x, y);
        }

        public static Color ParseColor(string input)
        {
            var splitted = input.Split(Delimiter, StringSplitOptions.RemoveEmptyEntries);

            var alpha = Convert.ToByte(splitted[0]);
            var red = Convert.ToByte(splitted[1]);
            var green = Convert.ToByte(splitted[2]);
            var blue = Convert.ToByte(splitted[3]);

            return Color.FromArgb(alpha, red, green, blue);
        }

        public static bool ParseBoolean(string input)
        {
            return Convert.ToBoolean(input);
        }
    }
}
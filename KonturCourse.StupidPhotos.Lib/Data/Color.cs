using System;

namespace KonturCourse.StupidPhotos.Lib.Data
{
    public readonly struct Color
    {
        public Color(double red, double green, double blue)
        {
            if (red < 0 || red > 1)
                throw new ArgumentOutOfRangeException(nameof(red));
            if (green < 0 || green > 1)
                throw new ArgumentOutOfRangeException(nameof(green));
            if (blue < 0 || blue > 1)
                throw new ArgumentOutOfRangeException(nameof(blue));
            Red = red;
            Green = green;
            Blue = blue;
        }

        public double Red { get; }
        public double Green { get; }
        public double Blue { get; }

        private static double Trim(double val) => val < 0
            ? 0
            : val > 1
                ? 1
                : val;

        public static Color operator *(Color color, double multiplier) => new Color(
            Trim(color.Red * multiplier),
            Trim(color.Green * multiplier),
            Trim(color.Blue * multiplier));

        public static Color operator *(double multiplier, Color color) => color * multiplier;

        public void Deconstruct(out double red, out double green, out double blue) =>
            (red, green, blue) = (Red, Green, Blue);
    }
}
namespace KonturCourse.StupidPhotos.Lib.Data
{
    public readonly struct Color
    {
        public Color(double red, double green, double blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public double Red { get; }
        public double Green { get; }
        public double Blue { get; }

        public void Deconstruct(out double red, out double green, out double blue) =>
            (red, green, blue) = (Red, Green, Blue);
    }
}
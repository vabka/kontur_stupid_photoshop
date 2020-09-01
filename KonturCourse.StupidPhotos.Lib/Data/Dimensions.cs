using System;

namespace KonturCourse.StupidPhotos.Lib.Data
{
    public readonly struct Dimensions
    {
        public Dimensions(int width, int height)
        {
            if (width < 0)
                throw new ArgumentOutOfRangeException(nameof(width));
            if (height < 0)
                throw new ArgumentOutOfRangeException(nameof(height));
            Width = width;
            Height = height;
        }

        public int Width { get; }
        public int Height { get; }
        public int Area => Width * Height;
        public void Deconstruct(out int width, out int height) => (width, height) = (Width, Height);
    }
}
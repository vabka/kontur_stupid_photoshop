using System;

namespace KonturCourse.StupidPhotos.Lib.Data
{
    public readonly struct Point
    {
        public Point(int x, int y)
        {
            if (x < 0)
                throw new ArgumentOutOfRangeException(nameof(x));
            if (y < 0)
                throw new ArgumentOutOfRangeException(nameof(y));
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
        public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
    }
}
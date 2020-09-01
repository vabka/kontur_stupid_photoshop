﻿using System;

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

    public readonly struct Pixel
    {
        public Pixel(Point point, Color color) => (Point, Color) = (point, color);

        public Point Point { get; }
        public Color Color { get; }

        public void Deconstruct(out int x, out int y) => (x, y) = Point;

        public void Deconstruct(out int x, out int y, out double r, out double g, out double b) =>
            ((x, y), (r, g, b)) = (Point, Color);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace KonturCourse.StupidPhotos.Lib.Data
{
    public readonly struct Photo : IEnumerable<Pixel>
    {
        public static Photo Create(int width, int height, Func<Point, Color> initializer)
        {
            Debug.Assert(width > 0);
            Debug.Assert(height > 0);
            var buf = new Memory<Color>(new Color[width * height]);
            var span = buf.Span;
            for (var x = 0; x < width; x++)
            for (var y = 0; y < height; y++)
                span[GetOffset(width, y, x)] = initializer(new Point(x, y));
            return new Photo(width, height, buf);
        }

        private static int GetOffset(int width, int y, int x)
        {
            return y * width + x;
        }

        public Photo(int width, int height, ReadOnlyMemory<Color> data) =>
            (Width, Height, Data) = (width, height, data);

        public int Width { get; }
        public int Height { get; }
        public ReadOnlyMemory<Color> Data { get; }
        public Color this[Point point] => this[point.X, point.Y];
        public Color this[int x, int y] => Data.Span[GetOffset(Width, y, x)];

        public IEnumerator<Pixel> GetEnumerator()
        {
            for (var x = 0; x < Width; x++)
            for (var y = 0; y < Height; y++)
                yield return new Pixel(new Point(x, y), this[x, y]);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
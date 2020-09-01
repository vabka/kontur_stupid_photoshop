using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KonturCourse.StupidPhotos.Lib.Data
{
    public readonly struct Photo : IEnumerable<Pixel>
    {
        public Photo(Dimensions dimensions, ReadOnlyMemory<Color> data) =>
            (Dimensions, Data) = (dimensions, data);

        public static Photo Create(Dimensions dimensions, Func<Point, Color> initializer)
        {
            var buf = new Memory<Color>(new Color[dimensions.Area]);
            var span = buf.Span;
            foreach (var point in dimensions.EnumeratePoints())
                span[GetOffset(dimensions.Width, point)] = initializer(point);
            return new Photo(dimensions, buf);
        }

        private static int GetOffset(int width, Point point) =>
            point.Y * width + point.X;


        public Dimensions Dimensions { get; }
        public ReadOnlyMemory<Color> Data { get; }

        public Color this[Point point] => Data.Span[GetOffset(Dimensions.Width, point)];

        public IEnumerator<Pixel> GetEnumerator()
        {
            var self = this;
            return Dimensions.EnumeratePoints()
                .Select(point => new Pixel(point, self[point]))
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
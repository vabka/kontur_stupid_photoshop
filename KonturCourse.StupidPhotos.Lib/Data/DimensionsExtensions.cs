using System.Collections.Generic;

namespace KonturCourse.StupidPhotos.Lib.Data
{
    public static class DimensionsExtensions
    {
        public static IEnumerable<Point> EnumeratePoints(this Dimensions dimensions)
        {
            for (var x = 0; x < dimensions.Width; x++)
            for (var y = 0; y < dimensions.Height; y++)
                yield return new Point(x, y);
        }
    }
}
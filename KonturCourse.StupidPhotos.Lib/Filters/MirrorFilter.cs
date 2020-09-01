using System;
using KonturCourse.StupidPhotos.Lib.Data;
using KonturCourse.StupidPhotos.Lib.Filters.Attributes;

namespace KonturCourse.StupidPhotos.Lib.Filters
{
    [Filter("mirror")]
    public class MirrorFilter : IFilter
    {
        [Parameter("mirror orientation")]
        public MirrorOrientation Orientation { get; set; } = MirrorOrientation.Horizontal;

        public Photo Process(Photo original)
        {
            return Photo.Create(original.Dimensions, point =>
            {
                var (width, height) = original.Dimensions;
                var (x, y) = point;
                return Orientation switch
                {
                    MirrorOrientation.Horizontal => original[new Point(x, height - y - 1)],
                    MirrorOrientation.Vertical => original[new Point(width - x - 1, y)],
                    _ => throw new InvalidOperationException("invalid enum value")
                };
            });
        }
    }
}
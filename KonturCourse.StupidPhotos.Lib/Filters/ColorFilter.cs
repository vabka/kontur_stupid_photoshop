using KonturCourse.StupidPhotos.Lib.Data;

namespace KonturCourse.StupidPhotos.Lib.Filters
{
    public abstract class ColorFilter : IFilter
    {
        public Photo Process(Photo original) =>
            Photo.Create(original.Dimensions, point => TransformColor(original[point]));

        protected abstract Color TransformColor(Color color);
    }
}
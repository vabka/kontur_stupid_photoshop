using KonturCourse.StupidPhotos.Lib.Data;

namespace KonturCourse.StupidPhotos.Lib.Filters
{
    public interface IFilter
    {
        Photo Process(Photo original);
    }
}
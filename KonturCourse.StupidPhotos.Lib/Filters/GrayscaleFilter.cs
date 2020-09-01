using KonturCourse.StupidPhotos.Lib.Data;

namespace KonturCourse.StupidPhotos.Lib.Filters
{
    public class GrayscaleFilter : IFilter
    {
        public ParameterInfo[] GetParameters()
        {
            return new ParameterInfo[0];
        }

        public override string ToString() => "Ч/б фильтр";

        public Photo Process(Photo original, double[] parameters) =>
            Photo.Create(original.Dimensions, point =>
            {
                var (red, green, blue) = original[point];
                var averageSaturation = (red + green + blue) / 3;
                return new Color(averageSaturation, averageSaturation, averageSaturation);
            });
    }
}
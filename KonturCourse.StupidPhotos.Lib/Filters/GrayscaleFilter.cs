using KonturCourse.StupidPhotos.Lib.Data;

namespace KonturCourse.StupidPhotos.Lib.Filters
{
    [Filter("grayscale")]
    public class GrayscaleFilter : ColorFilter
    {
        protected override Color TransformColor(Color color)
        {
            var (red, green, blue) = color;
            var averageSaturation = (red + green + blue) / 3;
            return new Color(averageSaturation, averageSaturation, averageSaturation);
        }
    }
}
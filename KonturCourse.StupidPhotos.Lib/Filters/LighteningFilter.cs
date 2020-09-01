using KonturCourse.StupidPhotos.Lib.Data;

namespace KonturCourse.StupidPhotos.Lib.Filters
{
    [Filter("lighten")]
    public class LighteningFilter : ColorFilter
    {
        [Parameter("ratio")]
        [Range(0.0, 10.0)]
        public double Ratio { get; set; } = 1;

        protected override Color TransformColor(Color color) => color * Ratio;
    }
}
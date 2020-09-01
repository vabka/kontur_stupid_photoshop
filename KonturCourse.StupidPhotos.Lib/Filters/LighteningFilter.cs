using System;
using KonturCourse.StupidPhotos.Lib.Data;

namespace KonturCourse.StupidPhotos.Lib.Filters
{
    public class LighteningFilter : IFilter
    {
        public ParameterInfo[] GetParameters()
        {
            return new[]
            {
                new ParameterInfo {Name = "Коэффициент", MaxValue = 10, MinValue = 0, Increment = 0.1, DefaultValue = 1}
            };
        }

        public override string ToString()
        {
            return "Осветление/затемнение";
        }

        public Photo Process(Photo original, double[] parameters)
        {
            var multiplier = parameters switch
            {
                {Length: 1} arr => arr[0],
                {Length: 0} => 1.0,
                null => throw new ArgumentNullException(nameof(parameters)),
                _ => throw new ArgumentException(nameof(parameters))
            };

            return Photo.Create(original.Width, original.Height, point => original[point] * multiplier);
        }
    }
}
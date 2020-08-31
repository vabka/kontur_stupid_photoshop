using KonturCourse.Data;

namespace KonturCourse.Filters
{
    public class CropFilter : IFilter
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
            var result = new Photo
            {
                Width = original.Width,
                Height = original.Height
            };
            result.Data = new double[result.Width, result.Height, 3];

            for (var x = 0; x < result.Width; x++)
            for (var y = 0; y < result.Height; y++)
            for (var z = 0; z < 3; z++)
                result.Data[x, y, z] = original.Data[x, y, z] * parameters[0];
            return result;
        }
    }
}
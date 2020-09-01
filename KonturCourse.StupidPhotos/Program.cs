using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using KonturCourse.StupidPhotos.Lib.Data;
using KonturCourse.StupidPhotos.Lib.Filters;

namespace KonturCourse
{
    class Program
    {
        static void Main(string[] args)
        {
            var filter = Create(args[0], args.Skip(2));
            var path = args[1];
            using var image = Image.FromFile(path);
            using var bitmap = new Bitmap(image);
            var photo = Convertors.Bitmap2Photo(bitmap);
            var resultPhoto = filter.Process(photo);
            using var resultBitmap = Convertors.Photo2Bitmap(resultPhoto);
            resultBitmap.Save("out.jpg");
        }

        private static readonly IReadOnlyList<Type> FilterTypes = new[]
            {typeof(LighteningFilter), typeof(GrayscaleFilter)};

        static IFilter Create(string filterName, IEnumerable<string> filterArgs)
        {
            var filter = FilterTypes.First(type =>
            {
                var attr = type.GetCustomAttribute<FilterAttribute>();
                return attr?.Name == filterName;
            });
            var filterObject = Activator.CreateInstance(filter);
            foreach (var (prop, val) in filter.GetProperties(BindingFlags.Public |
                                                             BindingFlags.Instance |
                                                             BindingFlags.SetProperty)
                .Where(prop =>
                {
                    var attr = prop.GetCustomAttribute<ParameterAttribute>();
                    return attr != null;
                })
                .Zip(filterArgs))
            {
                object value = null;
                if (prop.PropertyType == typeof(double))
                    value = double.Parse(val, CultureInfo.InvariantCulture);
                if (prop.PropertyType == typeof(int))
                    value = int.Parse(val, CultureInfo.InvariantCulture);
                if (prop.PropertyType == typeof(string))
                    value = val;
                if (value != null)
                    prop.SetValue(filterObject, value);
            }

            return (IFilter) filterObject;
        }
    }
}
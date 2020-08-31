using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using KonturCourse.Data;
using KonturCourse.Filters;

namespace KonturCourse
{
    class Program
    {
        static void Main(string[] args)
        {
            var filter = args[0] switch
            {
                "crop" => (IFilter) new CropFilter(),
                "lighten" => new LighteningFilter(),
                _ => throw new InvalidOperationException("Unknown filter")
            };
            if (args[1] == "?")
            {
                Console.WriteLine($"Filter: {args[0]}");
                var parameters = filter.GetParameters();
                foreach (var parameter in parameters)
                {
                    Console.WriteLine($"Parameter '{parameter.Name}'");
                    Console.WriteLine($"Min: {parameter.MinValue}");
                    Console.WriteLine($"Max: {parameter.MaxValue}");
                    Console.WriteLine($"Default: {parameter.DefaultValue}");
                    Console.WriteLine();
                }

                return;
            }

            var path = args[1];
            using var image = Image.FromFile(path);
            using var bitmap = new Bitmap(image);
            var photo = Convertors.Bitmap2Photo(bitmap);
            var resultPhoto = filter.Process(photo,
                args
                    .Skip(2)
                    .Select(x => double.Parse(x, CultureInfo.InvariantCulture)).ToArray());
            using var resultBitmap = Convertors.Photo2Bitmap(resultPhoto);
            resultBitmap.Save("out.jpg");
        }
    }
}
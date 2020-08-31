using System;
using System.Drawing;

namespace KonturCourse.Data
{
    public static class Convertors
    {
        public static Photo Bitmap2Photo(Bitmap bmp)
        {
            var photo = new Photo
            {
                Width = bmp.Width,
                Height = bmp.Height,
                Data = new double[bmp.Width, bmp.Height, 3]
            };
            for (var x = 0; x < bmp.Width; x++)
            for (var y = 0; y < bmp.Height; y++)
            {
                var pixel = bmp.GetPixel(x, y);
                photo.Data[x, y, 0] = (double) pixel.R / 255;
                photo.Data[x, y, 1] = (double) pixel.G / 255;
                photo.Data[x, y, 2] = (double) pixel.B / 255;
            }

            return photo;
        }

        private static int ToChannel(double val)
        {
            if (val < 0 || val > 1)
                throw new Exception($"Wrong channel value {val} (the value must be between 0 and 1");
            return (int) (val * 255);
        }

        public static Bitmap Photo2Bitmap(Photo photo)
        {
            var bmp = new Bitmap(photo.Width, photo.Height);
            for (var x = 0; x < bmp.Width; x++)
            for (var y = 0; y < bmp.Height; y++)
            {
                bmp.SetPixel(x, y, Color.FromArgb(
                    ToChannel(photo.Data[x, y, 0]),
                    ToChannel(photo.Data[x, y, 1]),
                    ToChannel(photo.Data[x, y, 2])));
            }

            return bmp;
        }
    }
}
using System;
using System.Drawing;

namespace KonturCourse.StupidPhotos.Lib.Data
{
    public static class Convertors
    {
        public static Photo Bitmap2Photo(Bitmap bmp) =>
            Photo.Create(bmp.Width, bmp.Height, point =>
            {
                var (x, y) = point;
                var color = bmp.GetPixel(x, y);
                return new Color(FromChannel(color.R),
                    FromChannel(color.G),
                    FromChannel(color.B));
            });

        private static double FromChannel(byte val) => val / 255.0;

        private static byte ToChannel(double val)
        {
            if (val < 0 || val > 1)
                throw new Exception($"Wrong channel value {val} (the value must be between 0 and 1");
            return (byte) (val * 255);
        }

        public static Bitmap Photo2Bitmap(Photo photo)
        {
            var bmp = new Bitmap(photo.Width, photo.Height);
            foreach (var (x, y, r, g, b) in photo)
            {
                bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(
                    ToChannel(r),
                    ToChannel(g),
                    ToChannel(b)));
            }

            return bmp;
        }
    }
}
using System.Drawing;
using Xunit;

namespace KonturCourse.StupidPhotos.Tests
{
    public static class AssertBitmap
    {
        public static void SamePixels(Bitmap expected, Bitmap actual)
        {
            Assert.Equal(expected.Width, actual.Width);
            Assert.Equal(expected.Height, actual.Height);

            for (var x = 0; x < expected.Width; x++)
            for (var y = 0; y < expected.Height; y++)
            {
                var expectedPixel = expected.GetPixel(x, y);
                var actualPixel = actual.GetPixel(x, y);
                Assert.Equal(expectedPixel.R, actualPixel.R);
                Assert.Equal(expectedPixel.G, actualPixel.G);
                Assert.Equal(expectedPixel.B, actualPixel.B);
                Assert.Equal(expectedPixel.A, actualPixel.A);
            }
        }
    }
}
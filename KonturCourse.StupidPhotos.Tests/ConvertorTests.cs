using System.Drawing;
using KonturCourse.StupidPhotos.Lib.Data;
using Xunit;

namespace KonturCourse.StupidPhotos.Tests
{
    public class ConvertorTests
    {
        [Fact]
        public void Bidirectional()
        {
            using var cat = Image.FromFile("cat.jpg");
            using var originalBitmap = new Bitmap(cat);

            var photo = Convertors.Bitmap2Photo(originalBitmap);
            using var newBitmap = Convertors.Photo2Bitmap(photo);
            AssertBitmap.SamePixels(originalBitmap, newBitmap);
        }
    }
}
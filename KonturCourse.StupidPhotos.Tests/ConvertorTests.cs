using System.Drawing;
using System.IO;
using KonturCourse.StupidPhotos.Lib.Data;
using Xunit;

namespace KonturCourse.StupidPhotos.Tests
{
    public class ConvertorTests
    {
        [Fact]
        public void Bidirectional()
        {
            using var cat = Image.FromFile(TestData.Path("cat.jpg"));
            using var originalBitmap = new Bitmap(cat);

            var photo = Convertors.Bitmap2Photo(originalBitmap);
            using var newBitmap = Convertors.Photo2Bitmap(photo);
            AssertBitmap.SamePixels(originalBitmap, newBitmap);
        }
    }
}
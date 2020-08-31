using System.Drawing;
using KonturCourse.StupidPhotos.Lib.Data;
using KonturCourse.StupidPhotos.Lib.Filters;
using Xunit;

namespace KonturCourse.StupidPhotos.Tests
{
    public class LightenTests
    {
        [Fact]
        public void None()
        {
            using var image = Image.FromFile(TestData.Path("cat.jpg"));
            using var catBitmap = new Bitmap(image);
            var photo = Convertors.Bitmap2Photo(catBitmap);
            var filter = new LighteningFilter();
            var result = filter.Process(photo, new[] {1.0});
            using var resultBitmap = Convertors.Photo2Bitmap(result);
            AssertBitmap.SamePixels(catBitmap, resultBitmap);
        }

        [Fact]
        public void Darken()
        {
            using var expectedImage = Image.FromFile(TestData.Path("lightening", "down.jpg"));
            using var expectedBitmap = new Bitmap(expectedImage);
            using var image = Image.FromFile(TestData.Path("cat.jpg"));
            using var catBitmap = new Bitmap(image);
            var photo = Convertors.Bitmap2Photo(catBitmap);
            var filter = new LighteningFilter();
            var result = filter.Process(photo, new[] {0.5});
            using var resultBitmap = Convertors.Photo2Bitmap(result);
            AssertBitmap.SamePixels(expectedBitmap, resultBitmap);
        }
    }
}
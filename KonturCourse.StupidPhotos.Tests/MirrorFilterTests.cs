using System.Drawing;
using KonturCourse.StupidPhotos.Lib.Data;
using KonturCourse.StupidPhotos.Lib.Filters;
using Xunit;

namespace KonturCourse.StupidPhotos.Tests
{
    public class MirrorFilterTests
    {
        [Fact]
        void MirroredImageIsNotEqualToOriginal()
        {
            using var image = Image.FromFile(TestData.Path("cat.jpg"));
            using var catBitmap = new Bitmap(image);
            var photo = Convertors.Bitmap2Photo(catBitmap);
            var filter = new MirrorFilter
            {
                Orientation = MirrorOrientation.Horizontal
            };
            var newPhoto = filter.Process(photo);
            using var resultBitmap = Convertors.Photo2Bitmap(newPhoto);
            AssertBitmap.NotSamePixels(catBitmap, resultBitmap);
        }

        [Fact]
        void DoubleMirroredImageIsEqualToOriginal()
        {
            using var image = Image.FromFile(TestData.Path("cat.jpg"));
            using var catBitmap = new Bitmap(image);
            var photo = Convertors.Bitmap2Photo(catBitmap);
            var filter = new MirrorFilter
            {
                Orientation = MirrorOrientation.Horizontal
            };
            var newPhoto = filter.Process(filter.Process(photo));
            using var resultBitmap = Convertors.Photo2Bitmap(newPhoto);
            AssertBitmap.SamePixels(catBitmap, resultBitmap);
        }

        [Fact]
        void MirroredImageIsNotEqualToOriginalVertical()
        {
            using var image = Image.FromFile(TestData.Path("cat.jpg"));
            using var catBitmap = new Bitmap(image);
            var photo = Convertors.Bitmap2Photo(catBitmap);
            var filter = new MirrorFilter
            {
                Orientation = MirrorOrientation.Vertical
            };
            var newPhoto = filter.Process(photo);
            using var resultBitmap = Convertors.Photo2Bitmap(newPhoto);
            AssertBitmap.NotSamePixels(catBitmap, resultBitmap);
        }

        [Fact]
        void DoubleMirroredImageIsEqualToOriginalVertical()
        {
            using var image = Image.FromFile(TestData.Path("cat.jpg"));
            using var catBitmap = new Bitmap(image);
            var photo = Convertors.Bitmap2Photo(catBitmap);
            var filter = new MirrorFilter
            {
                Orientation = MirrorOrientation.Vertical
            };
            var newPhoto = filter.Process(filter.Process(photo));
            using var resultBitmap = Convertors.Photo2Bitmap(newPhoto);
            AssertBitmap.SamePixels(catBitmap, resultBitmap);
        }
    }
}
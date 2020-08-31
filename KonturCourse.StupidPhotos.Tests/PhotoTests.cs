using System;
using KonturCourse.StupidPhotos.Lib.Data;
using Xunit;

namespace KonturCourse.StupidPhotos.Tests
{
    public class PhotoTests
    {
        [Fact]
        public void ValidInitialization()
        {
            var photo = Photo.Create(3, 4, point => point switch
            {
                (0, 0) => new Color(0.25, 0, 0),
                (0, 1) => new Color(0.5, 0, 0),
                (0, 2) => new Color(1, 0, 0),
                (0, 3) => new Color(0.25, 0.25, 0.25),
                (1, 0) => new Color(0, 0.25, 0),
                (1, 1) => new Color(0, 0.5, 0),
                (1, 2) => new Color(0, 1, 0),
                (1, 3) => new Color(0.5, 0.5, 0.5),
                (2, 0) => new Color(0, 0, 0.25),
                (2, 1) => new Color(0, 0, 0.5),
                (2, 2) => new Color(0, 0, 1),
                (2, 3) => new Color(1, 1, 1),
                _ => throw new InvalidOperationException()
            });

            foreach (var pixel in photo)
            {
                var expected = pixel switch
                {
                    (0, 0) => new Color(0.25, 0, 0),
                    (0, 1) => new Color(0.5, 0, 0),
                    (0, 2) => new Color(1, 0, 0),
                    (0, 3) => new Color(0.25, 0.25, 0.25),
                    (1, 0) => new Color(0, 0.25, 0),
                    (1, 1) => new Color(0, 0.5, 0),
                    (1, 2) => new Color(0, 1, 0),
                    (1, 3) => new Color(0.5, 0.5, 0.5),
                    (2, 0) => new Color(0, 0, 0.25),
                    (2, 1) => new Color(0, 0, 0.5),
                    (2, 2) => new Color(0, 0, 1),
                    (2, 3) => new Color(1, 1, 1),
                    _ => throw new InvalidOperationException()
                };
                Assert.Equal(expected, pixel.Color);
            }
        }
    }
}
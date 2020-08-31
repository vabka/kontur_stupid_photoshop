namespace KonturCourse.StupidPhotos.Tests
{
    public static class TestData
    {
        public static string Path(params string[] path) =>
            System.IO.Path.Combine("testData", System.IO.Path.Combine(path));
    }
}
using System;

namespace KonturCourse.StupidPhotos.Lib.Filters
{
    public class FilterAttribute : Attribute
    {
        public FilterAttribute(string name) => Name = name;
        public string Name { get; }
    }
}
using System;

namespace KonturCourse.StupidPhotos.Lib.Filters.Attributes
{
    public class FilterAttribute : Attribute
    {
        public FilterAttribute(string name) => Name = name;
        public string Name { get; }
    }
}
using System;

namespace KonturCourse.StupidPhotos.Lib.Filters.Attributes
{
    public class ParameterAttribute : Attribute
    {
        public string Name { get; }
        public ParameterAttribute(string name) => Name = name;
    }
}
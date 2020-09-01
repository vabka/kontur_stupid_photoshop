using System;

namespace KonturCourse.StupidPhotos.Lib.Filters
{
    public class ParameterAttribute : Attribute
    {
        public string Name { get; }
        public ParameterAttribute(string name) => Name = name;
    }
}
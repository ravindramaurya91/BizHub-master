using System;

namespace Base 
{

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class HttpServiceAttribute : Attribute
    {

        public HttpServiceAttribute()
        {
        }

        public HttpServiceAttribute(string name)
        {
            Name = name;
        }
            
        public string Name { get; set; }

    }

}
using System;

namespace TestStack.White.Modules
{
    [AttributeUsage(AttributeTargets.Class)]
    public class WhiteModuleAttribute : Attribute
    {
        private readonly string description;

        public WhiteModuleAttribute()
        {
            this.description = "";
        }

        public WhiteModuleAttribute(string Description)
        {
            this.description = Description;
        }

        public string Description
        {
            get { return description; }
        }
    }
}

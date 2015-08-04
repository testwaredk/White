using System;

namespace TestStack.White.Plugins
{
    [AttributeUsage(AttributeTargets.Class)]
    public class WhitePluginAttribute : Attribute
    {
        private readonly string description;

        public WhitePluginAttribute()
        {
            this.description = "";
        }

        public WhitePluginAttribute(string Description)
        {
            this.description = Description;
        }

        public string Description
        {
            get { return description; }
        }
    }
}

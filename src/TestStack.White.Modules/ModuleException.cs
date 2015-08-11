using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestStack.White.Modules
{
    public class ModuleException : Exception
    {
        public ModuleException(string message) : base(message)
        {
            
        }
    }
}

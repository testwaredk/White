using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestStack.White.Core.Mappings;

namespace TestStack.White.Plugins
{
    public abstract class PluginFacade
    {

        public abstract ControlDictionaryItems GetControlDictionaryItems();
        public abstract Type[] GetSupportedGenericControls();

        public virtual List<Type> GetEditableControls()
        {
            return new List<Type>();
        }

        public virtual object GetTestConfiguration()
        {
            throw new NotImplementedException();
        }

        public bool IsSupported(Type t)
        {
            return GetSupportedGenericControls().Any(m => m.Equals(t));
        }


    }
}

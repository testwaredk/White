using System;
using System.Collections.Generic;
using TestStack.White.Core.Mappings;

namespace TestStack.White.Plugins
{
    public interface IPluginFacade
    {
        ControlDictionaryItems GetControlDictionaryItems();

        List<Type> GetEditableControls();
    }
}

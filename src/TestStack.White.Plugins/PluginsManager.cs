using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using TestStack.White.Core.Mappings;

namespace TestStack.White.Plugins
{
    /// <summary>
    /// The plugins manager has the responsibility of checking whether there is any plugins available in the bin folder. It should read a config file and then read the assemblies contained.
    /// If there exists any plugins, then the plugin manager will publish a list of specialized UIItems classes, that must can be added to the ControlDictionary
    /// It also has the reponsiblity of listing all the white tests to be run agains the plugins uiitem classes.
    /// Therefore the plugin manager also publish the testconfiguration for the specific plugins.
    /// A list of plugins must also be published.
    /// </summary>
    public class PluginsManager
    {
        public static readonly PluginsManager Instance = new PluginsManager();

        public List<PluginFacade> LoadedPlugins { get;  private set; }

        bool isDictionaryLoaded = false;

        public PluginsManager()
        {
            List<Assembly> assemblies = LoadPlugInAssemblies();
            LoadedPlugins = GetPlugIns(assemblies);
        }

        private List<Assembly> LoadPlugInAssemblies()
        {
            DirectoryInfo dInfo = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "Plugins"));
            FileInfo[] files = dInfo.GetFiles("*.dll");

            List<Assembly> plugInAssemblyList = new List<Assembly>();

            if (null != files)
            {
                foreach (FileInfo file in files)
                {
                    plugInAssemblyList.Add(Assembly.LoadFile(file.FullName));
                }
            }
            return plugInAssemblyList;
        }


        private List<PluginFacade> GetPlugIns(List<Assembly> assemblies)
        {
            List<Type> availableTypes = new List<Type>();
            foreach (Assembly currentAssembly in assemblies)
            {
                availableTypes.AddRange(currentAssembly.GetTypes());
            }

            List<Type> facadeList = availableTypes.FindAll(t =>
            {
                List<Type> interfaceTypes = new List<Type>(t.GetInterfaces());

                object[] arr = t.GetCustomAttributes(typeof(WhitePluginAttribute), true);

                // the type returned need to first contain the WhitePluginAttribute and then be inherited from Facade
                return !(arr == null || arr.Length == 0) && t.BaseType.Equals(typeof(PluginFacade));
            });

            return facadeList.ConvertAll<PluginFacade>(t => Activator.CreateInstance(t) as PluginFacade);
        }

        /// <summary>
        /// This method should load all the plugins in the plugins directory and read the controldictionary from the plugins
        /// </summary>
        public void FillControlDictionary(ControlDictionary controlDictionaryInstance)
        {
            if (!isDictionaryLoaded)
            {
                foreach (PluginFacade plugin in LoadedPlugins)
                {
                    controlDictionaryInstance.AddControlDictionaryItems(plugin.ControlItems);
                    controlDictionaryInstance.AddEditableControls(plugin.EditableControls);
                }

                isDictionaryLoaded = true;
            }
        }

    }
}

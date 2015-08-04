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
        private static List<Assembly> LoadPlugInAssemblies()
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


        private static List<IPluginFacade> GetPlugIns(List<Assembly> assemblies)
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
                return !(arr == null || arr.Length == 0) && interfaceTypes.Contains(typeof(IPluginFacade));
            });

            return facadeList.ConvertAll<IPluginFacade>(t => Activator.CreateInstance(t) as IPluginFacade);
        }

        /// <summary>
        /// This method should load all the plugins in the plugins directory and read the controldictionary from the plugins
        /// </summary>
        public static void LoadPlugins(ControlDictionary controlDictionaryInstance)
        {
            List<Assembly> assemblies = LoadPlugInAssemblies();

            List<IPluginFacade> plugins = GetPlugIns(assemblies);

            foreach (IPluginFacade plugin in plugins)
            {
                controlDictionaryInstance.AddControlDictionaryItems(plugin.GetControlDictionaryItems());
            }
        }

    }
}

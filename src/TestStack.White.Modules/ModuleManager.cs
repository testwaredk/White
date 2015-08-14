using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using TestStack.White.Core.Mappings;
using TestStack.White.Configuration;
using System.Text.RegularExpressions;
using Castle.Core.Logging;

namespace TestStack.White.Modules
{
    /// <summary>
    /// The plugins manager has the responsibility of checking whether there is any plugins available in the bin folder. It should read a config file and then read the assemblies contained.
    /// If there exists any plugins, then the plugin manager will publish a list of specialized UIItems classes, that must can be added to the ControlDictionary
    /// It also has the reponsiblity of listing all the white tests to be run agains the plugins uiitem classes.
    /// Therefore the plugin manager also publish the testconfiguration for the specific plugins.
    /// A list of plugins must also be published.
    /// </summary>
    public class ModulesManager
    {
        private static readonly ILogger Logger = CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof(ModulesManager));

        public List<ModuleFacade> LoadedModules { get;  private set; }

        bool isDictionaryLoaded = false;

        public ModulesManager () { }

        public static ModulesManager Create()
        {
            ModulesManager manager = new ModulesManager();
            List<Assembly> assemblies = manager.LoadModuleAssemblies();
            manager.LoadedModules = manager.GetModules(assemblies);
            manager.FillControlDictionary(ControlDictionary.Instance);
            return manager;
        }

        private List<Assembly> LoadModuleAssemblies()
        {
            DirectoryInfo dInfo = new DirectoryInfo(Environment.CurrentDirectory);
            if (!dInfo.Exists) dInfo.Create();

            FileInfo[] files = dInfo.GetFiles("*.dll");

            List<Assembly> moduleAssemblyList = new List<Assembly>();

            if (null != files)
            {
                foreach (FileInfo file in files)
                {
                    string pattern = @"\w+\.White\.Modules\.\w+\.dll";
                    if (Regex.IsMatch(file.Name, pattern))
                    {
                        moduleAssemblyList.Add(Assembly.LoadFile(file.FullName));
                        Logger.Info("Loaded assembly " + file.FullName);
                    }
                }
            }
            return moduleAssemblyList;
        }


        private List<ModuleFacade> GetModules(List<Assembly> assemblies)
        {
            List<Type> availableTypes = new List<Type>();
            foreach (Assembly currentAssembly in assemblies)
            {
                availableTypes.AddRange(currentAssembly.GetTypes());
            }

            List<Type> facadeList = availableTypes.FindAll(t =>
            {
                List<Type> interfaceTypes = new List<Type>(t.GetInterfaces());

                object[] arr = t.GetCustomAttributes(typeof(WhiteModuleAttribute), true);

                // the type returned need to first contain the WhitePluginAttribute and then be inherited from Facade
                return !(arr == null || arr.Length == 0) && t.BaseType.Equals(typeof(ModuleFacade));
            });

            return facadeList.ConvertAll<ModuleFacade>(t => Activator.CreateInstance(t) as ModuleFacade);
        }

        /// <summary>
        /// This method should load all the plugins in the plugins directory and read the controldictionary from the plugins
        /// </summary>
        public void FillControlDictionary(ControlDictionary controlDictionaryInstance)
        {
            if (!isDictionaryLoaded)
            {
                foreach (ModuleFacade module in LoadedModules)
                {
                    controlDictionaryInstance.AddControlDictionaryItems(module.ControlItems);
                    controlDictionaryInstance.AddEditableControls(module.EditableControls);
                }

                isDictionaryLoaded = true;
            }
        }

    }
}

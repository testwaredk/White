using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;


namespace TestStack.White.Core.Mappings
{
    public class ControlDictionary
    {
        public static readonly ControlDictionary Instance = new ControlDictionary();
        private readonly ControlDictionaryItems items = new ControlDictionaryItems();
        private readonly List<Type> editableControls = new List<Type>();

        private ControlDictionary()
        {

        }

        public virtual void AddControlDictionaryItems(ControlDictionaryItems controlItems)
        {
            foreach (ControlDictionaryItem item in controlItems)
            {
                // add only unique items
                if (!this.items.Any(t => t.GetHashCode().Equals(item.GetHashCode())))
                {
                    this.items.Add(item);
                }
            }
        }

        public virtual void AddEditableControls(List<Type> editableControls)
        {
            this.editableControls.AddRange(editableControls);
        }

        public virtual bool HasPrimaryChildren(ControlType controlType)
        {
            if (controlType.Equals(ControlType.Custom)) return true;
            var results = items.FindBy(controlType).ToArray();
            if (!results.Any()) throw new ControlDictionaryException("Could not find control of type " + controlType.LocalizedControlType);
            return results.Any(i => i.HasPrimaryChildren);
        }

        public virtual ControlType[] GetControlType(Type testControlType, string frameworkId)
        {
            var controlDictionaryItem = items.FindBy(testControlType, frameworkId);
            if (controlDictionaryItem == null)
                throw new WhiteException(string.Format("Cannot find {0} for {1}", testControlType.Name, frameworkId));
            return controlDictionaryItem.Select(c => c.ControlType).ToArray();
        }

        public virtual Type GetTestControlType(string className, string name, ControlType controlType, string frameWorkId, bool isNativeControl)
        {
            if (Equals(controlType, ControlType.ListItem) && string.IsNullOrEmpty(frameWorkId))
                frameWorkId = WindowsFramework.Win32.FrameworkId();

            var dictionaryItems = items.Where(controlDictionaryItem =>
            {
                if (!ControlTypeMatches(controlType, controlDictionaryItem)) return false;
                if (!FrameworkIdMatches(frameWorkId, controlDictionaryItem)) return false;
                if (controlDictionaryItem.IsIdentifiedByClassName && !className.Contains(controlDictionaryItem.ClassName))
                    return false;
                if (controlDictionaryItem.IsIdentifiedByName && controlDictionaryItem.TestControlType.Name != name)
                    return false;

                return true;
            })
            .ToArray();
            if (!dictionaryItems.Any())
            {
                throw new ControlDictionaryException(string.Format("Could not find TestControl for ControlType={0} and FrameworkId:{1}",
                                                                   controlType.LocalizedControlType, frameWorkId));
            }
            if (dictionaryItems.Length > 1)
            {
                var primaries = dictionaryItems.Where(i => IsPrimaryControl(i.ControlType, className, name)).ToArray();
                if (primaries.Length == 1)
                    return primaries.Single().TestControlType;

                var identifiedByName = dictionaryItems.Where(i => i.IsIdentifiedByName).ToArray();
                if (identifiedByName.Length == 1)
                    return identifiedByName.Single().TestControlType;
                var identifiedByClassName = dictionaryItems.Where(i => i.IsIdentifiedByClassName).ToArray();
                if (identifiedByClassName.Length == 1)
                    return identifiedByClassName.Single().TestControlType;
                var isPrimary = dictionaryItems.Where(i => i.IsPrimary).ToArray();
                if (isPrimary.Length == 1)
                    return isPrimary.Single().TestControlType;

                throw new ControlDictionaryException(string.Format(
                   "Multiple TestControls found for ControlType={0} and FrameworkId:{1} - {2}",
                   controlType.LocalizedControlType, frameWorkId,
                   string.Join(", ", dictionaryItems.Select(d => d.TestControlType == null ? "null" : d.TestControlType.FullName))));

            }
            return dictionaryItems.Single().TestControlType;
        }

        private static bool ControlTypeMatches(ControlType controlType, ControlDictionaryItem controlDictionaryItem)
        {
            return controlDictionaryItem.ControlType.Equals(controlType);
        }

        private static bool FrameworkIdMatches(string frameWorkId, ControlDictionaryItem controlDictionaryItem)
        {
            return string.IsNullOrEmpty(frameWorkId) ||
                controlDictionaryItem.FrameworkId == frameWorkId ||
                string.IsNullOrEmpty(controlDictionaryItem.FrameworkId);
        }

        public virtual bool IsPrimaryControl(ControlType controlType, string className, string name)
        {
            return items.Exists(controlDictionaryItem =>
            {
                bool isPrimaryMatching = controlDictionaryItem.IsPrimary && ControlTypeMatches(controlType, controlDictionaryItem) && !controlDictionaryItem.IsIdentifiedByClassName && !controlDictionaryItem.IsIdentifiedByName;
                bool identifiedByClassNameMatches = !string.IsNullOrWhiteSpace(className) && className.Contains(controlDictionaryItem.ClassName) && controlDictionaryItem.IsIdentifiedByClassName;
                bool identifiedByNameMatches = !string.IsNullOrWhiteSpace(name) && controlDictionaryItem.TestControlType != null && name.Equals(controlDictionaryItem.TestControlType.Name) && controlDictionaryItem.IsIdentifiedByName;
                return isPrimaryMatching || identifiedByClassNameMatches || identifiedByNameMatches;
            });
        }

        public virtual bool IsExcluded(ControlType controlType)
        {
            return items.Exists(controlDictionaryItem => controlDictionaryItem.ControlType.Equals(controlType) && controlDictionaryItem.IsExcluded);
        }

        public virtual bool IsControlTypeSupported(ControlType controlType)
        {
            return items.Any(controlDictionaryItem => controlDictionaryItem.ControlType.Equals(controlType));
        }

        public virtual List<ControlType> PrimaryControlTypes(string frameworkId)
        {
            var controlTypes = new List<ControlType>();
            foreach (ControlDictionaryItem controlDictionaryItem in items)
            {
                if (controlDictionaryItem.OfFramework(frameworkId) && controlDictionaryItem.IsPrimary &&
                    !controlTypes.Contains(controlDictionaryItem.ControlType))
                    controlTypes.Add(controlDictionaryItem.ControlType);
            }
            return controlTypes;
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>object was UIItem</remarks>
        /// <param name="uiItem"></param>
        /// <returns></returns>
        public virtual bool IsEditable(object uiItem)
        {
            return editableControls.All(t => t.IsInstanceOfType(uiItem));
        }
        

        public virtual Type GetTestControlType(AutomationElement automationElement)
        {
            AutomationElement.AutomationElementInformation current = automationElement.Current;
            return GetTestControlType(current.ClassName, current.Name, current.ControlType, current.FrameworkId, current.NativeWindowHandle != 0);
        }
    }
}

using System;
using System.Windows.Automation;
using TestStack.White.Core.Security;

namespace TestStack.White.Core.Mappings
{
    public class ControlDictionaryItem
    {
        private readonly Type testControlType;
        private readonly ControlType controlType;
        private readonly string className;
        private readonly bool identifiedByClassName;
        private readonly bool isPrimary;
        private readonly bool isExcluded;
        private readonly string frameworkId;
        private readonly bool hasPrimaryChildren;

        public ControlDictionaryItem(Type testControlType, ControlType controlType, string className, bool identifiedByClassName, bool isPrimary,
                                     bool isExcluded, string frameworkId, bool hasPrimaryChildren)
        {
            this.testControlType = testControlType;
            this.controlType = controlType;
            this.className = className;
            this.identifiedByClassName = identifiedByClassName;
            this.isPrimary = isPrimary;
            this.isExcluded = isExcluded;
            this.frameworkId = frameworkId;
            this.hasPrimaryChildren = hasPrimaryChildren;
        }

        public override int GetHashCode()
        {
            int[] ints = new int[] { 
                Cryptography.GetMD5Hash(this.testControlType == null ? "" : this.testControlType.Name),
                Cryptography.GetMD5Hash(this.controlType.ProgrammaticName),
                Cryptography.GetMD5Hash(this.className),
                this.identifiedByClassName ? 1 : 0,
                this.isPrimary ? 1 : 0,
                this.isExcluded ? 1 : 0,
                Cryptography.GetMD5Hash(this.frameworkId == null ? "" : this.frameworkId),
                this.hasPrimaryChildren ? 1 : 0
            };
            return Cryptography.GetMD5Hash(ints);
            
        }

        public static ControlDictionaryItem Primary(Type testControlType, ControlType controlType)
        {
            return new ControlDictionaryItem(testControlType, controlType, string.Empty, false, true, false, null, false);
        }

        public static ControlDictionaryItem Primary(Type testControlType, ControlType controlType, bool hasPrimaryChildren)
        {
            return new ControlDictionaryItem(testControlType, controlType, string.Empty, false, true, false, null, hasPrimaryChildren);
        }

        private static ControlDictionaryItem Primary(Type testControlType, ControlType controlType, string frameworkId)
        {
            return new ControlDictionaryItem(testControlType, controlType, string.Empty, false, true, false, frameworkId, false);
        }
        private static ControlDictionaryItem Primary(Type testControlType, ControlType controlType, string frameworkId, bool hasPrimaryChildren)
        {
            return new ControlDictionaryItem(testControlType, controlType, string.Empty, false, true, false, frameworkId, hasPrimaryChildren);
        }

        public static ControlDictionaryItem WinFormPrimary(Type testControlType, ControlType controlType)
        {
            return Primary(testControlType, controlType, WindowsFramework.WinForms.FrameworkId());
        }
        public static ControlDictionaryItem WinFormPrimary(Type testControlType, ControlType controlType, bool hasPrimaryChildren)
        {
            return Primary(testControlType, controlType, WindowsFramework.WinForms.FrameworkId(), hasPrimaryChildren);
        }

        public static ControlDictionaryItem WPFPrimary(Type testControlType, ControlType controlType)
        {
            return Primary(testControlType, controlType, WindowsFramework.Wpf.FrameworkId());
        }

        public static ControlDictionaryItem WPFPrimary(Type testControlType, ControlType controlType, bool hasPrimaryChildren)
        {
            return Primary(testControlType, controlType, WindowsFramework.Wpf.FrameworkId(), hasPrimaryChildren);
        }

        public static ControlDictionaryItem Win32Primary(Type testControlType, ControlType controlType)
        {
            return Primary(testControlType, controlType, WindowsFramework.Win32.FrameworkId());
        }

        public static ControlDictionaryItem SilverlightPrimary(Type testControlType, ControlType controlType)
        {
            return Primary(testControlType, controlType, WindowsFramework.Silverlight.FrameworkId());
        }
        public static ControlDictionaryItem SilverlightPrimary(Type testControlType, ControlType controlType, bool hasPrimaryChildren)
        {
            return Primary(testControlType, controlType, WindowsFramework.Silverlight.FrameworkId(), hasPrimaryChildren);
        }

        private static ControlDictionaryItem Secondary(Type testControlType, ControlType controlType, string frameworkId)
        {
            return new ControlDictionaryItem(testControlType, controlType, string.Empty, false, false, false, frameworkId, false);
        }

        private static ControlDictionaryItem Secondary(Type testControlType, ControlType controlType, string frameworkId, bool hasPrimaryChildren)
        {
            return new ControlDictionaryItem(testControlType, controlType, string.Empty, false, false, false, frameworkId, hasPrimaryChildren);
        }

        public static ControlDictionaryItem Secondary(Type testControlType, ControlType controlType)
        {
            return new ControlDictionaryItem(testControlType, controlType, string.Empty, false, false, false, null, false);
        }

        public static ControlDictionaryItem Secondary(Type testControlType, ControlType controlType, bool hasPrimaryChildren)
        {
            return new ControlDictionaryItem(testControlType, controlType, string.Empty, false, false, false, null, hasPrimaryChildren);
        }

        public static ControlDictionaryItem WinFormSecondary(Type testControlType, ControlType controlType)
        {
            return Secondary(testControlType, controlType, WindowsFramework.WinForms.FrameworkId());
        }
        public static ControlDictionaryItem WinFormSecondary(Type testControlType, ControlType controlType, bool hasPrimaryChildren)
        {
            return Secondary(testControlType, controlType, WindowsFramework.WinForms.FrameworkId(), hasPrimaryChildren);
        }

        public static ControlDictionaryItem Win32Secondary(Type testControlType, ControlType controlType)
        {
            return Secondary(testControlType, controlType, WindowsFramework.Win32.FrameworkId());
        }

        public static ControlDictionaryItem WPFSecondary(Type testControlType, ControlType controlType)
        {
            return Secondary(testControlType, controlType, WindowsFramework.Wpf.FrameworkId());
        }
        public static ControlDictionaryItem WPFSecondary(Type testControlType, ControlType controlType, bool hasPrimaryChildren)
        {
            return Secondary(testControlType, controlType, WindowsFramework.Wpf.FrameworkId(), hasPrimaryChildren);
        }

        public static ControlDictionaryItem SilverlightSecondary(Type testControlType, ControlType controlType)
        {
            return Secondary(testControlType, controlType, WindowsFramework.Silverlight.FrameworkId());
        }

        public virtual bool IsPrimary
        {
            get { return isPrimary; }
        }

        public virtual Type TestControlType
        {
            get { return testControlType; }
        }

        public virtual string FrameworkId
        {
            get { return frameworkId; }
        }

        public virtual ControlType ControlType
        {
            get { return controlType; }
        }

        public virtual string ClassName
        {
            get { return className; }
        }

        public virtual bool IsExcluded
        {
            get { return isExcluded; }
        }

        public virtual bool IsIdentifiedByClassName
        {
            get { return identifiedByClassName; }
        }

        public virtual bool HasPrimaryChildren
        {
            get { return hasPrimaryChildren; }
        }

        public virtual bool OfFramework(string id)
        {
            //TODO id.Equals(id) will always return true.. figure out what this is doing
            return string.IsNullOrEmpty(id) || id.Equals(id);
        }

        public virtual bool IsIdentifiedByName { set; get; }

        public override string ToString()
        {
            return
                string.Format(
                    "TestControlType: {0}, ControlType: {1}, ClassName: {2}, IdentifiedByClassName: {3}, IsPrimary: {4}, IsExcluded: {5}, FrameworkId: {6}, HasPrimaryChildren: {7}, IsIdentifiedByName: {8}",
                    testControlType.Name, controlType.LocalizedControlType, className, identifiedByClassName, isPrimary, isExcluded, frameworkId, hasPrimaryChildren,
                    IsIdentifiedByName);
        }
    }
}
using TestStack.White.Core;
using TestStack.White.UIItems;
using TestStack.White.Modules;

namespace TestStack.White.Modules.WinForm
{
    public class WinformsTestConfiguration : WindowsConfiguration
    {
        public WinformsTestConfiguration()
            : base(WindowsFramework.WinForms)
        {
        }

        protected override string ApplicationExePath()
        {
            return "WindowsFormsTestApplication.exe";
        }
    }
}
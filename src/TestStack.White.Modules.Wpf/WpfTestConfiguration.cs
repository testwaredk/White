using TestStack.White.Core;
using TestStack.White.UIItems;
using TestStack.White.Modules;

namespace TestStack.White.Modules.Wpf
{
    public class WpfTestConfiguration : WindowsConfiguration
    {
        public WpfTestConfiguration()
            : base(WindowsFramework.Wpf)
        {
        }

        protected override string ApplicationExePath()
        {
            return "WpfTestApplication.exe";
        }
    }
}
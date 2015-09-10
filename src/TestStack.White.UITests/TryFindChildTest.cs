using System;
using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White.Configuration;
using TestStack.White.Core.Mappings;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TabItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.Utility;
using TestStack.White.Core;
using Xunit;

namespace TestStack.White.UITests
{
    public class TryFindChildTest : WhiteTestBase
    {
        void DetectTextBoxAndTryGetIt()
        {

            UIItemContainer inputControls = MainScreen.GetInputControls();

            IUIItem uiItem; 
            Assert.True(inputControls.TryGet<TextBox>("TextBox", out uiItem));

            TextBox textBox = (TextBox)uiItem;
            Assert.Equal(textBox.Id, "TextBox");
            textBox.Text = "TryGetWasHere";



            Assert.Equal("TryGetWasHere", textBox.Text);
        }

        void TryGetSomeNonExistingStuff()
        {
            UIItemContainer inputControls = MainScreen.GetInputControls();
            IUIItem uiItem;
            Assert.False(inputControls.TryGet<TextBox>("DosntExist", new TimeSpan(1000), out uiItem));
            Assert.Null(uiItem);
        }

        protected override void ExecuteTestRun()
        {
            SelectInputControls();
            RunTest(DetectTextBoxAndTryGetIt);
            RunTest(TryGetSomeNonExistingStuff);
        }


        protected override IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.Windows.MessageBoxRequirement);
        }

    }

}
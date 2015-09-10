using System;
using System.Collections.Generic;
using TestStack.White.Configuration;
using TestStack.White.UIItems;
using TestStack.White.Core;
using Castle.Core.Logging;
using Xunit;

namespace TestStack.White.UITests
{
    public class TryFindChildTest : WhiteTestBase
    {
        ILogger logger = CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof(TryFindChildTest));
        void DetectTextBoxAndTryGetIt()
        {
            UIItemContainer inputControls = MainScreen.GetInputControls();

            TextBox textBox; 
            Assert.True(inputControls.TryGet<TextBox>("TextBox", out textBox));

            Assert.Equal(textBox.Id, "TextBox");
            textBox.Text = "TryGetWasHere";
            Assert.Equal("TryGetWasHere", textBox.Text);
        }

        void ShouldSpendAllWaitingTimeSearchingForUnexistingItem()
        {
            UIItemContainer inputControls = MainScreen.GetInputControls();
            TextBox uiItem;
            
            long wait = new TimeSpan(0,0,5).Ticks;
            long shouldEndAt = DateTime.Now.Ticks + wait;
            
            Assert.False(inputControls.TryGet<TextBox>("DosntExist", new TimeSpan(wait), out uiItem));
            long finishedAt = DateTime.Now.Ticks;
            
            Assert.True(shouldEndAt <= finishedAt);
            Assert.Null(uiItem);
        }

        protected override void ExecuteTestRun()
        {
            SelectInputControls();
            RunTest(DetectTextBoxAndTryGetIt);
            RunTest(ShouldSpendAllWaitingTimeSearchingForUnexistingItem);
        }


        protected override IEnumerable<Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.Windows.MessageBoxRequirement);
        }

    }

}
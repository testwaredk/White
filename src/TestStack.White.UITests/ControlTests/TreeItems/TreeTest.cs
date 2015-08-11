using System.Collections.Generic;
using TestStack.White.Core;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TreeItems;
using Xunit;
using System.Text.RegularExpressions;

namespace TestStack.White.UITests.ControlTests.TreeItems
{
    public class TreeTest : WhiteTestBase
    {
        Tree tree;

        protected override void ExecuteTestRun()
        {
            SelectOtherControls();
            tree = MainWindow.Get<Tree>("TreeView");

            RunTest(Nodes);
            RunTest(FindNode);
            RunTest(SelectNodeWhichNeedsScrolling);
            RunTest(SelectNode);
            RunTest(DynamicallyAddedNodeCanBeFound);
            RunTest(GetPathTo);
            RunTest(GetClickedNodePathForGrandChild);
            RunTest(GetClickedNodePathForRoot);
            RunTest(ScrollAndSelect);
        }

        void Nodes()
        {
            Assert.True(tree.Nodes.Count >= 2);
        }

        void FindNode()
        {
            Assert.True(tree.HasNode("Root"));
            Assert.False(tree.HasNode("Roo"));
            Assert.True(tree.HasNode("Main"));
            Assert.True(tree.HasNode("Root", "Child"));
            Assert.True(tree.HasNode("Root", "Child", "Grand Child"));
            var exception = Assert.Throws<AutomationException>(() => tree.HasNode("Root", "Child", "Grand Child", "Grand Child"));

            string expected = 
                @"Cannot expand TreeNode \w+TreeNode. AutomationId:, Name:Grand Child, " +
                @"ControlType:tree view item, FrameworkId:\w+, expand button not visible";
            Assert.True(Regex.IsMatch(exception.Message, expected));
        }

        void SelectNodeWhichNeedsScrolling()
        {
            tree.Node("Root").Select();
            Assert.Equal("Root", tree.SelectedNode.Text);
            tree.Node("Main").Select();
            Assert.Equal("Main", tree.SelectedNode.Text);
            tree.Node("Root").Select();
            Assert.Equal("Root", tree.SelectedNode.Text);
            tree.Node("Main").Select();
            Assert.Equal("Main", tree.SelectedNode.Text);
        }

        void SelectNode()
        {
            TreeNode treeNode = tree.Node("Root", "Child");
            treeNode.Select();
            Assert.Equal("Child", tree.SelectedNode.Name);
        }

        void DynamicallyAddedNodeCanBeFound()
        {
            MainWindow.Get<Button>("AddNode").Click();
            Assert.True(tree.HasNode("AddedNode"));
        }

        void GetPathTo()
        {
            TreeNode treeNode = tree.Node("Root", "Child");
            List<TreeNode> path = tree.GetPathTo(treeNode);
            Assert.Equal(2, path.Count);
        }

        void GetClickedNodePathForGrandChild()
        {
            TreeNode treeNode = tree.Node("Root", "Child", "Grand Child");
            List<TreeNode> path = tree.GetPathTo(treeNode);
            Assert.Equal(3, path.Count);
        }

        void GetClickedNodePathForRoot()
        {
            TreeNode treeNode = tree.Node("Root");
            List<TreeNode> path = tree.GetPathTo(treeNode);
            Assert.Equal(1, path.Count);
        }

        void ScrollAndSelect()
        {
            TreeNode treeNode = tree.Node("Lots Of Children", "Child40");
            Assert.NotNull(treeNode);
            treeNode.Select();
            Assert.Equal(treeNode, tree.SelectedNode);
        }

        protected override IEnumerable<System.Type> CoveredRequirements()
        {
            yield return typeof(Core.Requirements.TreeItems.TreeRequirement);
        }
    }
}
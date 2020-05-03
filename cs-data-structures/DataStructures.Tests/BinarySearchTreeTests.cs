using FluentAssertions;
using Xunit;

namespace DataStructures.Tests
{
    public class BinarySearchTreeTests
    {
        [Fact]
        public void Add_SetsRoot_WhenTreeIsEmpty()
        {
            //arrange
            const int rootValue = 1;
            var bst = new BinarySearchTree<int>();
            //act
            bst.Add(rootValue);
            //assert
            bst.RootNode.Should().NotBeNull();
            bst.RootNode.Value.Should().Be(rootValue);
        }

        [Fact]
        public void Add_SetsLeftChild_WhenNewElement_IsLesserThanRoot()
        {
            //arrange
            const int leftValue = 5;
            var bst = new BinarySearchTree<int>();
            //act
            bst.Add(10);
            bst.Add(leftValue);
            //assert
            bst.RootNode.Left.Should().NotBeNull();
            bst.RootNode.Left.Value.Should().Be(leftValue);
        }

        [Fact]
        public void Add_SetsRightChild_WhenNewElement_IsGreaterThanRoot()
        {
            //arrange
            const int rightValue = 12;
            var bst = new BinarySearchTree<int>();
            //act
            bst.Add(10);
            bst.Add(rightValue);
            //assert
            bst.RootNode.Right.Should().NotBeNull();
            bst.RootNode.Right.Value.Should().Be(rightValue);
        }

        [Fact]
        public void Remove_SetsRootNodeNull_WhenTreeConsistsOfOneElement()
        {
            //arrange
            var bst = new BinarySearchTree<int>();
            bst.Add(1);
            //act
            bst.Remove(1);
            //assert
            bst.RootNode.Should().BeNull();
        }

        [Fact]
        public void Remove_ForNotEmptyTree_Works()
        {
            //arrange
            var bst = new BinarySearchTree<int>();
            bst.Add(7);
            bst.Add(2);
            bst.Add(12);
            bst.Add(11);
            bst.Add(1);
            bst.Add(6);
            //act
            bst.Remove(7);
            //assert
            bst.RootNode.Should().NotBeNull();
            bst.RootNode.Left.Should().NotBeNull();
            bst.RootNode.Right.Should().NotBeNull();
            bst.NodesCount.Should().Be(5);
        }
    }
}

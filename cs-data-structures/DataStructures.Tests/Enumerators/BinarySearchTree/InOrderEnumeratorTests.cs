using System;
using DataStructures.Enumerators.BinarySearchTree;
using FluentAssertions;
using Xunit;

namespace DataStructures.Tests.Enumerators.BinarySearchTree
{
    public class InOrderEnumeratorTests : BaseTreeEnumeratorTests
    {
        [Fact]
        public void Current_IfNotMovedYet_ThrowsException()
        {
            //arrange
            var bst = GetTreeWithElements();
            var iterator = new InOrderEnumerator<int>(bst.RootNode);
            //act
            Action act = () => { var cur = iterator.Current; };
            //assert
            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Current_IfAlreadyMoved_Works()
        {
            //arrange
            var bst = GetTreeWithElements();
            var iterator = new InOrderEnumerator<int>(bst.RootNode);
            //act
            iterator.MoveNext();
            var result = iterator.Current;
            //assert
            result.Value.Should().Be(1);
        }

        [Fact]
        public void MoveNext_ReturnsNodes_InRightOrder()
        {
            //arrange
            var bst = GetTreeWithElements();
            var iterator = new InOrderEnumerator<int>(bst.RootNode);
            //act
            iterator.MoveNext();
            var previous = iterator.Current;
            //assert
            while(iterator.MoveNext()) {
                var current = iterator.Current;
                current.Value.Should().BeGreaterOrEqualTo(previous.Value);
                previous = current;
            }
        }
    }
}

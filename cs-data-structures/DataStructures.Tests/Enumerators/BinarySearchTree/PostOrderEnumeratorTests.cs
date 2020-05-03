using DataStructures.Enumerators.BinarySearchTree;
using FluentAssertions;
using Xunit;

namespace DataStructures.Tests.Enumerators.BinarySearchTree
{
    public class PostOrderEnumeratorTests : BaseTreeEnumeratorTests
    {
        [Fact]
        public void MoveNext_ReturnsNodes_InRightOrder()
        {
            //arrange
            var bst = GetTreeWithElements();
            var iterator = new PostOrderEnumerator<int>(bst.RootNode);
            //act+assert
            var i = 0;
            while(iterator.MoveNext()) {
                var current = iterator.Current;
                current.Value.Should().Be(PostOrderedElements[i]);
                ++i;
            }
        }
    }
}

using System;
using FluentAssertions;
using Xunit;

namespace DataStructures.Tests
{
    public class UnionFindTests
    {
        [Fact]
        public void Constructor_ForGoodParameter_SetsFields()
        {
            //arrange
            const int length = 5;
            //act
            var uf = new UnionFind(length);
            //assert
            uf.ComponentsCount.Should().Be(length);
            uf.InitialComponentsCount.Should().Be(length);
        }

        [Fact]
        public void Constructor_ForBadParameter_ThrowsException()
        {
            //arrange
            const int length = 0;
            //act
            Action act = () => { var uf = new UnionFind(length); };
            //assert
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Find_ForExistingIndex_WhenUnionWasntChanged_ReturnsTheIndexItself()
        {
            //arrange
            const int length = 5;
            const int element = 4;
            var uf = new UnionFind(length);
            //act
            var result = uf.Find(element);
            //assert
            result.Should().Be(element);
        }

        [Fact]
        public void Find_ForExistingIndex_WhenAlreadyUnified_ReturnsIndexDifferentThanValueOfElement()
        {
            //arrange
            const int length = 5;
            const int element = 4;
            var uf = new UnionFind(length);
            uf.Unify(3, element);
            //act
            var result = uf.Find(element);
            //assert
            result.Should().NotBe(element);
        }

        [Fact]
        public void Find_ForNotExistingIndex_ShoudThrowException()
        {
            //arrange
            const int length = 5;
            var uf = new UnionFind(length);
            //act
            Action act = () => { uf.Find(length); };
            //assert
            act.Should().Throw<IndexOutOfRangeException>();
        }

        [Fact]
        public void Unify_ForGoodParameters_ChangesComponentsButNotLength()
        {
            //arrange
            const int length = 5;
            var uf = new UnionFind(length);
            //act
            uf.Unify(3, 4);
            //assert
            uf.ComponentsCount.Should().Be(4);
            uf.InitialComponentsCount.Should().Be(length);
        }

        [Fact]
        public void Unify_ForGoodParameters_ChangesParentIndex()
        {
            //arrange
            const int length = 5;
            const int element = 4;
            var uf = new UnionFind(length);
            var parentBefore = uf.Find(element);
            //act
            uf.Unify(3, 4);
            var result = uf.Find(element);
            //assert
            parentBefore.Should().Be(element);
            result.Should().NotBe(element);
        }

        [Fact]
        public void Unify_ForNotExistingIndicies_ShoudThrowException()
        {
            //arrange
            const int length = 5;
            var uf = new UnionFind(length);
            //act
            Action act = () => { uf.Unify(5, 6); };
            //assert
            act.Should().Throw<IndexOutOfRangeException>();
        }
    }
}

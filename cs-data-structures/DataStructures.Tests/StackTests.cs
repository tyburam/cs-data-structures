using System;
using FluentAssertions;
using Xunit;

namespace DataStructures.Tests
{
    public class StackTests
    {
        [Fact]
        public void Push_ChangesLength()
        {
            //arrange
            var da = new Stack<int>();
            //act
            da.Push(1);
            //assert
            da.Length.Should().Be(1);
        }

        [Fact]
        public void Peek_ForEmptyStack_ThrowsIndexOutOfRangeException()
        {
            //arrange
            var da = new Stack<int>();
            //act
            Action act = () => {da.Peek(); };
            //assert
            act.Should().Throw<IndexOutOfRangeException>();
        }

        [Fact]
        public void Peek_ForNotEmptyStack_ReturnsTheLastValue()
        {
            //arrange
            const int lastElement = 2;
            var da = new Stack<int>();
            da.Push(1);
            da.Push(lastElement);
            //act
            var result = da.Peek();
            //assert
            result.Should().Be(lastElement);
        }

        [Fact]
        public void Pop_ForEmptyStack_ThrowsIndexOutOfRangeException()
        {
            //arrange
            var da = new Stack<int>();
            //act
            Action act = () => {da.Pop(); };
            //assert
            act.Should().Throw<IndexOutOfRangeException>();
        }

        [Fact]
        public void Pop_ForNonEmptyStack_ReturnsFirstElementAndChangesLength()
        {
            //arrange
            const int lastElement = 3;
            var da = new Stack<int>();
            da.Push(1);
            da.Push(2);
            da.Push(lastElement);
            //act
            var value = da.Pop();
            //assert
            da.Length.Should().Be(2);
            value.Should().Be(lastElement);
        }
    }
}

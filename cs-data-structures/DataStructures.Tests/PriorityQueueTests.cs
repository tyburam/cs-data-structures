using System;
using FluentAssertions;
using Xunit;

namespace DataStructures.Tests
{
    public class PriorityQueueTests
    {
        [Fact]
        public void Enqueue_ChangesLength()
        {
            //arrange
            var da = new PriorityQueue<int>();
            //act
            da.Enqueue(1);
            //assert
            da.Length.Should().Be(1);
        }

        [Fact]
        public void Peek_ForEmptyQueue_ThrowsIndexOutOfRangeException()
        {
            //arrange
            var da = new PriorityQueue<int>();
            //act
            Action act = () => {da.Peek(); };
            //assert
            act.Should().Throw<IndexOutOfRangeException>();
        }

        [Fact]
        public void Peek_ForNotEmptyQueue_ReturnsTheFirstValue()
        {
            //arrange
            const int firstElement = 1;
            var da = new PriorityQueue<int>();
            da.Enqueue(firstElement);
            da.Enqueue(2);
            //act
            var result = da.Peek();
            //assert
            result.Should().Be(firstElement);
        }

        [Fact]
        public void Dequeue_ForEmptyQueue_ThrowsIndexOutOfRangeException()
        {
            //arrange
            var da = new PriorityQueue<int>();
            //act
            Action act = () => {da.Dequeue(); };
            //assert
            act.Should().Throw<IndexOutOfRangeException>();
        }

        [Fact]
        public void Dequeue_ForNonEmptyQueue_ReturnsFirstElementAndChangesLength()
        {
            //arrange
            const int firstElement = 1;
            var da = new PriorityQueue<int>();
            da.Enqueue(3);
            da.Enqueue(2);
            da.Enqueue(firstElement);
            //act
            var value = da.Dequeue();
            //assert
            da.Length.Should().Be(2);
            value.Should().Be(firstElement);
        }
    }
}

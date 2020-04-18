using System;
using FluentAssertions;
using Xunit;

namespace DataStructures.Tests
{
    public class LinkedListTests
    {
        [Fact]
        public void GetAt_ForEmptyList_ThrowsIndexOutOfRangeException()
        {
            //arrange
            var da = new LinkedList<int>();
            //act
            Action act = () => {da.GetAt(0); };
            //assert
            act.Should().Throw<IndexOutOfRangeException>();
        }

        [Fact]
        public void GetAt_ForIndexLowerThanZero_ThrowsIndexOutOfRangeException()
        {
            //arrange
            var da = new LinkedList<int>();
            da.Add(1);
            //act
            Action act = () => {da.GetAt(-1); };
            //assert
            act.Should().Throw<IndexOutOfRangeException>();
        }

        [Fact]
        public void GetAt_ForIndexEqualLength_ThrowsIndexOutOfRangeException()
        {
            //arrange
            var da = new LinkedList<int>();
            da.Add(1);
            //act
            Action act = () => {da.GetAt(da.Length); };
            //assert
            act.Should().Throw<IndexOutOfRangeException>();
        }

        [Fact]
        public void GetAt_ForIndexGreaterThanLength_ThrowsIndexOutOfRangeException()
        {
            //arrange
            var da = new LinkedList<int>();
            da.Add(1);
            //act
            Action act = () => {da.GetAt(da.Length+1); };
            //assert
            act.Should().Throw<IndexOutOfRangeException>();
        }

        [Fact]
        public void Add_ChangesLengthAndAddsElement()
        {
            //arrange
            const int element = 1;
            var da = new LinkedList<int>();
            //act
            da.Add(element);
            //assert
            da.Length.Should().Be(1);
            da.GetAt(0).Should().Be(element);
        }

        [Fact]
        public void InsertAt_ForIndexLowerThanZero_ThrowsIndexOutOfRangeException()
        {
            //arrange
            var da = new LinkedList<int>();
            //act
            Action act = () => {da.InsertAt(1, -1); };
            //assert
            act.Should().Throw<IndexOutOfRangeException>();
        }

        [Fact]
        public void InsertAt_WithIndex0_ChangesLengthAndAddsElement()
        {
            //arrange
            const int element = 1;
            var da = new LinkedList<int>();
            //act
            da.InsertAt(element, 0);
            //assert
            da.Length.Should().Be(1);
            da.GetAt(0).Should().Be(element);
        }

        [Fact]
        public void IndexOf_ForEmptyList_ReturnsMinus1()
        {
            //arrange
            const int element = 1;
            var da = new LinkedList<int>();
            //act
            var result = da.IndexOf(element);
            //assert
            result.Should().Be(-1);
        }

        [Fact]
        public void IndexOf_ForExistingElement_ReturnsItsIndex()
        {
            //arrange
            const int index = 3;
            const int element = 99;
            var da = new LinkedList<int>();
            for(var i = 0; i < 5; i++) {
                da.Add(i);
            }
            da[index] = element;
            //act
            var result = da.IndexOf(element);
            //assert
            result.Should().Be(index);
        }

        [Fact]
        public void IndexOf_ForNonExistingElement_ReturnsMinus1()
        {
            //arrange
            const int index = -1;
            const int element = 99;
            var da = new LinkedList<int>();
            for(var i = 0; i < 5; i++) {
                da.Add(i);
            }
            //act
            var result = da.IndexOf(element);
            //assert
            result.Should().Be(index);
        }

        [Fact]
        public void Remove_ForNonExistingElement_LeavesListTheWayItWas()
        {
            //arrange
            const int length = 5;
            const int value = 11;
            const int element = 99;
            var da = new LinkedList<int>();
            for(var i = 0; i < length; i++) {
                da.Add(value);
            }
            //act
            da.Remove(element);
            //assert
            da.Length.Should().Be(length);
            da[0].Should().Be(value);
            da[1].Should().Be(value);
            da[2].Should().Be(value);
            da[3].Should().Be(value);
            da[4].Should().Be(value);
        }

        [Fact]
        public void Remove_ForExistingElement_RemovesIt()
        {
            //arrange
            const int length= 4;
            const int value = 11;
            const int element = 99;
            var da = new LinkedList<int>();
            for(var i = 0; i < length+1; i++) {
                da.Add(value);
            }
            da[3] = element;
            //act
            da.Remove(element);
            //assert
            da.Length.Should().Be(length);
            da[0].Should().Be(value);
            da[1].Should().Be(value);
            da[2].Should().Be(value);
            da[3].Should().Be(value);
        }

        [Fact]
        public void RemoveAt_ForMinusOneIndex_ThrowsIndexOutOfRangeException()
        {
            //arrange
            const int length = 5;
            const int value = 11;
            var da = new LinkedList<int>();
            for(var i = 0; i < length; i++) {
                da.Add(value);
            }
            //act
            Action act = () => { da.RemoveAt(-1); };
            //assert
            act.Should().Throw<IndexOutOfRangeException>();
        }

        [Fact]
        public void RemoveAt_ForIndexEqualToLength_ThrowsIndexOutOfRangeException()
        {
            //arrange
            const int length = 5;
            const int value = 11;
            var da = new LinkedList<int>();
            for(var i = 0; i < length; i++) {
                da.Add(value);
            }
            //act
            Action act = () => { da.RemoveAt(length); };
            //assert
            act.Should().Throw<IndexOutOfRangeException>();
        }

        [Fact]
        public void RemoveAt_ForGoodIndex_RemovesIt()
        {
            //arrange
            const int length = 4;
            const int value = 11;
            const int element = 99;
            const int removalIndex = 3;
            var da = new LinkedList<int>();
            for(var i = 0; i < length+1; i++) {
                da.Add(value);
            }
            da[removalIndex] = element;
            //act
            da.RemoveAt(removalIndex);
            //assert
            da.Length.Should().Be(length);
            da[0].Should().Be(value);
            da[1].Should().Be(value);
            da[2].Should().Be(value);
            da[3].Should().Be(value);
        }
    }
}

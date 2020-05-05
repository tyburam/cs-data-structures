using System;
using FluentAssertions;
using Xunit;

namespace DataStructures.Tests
{
    public class ChainingHashTableTests
    {
        [Fact]
        public void Constructor_ForGoodParameter_DontThrowException()
        {
            //arrange + act
            Action act = () => { var cht = new ChainingHashTable<string, int>(5); };
            //assert
            act.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void Constructor_ForBadParameter_ThrowsException()
        {
            //arrange + act
            Action act = () => { var cht = new ChainingHashTable<string, int>(0); };
            //assert
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Add_ForNullKey_ThrowsException()
        {
            //arrange
            var cht = new ChainingHashTable<string, int>(5);
            //act
            Action act = () => { cht.Add(null, 1); };
            //assert
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Add_ForGoodValues_InsertsIt()
        {
            //arrange
            const string key = "1";
            const int value = 1;
            var cht = new ChainingHashTable<string, int>(5);
            //act
            cht.Add(key, value);
            //assert
            cht[key].Should().Be(value);
        }

        [Fact]
        public void Get_ForNull_ThrowsException()
        {
            //arrange
            var cht = new ChainingHashTable<string, int>(5);
            //arrange + act
            Action act = () => { cht.Get(null); };
            //assert
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Get_ForNotExistingKey_ThrowsException()
        {
            //arrange
            var cht = new ChainingHashTable<string, int>(5);
            //arrange + act
            Action act = () => { cht.Get("null"); };
            //assert
            act.Should().Throw<System.Collections.Generic.KeyNotFoundException>();
        }

        [Fact]
        public void Get_ForExistingKey_ReturnsTheValue()
        {
            //arrange
            const string key = "1";
            const int value = 1;
            var cht = new ChainingHashTable<string, int>(5);
            cht.Add(key, value);
            //act
            var result = cht.Get(key);
            //assert
            result.Should().Be(value);
        }
    }
}

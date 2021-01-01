using System;
using FluentAssertions;
using Xunit;
using DataStructures.Hash;
using System.Diagnostics;

namespace DataStructures.Tests.Hash
{
    public class OpenAddressingHashTableTests
    {
        [Fact]
        public void Constructor_ForGoodParameter_DontThrowException()
        {
            //arrange + act
            Action act = () => { var oaht = new OpenAddressingHashTable<string, int>(5); };
            //assert
            act.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void Constructor_ForBadParameter_ThrowsException()
        {
            //arrange + act
            Action act = () => { var oaht = new OpenAddressingHashTable<string, int>(0); };
            //assert
            act.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData(ProbingType.Linear)]
        [InlineData(ProbingType.Quadratic)]
        public void Add_ForNullKey_ThrowsException(ProbingType type)
        {
            //arrange
            var oaht = new OpenAddressingHashTable<string, int>(5, type);
            //act
            Action act = () => { oaht.Add(null, 1); };
            //assert
            act.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData(ProbingType.Linear)]
        [InlineData(ProbingType.Quadratic)]
        public void Add_ForGoodValues_InsertsIt(ProbingType type)
        {
            //arrange
            const string key = "1";
            const int value = 1;
            var oaht = new OpenAddressingHashTable<string, int>(5, type);
            //act
            oaht.Add(key, value);
            //assert
            oaht[key].Should().Be(value);
        }

        [Theory]
        [InlineData(ProbingType.Linear)]
        [InlineData(ProbingType.Quadratic)]
        public void Get_ForNull_ThrowsException(ProbingType type)
        {
            //arrange
            var oaht = new OpenAddressingHashTable<string, int>(5, type);
            //arrange + act
            Action act = () => { oaht.Get(null); };
            //assert
            act.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData(ProbingType.Linear)]
        [InlineData(ProbingType.Quadratic)]
        public void Get_ForNotExistingKey_ThrowsException(ProbingType type)
        {
            //arrange
            var oaht = new OpenAddressingHashTable<string, int>(5, type);
            //arrange + act
            Action act = () => { oaht.Get("null"); };
            //assert
            act.Should().Throw<System.Collections.Generic.KeyNotFoundException>();
        }

        [Theory]
        [InlineData(ProbingType.Linear)]
        [InlineData(ProbingType.Quadratic)]
        public void Get_ForExistingKey_ReturnsTheValue(ProbingType type)
        {
            //arrange
            const string key = "1";
            const int value = 1;
            var oaht = new OpenAddressingHashTable<string, int>(5, type);
            oaht.Add(key, value);
            //act
            var result = oaht.Get(key);
            //assert
            result.Should().Be(value);
        }
    }
}
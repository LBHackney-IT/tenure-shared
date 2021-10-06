using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Hackney.Shared.Tenure.Infrastructure;
using Xunit;

namespace Hackney.Shared.Tenure.Tests.Infrastructure
{
    public class EnumerableExtensionsTests
    {
        [Fact]
        public void ToListOrEmptyTestNullReturnsEmpty()
        {
            var sut = (IEnumerable<string>)null;
            sut.ToListOrEmpty().Should().BeEmpty();
        }

        [Fact]
        public void ToListOrEmptyTestEmptyReturnsEmpty()
        {
            var sut = Enumerable.Empty<string>();
            sut.ToListOrEmpty().Should().BeEmpty();
        }

        [Fact]
        public void ToListOrEmptyTestPupluatedReturnsList()
        {
            var sut = new[] { "one", "two", "three" };
            sut.ToListOrEmpty().Should().BeEquivalentTo(sut);
        }

        [Fact]
        public void ToListOrNullTestNullReturnsNull()
        {
            var sut = (IEnumerable<string>)null;
            sut.ToListOrNull().Should().BeNull();
        }

        [Fact]
        public void ToListOrNullTestEmptyReturnsEmpty()
        {
            var sut = Enumerable.Empty<string>();
            sut.ToListOrNull().Should().BeEmpty();
        }

        [Fact]
        public void ToListOrNullTestPupluatedReturnsList()
        {
            var sut = new[] { "one", "two", "three" };
            sut.ToListOrNull().Should().BeEquivalentTo(sut);
        }
    }
}

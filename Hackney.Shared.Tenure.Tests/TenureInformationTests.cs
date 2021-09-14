using System;
using FluentAssertions;
using Hackney.Shared.Tenure;
using Xunit;

namespace Hackney.Shared.Tenure.Tests
{
    public class TenureInformationTests
    {
        private TenureInformation _classUnderTest;

        public TenureInformationTests()
        {
            _classUnderTest = new TenureInformation();
        }

        [Fact]
        public void GivenATenureWhenEndDateIsNullThenIsActiveShouldBeTrue()
        {
            // given + when + then
            _classUnderTest.IsActive.Should().BeTrue();
        }

        [Fact]
        public void GivenATenureWhenEndDateIsGreaterThanCurrentDateThenIsActiveShouldBeTrue()
        {
            // given
            _classUnderTest.EndOfTenureDate = DateTime.Now.AddDays(1);

            // when + then
            _classUnderTest.IsActive.Should().BeTrue();
        }

        [Fact]
        public void GivenATenureWhenEndDateIsMinimumDateThanCurrentDateThenIsActiveShouldBeTrue()
        {
            // given
            _classUnderTest.EndOfTenureDate = DateTime.Parse("1900-01-01");

            // when + then
            _classUnderTest.IsActive.Should().BeTrue();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void GivenATenureWhenEndDateIsLessThanCurrentDateThenIsActiveShouldBeFalse(int daysToAdd)
        {
            // given
            _classUnderTest.EndOfTenureDate = DateTime.UtcNow.AddDays(daysToAdd);

            // when + then
            _classUnderTest.IsActive.Should().BeFalse();
        }
    }
}

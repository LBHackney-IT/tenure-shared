using AutoFixture;
using FluentAssertions;
using Hackney.Shared.Tenure.Boundary.Requests;
using Hackney.Shared.Tenure.Factories;
using Xunit;

namespace Hackney.Shared.Tenure.Tests.Factories
{
    public class UpdateRequestFactoryTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void CanMapARequestToADatabaseObject(bool nullHMs)
        {
            var request = _fixture.Create<UpdateTenureRequestObject>();
            if (nullHMs) request.HouseholdMembers = null;

            var databaseEntity = request.ToDatabase();
            databaseEntity.LegacyReferences.Should().BeNull();
            databaseEntity.Notices.Should().BeNull();
            databaseEntity.HouseholdMembers.Should().BeEquivalentTo(nullHMs ? null : request.HouseholdMembers);
        }
    }
}

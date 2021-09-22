using System;
using AutoFixture;
using Hackney.Shared.Tenure.Domain;
using Hackney.Shared.Tenure.Factories;
using Hackney.Shared.Tenure.Infrastructure;
using FluentAssertions;
using Xunit;

namespace Hackney.Shared.Tenure.Tests.Factories
{
    public class EntityFactoryTest
    {
        private readonly Fixture _fixture = new Fixture();

        [Fact]
        public void CanMapADatabaseEntityToADomainObject()
        {
            var databaseEntity = _fixture.Create<TenureInformationDb>();
            databaseEntity.EndOfTenureDate = DateTime.UtcNow;

            var entity = databaseEntity.ToDomain();

            databaseEntity.Should().BeEquivalentTo(entity, config => config.Excluding(x => x.IsActive));
        }


        [Fact]
        public void CanMapADomainEntityToADatabaseObject()
        {
            var entity = _fixture.Create<TenureInformation>();
            entity.EndOfTenureDate = DateTime.UtcNow;

            var databaseEntity = entity.ToDatabase();

            entity.Should().BeEquivalentTo(databaseEntity);
        }
    }
}

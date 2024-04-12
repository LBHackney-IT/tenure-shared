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

        #region Tenure Information
        [Fact]
        public void NullTenureDomainMapsToNullTenureDatabaseEntity()
        {
            // arrange
            TenureInformation domainTenure = null;

            // act
            var entityTenure = domainTenure.ToDatabase();

            // assert
            entityTenure.Should().BeNull();
        }

        [Fact]
        public void NullTenureDatabaseEntityMapsToNullTenureDomain()
        {
            // arrange
            TenureInformationDb entityTenure = null;

            // act
            var domainTenure = entityTenure.ToDomain();

            // assert
            domainTenure.Should().BeNull();
        }

        [Fact]
        public void CanMapADatabaseEntityToADomainObject()
        {
            var databaseEntity = _fixture.Create<TenureInformationDb>();
            databaseEntity.EndOfTenureDate = DateTime.UtcNow;

            var domainTenure = databaseEntity.ToDomain();

            databaseEntity.Should().BeEquivalentTo(domainTenure, config => config.Excluding(x => x.IsActive));

            // If it is null, cross-static-method calls were not properly covered.
            domainTenure.TempAccInfo.Should().NotBeNull();
        }

        [Fact]
        public void CanMapADomainEntityToADatabaseObject()
        {
            var entity = _fixture.Create<TenureInformation>();
            entity.EndOfTenureDate = DateTime.UtcNow;

            var databaseEntity = entity.ToDatabase();

            entity.Should().BeEquivalentTo(databaseEntity);

            // If it is null, cross-static-method calls were not properly covered.
            databaseEntity.TempAccInfo.Should().NotBeNull();
        }
        #endregion
        #region Temporary Accommodation Information
        #region Domain to Entity
        [Fact]
        public void NullTAOfficerDomainMapsToNullTAOfficerDatabase()
        {
            // arrange
            TemporaryAccommodationOfficer domainTAOfficer = null;

            // act
            var taOfficerEntity = domainTAOfficer.ToDatabase();

            // assert
            taOfficerEntity.Should().BeNull();
        }
        [Fact]
        public void NullTAInfoDomainMapsToNullTAInfoDatabase()
        {
            // arrange
            TemporaryAccommodationInfo domainTAInfo = null;

            // act
            var taInfoEntity = domainTAInfo.ToDatabase();

            // assert
            taInfoEntity.Should().BeNull();
        }
        [Fact]
        public void TAInfoDomainMapsFieldsCorrectlyToTAInfoDatabase()
        {
            // arrange
            var domainTAInfo = _fixture.Create<TemporaryAccommodationInfo>();

            // act
            var taInfoEntity = domainTAInfo.ToDatabase();

            // assert
            taInfoEntity.BookingStatus.Should().Be(domainTAInfo.BookingStatus);
            // If it is null, cross-static-method calls were not properly covered.
            taInfoEntity.AssignedOfficer.Should().NotBeNull();
            taInfoEntity.AssignedOfficer.Should().Be(domainTAInfo.AssignedOfficer);
        }
        [Fact]
        public void TAOfficerDomainMapsFieldsCorrectlyToTAOfficerDatabase()
        {
            // arrange
            var domainTAOfficer = _fixture.Create<TemporaryAccommodationOfficer>();

            // act
            var taOfficerEntity = domainTAOfficer.ToDatabase();

            // assert
            taOfficerEntity.FirstName.Should().Be(domainTAOfficer.FirstName);
            taOfficerEntity.LastName.Should().Be(domainTAOfficer.LastName);
            taOfficerEntity.Email.Should().Be(domainTAOfficer.Email);
        }
        #endregion
        #region Entity to Domain
        [Fact]
        public void NullTAOfficerEntityMapsToNullTAOfficerDomain()
        {
            // arrange
            TemporaryAccommodationOfficerDb entityTAOfficer = null;

            // act
            var taOfficerDomain = entityTAOfficer.ToDomain();

            // assert
            taOfficerDomain.Should().BeNull();
        }
        [Fact]
        public void NullTAInfoEntityMapsToNullTAInfoDomain()
        {
            // arrange
            TemporaryAccommodationInfoDb entityTAInfo = null;

            // act
            var taInfoDomain = entityTAInfo.ToDomain();

            // assert
            taInfoDomain.Should().BeNull();
        }
        [Fact]
        public void TAInfoEntityMapsFieldsCorrectlyToTAInfoDomain()
        {
            // arrange
            var entityTAInfo = _fixture.Create<TemporaryAccommodationInfoDb>();

            // act
            var taInfoDomain = entityTAInfo.ToDomain();

            // assert
            taInfoDomain.BookingStatus.Should().Be(entityTAInfo.BookingStatus);
            // If it is null, cross-static-method calls were not properly covered.
            taInfoDomain.AssignedOfficer.Should().NotBeNull();
            taInfoDomain.AssignedOfficer.Should().Be(entityTAInfo.AssignedOfficer);
        }
        [Fact]
        public void TAOfficerEntityMapsFieldsCorrectlyToTAOfficerDomain()
        {
            // arrange
            var entityTAOfficer = _fixture.Create<TemporaryAccommodationOfficerDb>();

            // act
            var taOfficerDomain = entityTAOfficer.ToDomain();

            // assert
            taOfficerDomain.FirstName.Should().Be(entityTAOfficer.FirstName);
            taOfficerDomain.LastName.Should().Be(entityTAOfficer.LastName);
            taOfficerDomain.Email.Should().Be(entityTAOfficer.Email);
        }
        #endregion
        #endregion
    }
}

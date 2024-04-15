using AutoFixture;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using Hackney.Shared.Tenure.Domain;
using Hackney.Shared.Tenure.Factories;
using Xunit;

namespace Hackney.Shared.Tenure.Tests.Factories
{
    public class ResponseFactoryTest
    {
        private readonly Fixture _fixture = new Fixture();

        #region Tenure Information
        [Fact]
        public void CanMapANullTenureInfoToAResponseObject()
        {
            TenureInformation domain = null;
            var response = domain.ToResponse();

            response.Should().BeNull();
        }

        [Fact]
        public void CanMapATenureInfoToAResponseObject()
        {
            var domain = _fixture.Create<TenureInformation>();
            var response = domain.ToResponse();

            domain.Should().BeEquivalentTo(response);

            // If it is null, cross-static-method calls were not properly covered.
            response.TempAccommodationInfo.Should().NotBeNull();
        }

        [Fact]
        public void CanMapDomainTenureInfoListToAResponsesList()
        {
            var list = _fixture.CreateMany<TenureInformation>(10);
            var responseNotes = list.ToResponse();

            responseNotes.Should().BeEquivalentTo(list, config => config.Excluding(x => x.VersionNumber));

        }

        [Fact]
        public void CanMapNullDomainTenureInfoListToAnEmptyResponsesList()
        {
            List<TenureInformation> list = null;
            var responseNotes = list.ToResponse();

            responseNotes.Should().BeEmpty();
        }
        #endregion
        #region Temporary Accommodation details
        [Fact]
        public void NullTAOfficerDomainMapsToNullTAOfficerResponse()
        {
            // arrange
            TemporaryAccommodationOfficer domainTAOfficer = null;

            // act
            var taOfficerPresentation = domainTAOfficer.ToResponse();

            // assert
            taOfficerPresentation.Should().BeNull();
        }
        [Fact]
        public void NullTAInfoDomainMapsToNullTAInfoResponse()
        {
            // arrange
            TemporaryAccommodationInfo domainTAInfo = null;

            // act
            var taInfoPresentation = domainTAInfo.ToResponse();

            // assert
            taInfoPresentation.Should().BeNull();
        }
        [Fact]
        public void TAInfoDomainMapsFieldsCorrectlyToTAInfoResponse()
        {
            // arrange
            var domainTAInfo = _fixture.Create<TemporaryAccommodationInfo>();

            // act
            var taInfoPresentation = domainTAInfo.ToResponse();

            // assert
            taInfoPresentation.BookingStatus.Should().Be(domainTAInfo.BookingStatus);
            // If it is null, cross-static-method calls were not properly covered.
            taInfoPresentation.AssignedOfficer.Should().NotBeNull();
            taInfoPresentation.AssignedOfficer.Should().BeEquivalentTo(domainTAInfo.AssignedOfficer);
        }
        [Fact]
        public void TAOfficerDomainMapsFieldsCorrectlyToTAOfficerResponse()
        {
            // arrange
            var domainTAOfficer = _fixture.Create<TemporaryAccommodationOfficer>();

            // act
            var taOfficerPresentation = domainTAOfficer.ToResponse();

            // assert
            taOfficerPresentation.FirstName.Should().Be(domainTAOfficer.FirstName);
            taOfficerPresentation.LastName.Should().Be(domainTAOfficer.LastName);
            taOfficerPresentation.Email.Should().Be(domainTAOfficer.Email);
        }
        #endregion
    }
}

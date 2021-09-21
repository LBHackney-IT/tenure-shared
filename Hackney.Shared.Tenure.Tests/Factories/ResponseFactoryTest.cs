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
    }
}

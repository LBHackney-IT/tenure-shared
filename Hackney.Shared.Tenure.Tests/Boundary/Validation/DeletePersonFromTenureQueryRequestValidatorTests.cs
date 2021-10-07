using FluentValidation.TestHelper;
using Hackney.Shared.Tenure.Boundary.Requests;
using Hackney.Shared.Tenure.Boundary.Requests.Validation;
using System;
using Xunit;

namespace Hackney.Shared.Tenure.Tests.Boundary.Requests.Validation
{
    public class DeletePersonFromTenureQueryRequestValidatorTests
    {
        private readonly DeletePersonFromTenureQueryRequestValidator _sut;

        public DeletePersonFromTenureQueryRequestValidatorTests()
        {
            _sut = new DeletePersonFromTenureQueryRequestValidator();
        }

        [Fact]
        public void RequestShouldErrorWithNullTenureId()
        {
            var query = new DeletePersonFromTenureQueryRequest();
            var result = _sut.TestValidate(query);
            result.ShouldHaveValidationErrorFor(x => x.TenureId);
        }

        [Fact]
        public void RequestShouldErrorWithEmptyId()
        {
            var query = new DeletePersonFromTenureQueryRequest() { TenureId = Guid.Empty };
            var result = _sut.TestValidate(query);
            result.ShouldHaveValidationErrorFor(x => x.TenureId);
        }

        [Fact]
        public void RequestShouldErrorWithNullPersonId()
        {
            var query = new DeletePersonFromTenureQueryRequest();
            var result = _sut.TestValidate(query);
            result.ShouldHaveValidationErrorFor(x => x.PersonId);
        }

        [Fact]
        public void RequestShouldErrorWithEmptyPersonId()
        {
            var query = new DeletePersonFromTenureQueryRequest() { PersonId = Guid.Empty };
            var result = _sut.TestValidate(query);
            result.ShouldHaveValidationErrorFor(x => x.PersonId);
        }
    }
}

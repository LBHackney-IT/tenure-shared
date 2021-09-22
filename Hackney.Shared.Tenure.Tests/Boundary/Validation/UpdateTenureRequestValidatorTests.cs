using FluentValidation.TestHelper;
using System;
using Hackney.Shared.Tenure.Boundary.Request.Validation;
using Hackney.Shared.Tenure.Boundary.Requests;
using Xunit;

namespace Hackney.Shared.Tenure.Tests.Boundary.Request.Validation
{
    public class UpdateTenureRequestValidatorTests
    {
        private readonly UpdateTenureRequestValidator _sut;

        public UpdateTenureRequestValidatorTests()
        {
            _sut = new UpdateTenureRequestValidator();
        }

        [Fact]
        public void RequestShouldErrorWithNullId()
        {
            var query = new UpdateTenureRequest();
            var result = _sut.TestValidate(query);
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }

        [Fact]
        public void RequestShouldErrorWithEmptyId()
        {
            var query = new UpdateTenureRequest() { Id = Guid.Empty };
            var result = _sut.TestValidate(query);
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }

        [Fact]
        public void RequestShouldErrorWithNullPersonId()
        {
            var query = new UpdateTenureRequest();
            var result = _sut.TestValidate(query);
            result.ShouldHaveValidationErrorFor(x => x.PersonId);
        }

        [Fact]
        public void RequestShouldErrorWithEmptyPersonId()
        {
            var query = new UpdateTenureRequest() { PersonId = Guid.Empty };
            var result = _sut.TestValidate(query);
            result.ShouldHaveValidationErrorFor(x => x.PersonId);
        }
    }
}

using FluentValidation.TestHelper;
using System;
using Hackney.Shared.Tenure.Boundary.Requests.Validation;
using Hackney.Shared.Tenure.Boundary.Requests;
using Xunit;

namespace Hackney.Shared.Tenure.Tests.Boundary.Requests.Validation
{
    public class GetByIdRequestValidatorTests
    {
        private readonly GetByIdRequestValidator _sut;

        public GetByIdRequestValidatorTests()
        {
            _sut = new GetByIdRequestValidator();
        }

        [Fact]
        public void RequestShouldErrorWithNullTargetId()
        {
            var query = new TenureQueryRequest();
            var result = _sut.TestValidate(query);
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }

        [Fact]
        public void RequestShouldErrorWithEmptyTargetId()
        {
            var query = new TenureQueryRequest() { Id = Guid.Empty };
            var result = _sut.TestValidate(query);
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }
    }
}

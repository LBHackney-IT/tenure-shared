using FluentValidation.TestHelper;
using Hackney.Shared.Tenure.Boundary.Requests;
using Hackney.Shared.Tenure.Boundary.Requests.Validation;
using Hackney.Shared.Tenure.Domain;
using System;
using Xunit;

namespace Hackney.Shared.Tenure.Tests.Boundary.Validation
{
    public class UpdateTenureForPersonRequestObjectValidatorTests
    {
        private const string StringWithTags = "Some string with <tag> in it.";

        public UpdateTenureForPersonRequestObjectValidation _classUnderTest;

        public UpdateTenureForPersonRequestObjectValidatorTests()
        {
            _classUnderTest = new UpdateTenureForPersonRequestObjectValidation();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void RequestShouldNotErrorWithNoFullNameValue(string value)
        {
            var model = new UpdateTenureForPersonRequestObject() { FullName = value };
            var result = _classUnderTest.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.FullName);

        }

        [Fact]
        public void RequestShouldErrorWithTagsInFullNameValue()
        {
            var model = new UpdateTenureForPersonRequestObject() { FullName = StringWithTags };
            var result = _classUnderTest.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.FullName)
                .WithErrorCode(ErrorCodes.XssCheckFailure);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(true)]
        [InlineData(false)]
        public void RequestShouldNotErrorWithIsResponsibleValue(bool? value)
        {
            var model = new UpdateTenureForPersonRequestObject() { IsResponsible = value };
            var result = _classUnderTest.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.IsResponsible);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void RequestShouldNotErrorWithDateOfBirthValue(bool isNull)
        {
            DateTime? value = isNull ? (DateTime?)null : DateTime.UtcNow;
            var model = new UpdateTenureForPersonRequestObject() { DateOfBirth = value };
            var result = _classUnderTest.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.DateOfBirth);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(HouseholdMembersType.Organisation)]
        [InlineData(HouseholdMembersType.Person)]
        public void RequestShouldNotErrorWithTypeValue(HouseholdMembersType? value)
        {
            var model = new UpdateTenureForPersonRequestObject() { Type = value };
            var result = _classUnderTest.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Type);
        }
    }
}

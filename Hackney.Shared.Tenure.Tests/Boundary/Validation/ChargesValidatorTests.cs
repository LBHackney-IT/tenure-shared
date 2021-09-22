using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hackney.Shared.Tenure.Boundary.Requests.Validation;
using Hackney.Shared.Tenure.Domain;
using Xunit;

namespace Hackney.Shared.Tenure.Tests.Boundary.Validation
{
    public class ChargesValidatorTests
    {
        public ChargesValidator _classUnderTest;

        public ChargesValidatorTests()
        {
            _classUnderTest = new ChargesValidator();
        }
        private const string StringWithTags = "Some string with <tag> in it.";



        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void BillingFrequencyShouldNotErrorWithNoValue(string value)
        {
            var model = new Charges() { BillingFrequency = value };
            var result = _classUnderTest.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.BillingFrequency);

        }

        [Fact]
        public void BillingFrequencyShouldErrorWithhTagsInValue()
        {
            var model = new Charges() { BillingFrequency = StringWithTags };
            var result = _classUnderTest.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.BillingFrequency)
                .WithErrorCode(ErrorCodes.XssCheckFailure);
        }
    }
}

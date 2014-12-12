using GS.Domain;
using GS.TestTools;

using Xunit;

namespace GS.Features.Tests.Domain.ValueObjects
{
    public class EmailValidationTests
    {
        private const string ValidEmailString = "test.user@mail.com";

        [Fact]
        public void Should_Not_be_valid_when_Value_is_InCorrect()
        {
            var email = Email.Parse(ValidEmailString);

            email.SetProtectedProperty(x => x.Value, "test.usermail.com");

            Assert.False(email.IsValid());
        }

        [Fact]
        public void Should_be_valid_with_a_correct_Value()
        {
            Assert.True(Email.Parse("test.user@mail.com").IsValid());
        }

        [Fact]
        public void Should_not_be_valid_when_Value_is_Null()
        {
            var email = Email.Parse(ValidEmailString);

            email.SetProtectedProperty(x => x.Value, null);

            Assert.False(email.IsValid());
        }
    }
}

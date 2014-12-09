using System;

using GS.Web.Features.Authentication.Domain;

using Nancy.SimpleAuthentication;

using SimpleAuthentication.Core;

using Xunit;

namespace GS.Features.Tests.Authentication
{
    public class AuthorizedUserTests
    {
        private AuthenticatedUser _authenticatedUser;

        public AuthorizedUserTests()
        {
            _authenticatedUser = AuthenticatedUser.Create(new AuthenticatedClient("Google")
                {
                    AccessToken = new AccessToken
                        {
                            ExpiresOn = DateTime.UtcNow.AddDays(1),
                            PublicToken = Guid.NewGuid().ToString(),
                            SecretToken = Guid.NewGuid().ToString(),
                        },
                    UserInformation = new UserInformation
                        {
                            Email = "test.user@mail.com",
                            Gender = GenderType.Male,
                            Name = "test user",
                            UserName = "test_user",
                            Picture = "http://hfkhfsak/pic.jpg",
                            Locale = "sv-SE",
                            Id = "userid",
                        }
                });
        }

        [Fact]
        public void Should_have_Email()
        {
            Assert.Equal("test.usermail.com", _authenticatedUser.PrimaryEmail());
        }

        [Fact]
        public void Should_have_Name()
        {
            Assert.Equal("test user", _authenticatedUser.Name);
        }

        [Fact]
        public void Should_have_CreatedAt()
        {
            Assert.NotEqual(DateTime.MinValue, _authenticatedUser.CreatedAt);
        }

        [Fact]
        public void Should_have_Id()
        {
            Assert.NotNull(_authenticatedUser.Id);
            Assert.NotEqual(Guid.Empty, _authenticatedUser.Id);
        }

        [Fact]
        public void Should_be_able_to_Create_AutorizedUser()
        {
            Assert.NotNull(_authenticatedUser);
        }
    }
}

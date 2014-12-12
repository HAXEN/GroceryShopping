using System;

using SimpleAuthentication.Core;

namespace GS.TestTools.Mocks
{
    public class AuthenticatedClientMock : IAuthenticatedClient
    {
        public AuthenticatedClientMock(string providerName)
        {
            ProviderName = providerName;
        }

        public AccessToken AccessToken { get; set; }
        public string ProviderName { get; protected set; }
        public UserInformation UserInformation { get; set; }

        public static IAuthenticatedClient TestUser()
        {
            return new AuthenticatedClientMock("Google")
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
                };
        }
    }
}

using System;

using GS.Domain;

using SimpleAuthentication.Core;

namespace GS.Web.Features.Authentication.Domain
{
    public class AuthenticatedUser : AggregateRoot<Guid>
    {
        public string Name { get; protected set; }

        public string PrimaryEmail()
        {
            throw new NotImplementedException();
        }

        public static AuthenticatedUser Create(IAuthenticatedClient authenticatedClient)
        {
            return new AuthenticatedUser
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.UtcNow,
                    Name = authenticatedClient.UserInformation.Name,
                };
        }

        public class UserEmail
        {
            public Email Email { get; protected set; }
            public bool Primary { get; protected set; }
            public DateTime VerifiedAt { get; set; }
        }
    }
}
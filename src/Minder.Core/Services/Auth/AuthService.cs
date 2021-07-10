using Microsoft.AspNet.Identity;
using Minder.DomainModels.Context;
using System;

namespace Minder.Core.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly MinderDbContext _dbContext;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(MinderDbContext dbContext, IPasswordHasher passwordHasher)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
        }

        public void TryLoginAsync(string login, string password, AccountType accountType)
        {
            throw new NotImplementedException();
        }
    }
}

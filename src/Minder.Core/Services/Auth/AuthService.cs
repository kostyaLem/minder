using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Minder.Core.Exceptions;
using Minder.DomainModels.Context;
using Minder.DomainModels.Models;
using System;
using System.Threading.Tasks;

namespace Minder.Core.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly MinderDbContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(MinderDbContext dbContext, IPasswordHasher passwordHasher)
        {
            _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
        }

        public async Task<Account> TryLoginAsync(string login, string password, AccountType accountType)
        {
            ValidateInput(login, password);

            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Login == login);

            var result = _passwordHasher.VerifyHashedPassword(account.PasswordHash, password);

            if (result == PasswordVerificationResult.Failed)            
                throw new NotAuthorizedException();

            return account;
        }

        private void ValidateInput(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login))
                throw new ArgumentNullException(nameof(login));

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException(nameof(password));
        }
    }
}

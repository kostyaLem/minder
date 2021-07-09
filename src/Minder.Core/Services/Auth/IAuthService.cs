using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Minder.Core.Services.Auth
{
    public enum AccountType
    {
        Admin,
        Employee
    }

    public interface IAuthService
    {
        /// <summary>
        /// Попытка авторизации пользователя
        /// </summary>
        /// <param name="login"> Логин </param>
        /// <param name="password"> Пароль </param>
        /// <param name="accountType"> Тип аккаунта </param>
        /// <returns> Найденыый аккаунт </returns>
        void TryLoginAsync(string login, string password, AccountType accountType);
    }

    internal class AuthService : IAuthService
    {
        private readonly DbContext _dbContext;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(DbContext dbContext, IPasswordHasher passwordHasher)
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

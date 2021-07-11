using Minder.DomainModels.Models;
using System.Threading.Tasks;

namespace Minder.Core.Services.Auth
{
    public interface IAuthService
    {
        /// <summary>
        /// Попытка авторизации пользователя
        /// </summary>
        /// <param name="login"> Логин </param>
        /// <param name="password"> Пароль </param>
        /// <param name="accountType"> Тип аккаунта </param>
        /// <returns> Найденыый аккаунт </returns>
        Task<Account> TryLoginAsync(string login, string password, AccountType accountType);
    }
}

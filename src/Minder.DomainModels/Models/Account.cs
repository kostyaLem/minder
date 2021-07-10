#nullable disable

namespace Minder.DomainModels.Models
{
    public partial class Account
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string AccountType { get; set; }
    }
}

using Minder.Core.Services.Auth;
using System.Windows.Media;

namespace Minder.Helpers.Models
{
    public record DescriptionItemPart
    {
        public ImageSource Image { get; set; }
        public AccountType AccountType { get; set; }
        public string Caption { get; set; }
    }
}

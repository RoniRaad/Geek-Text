using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Geek_Text.Models
{
    public class CreditCard
    {
        public string CardNumber { get; set; }
        public int UserId { get; set; }
        public int ExpirationYear { get; set; }
        public int CVVNumber { get; set; }

    }
}

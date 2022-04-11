namespace Geek_Text.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string BookIsbns { get; set;}
        public int Quantity { get; set;}
    }
}

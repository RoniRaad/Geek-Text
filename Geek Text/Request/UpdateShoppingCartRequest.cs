namespace Geek_Text.Request
{
    public class UpdateShoppingCartRequest
    {
        public int UserId { get; set; }
        public string BookIsbn { get; set; }
        public string Name { get; set; }
    }
}

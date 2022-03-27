namespace Geek_Text.Models
{
    public class BookDetails
    {
        public string? ISBN { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int Author { get; set; }
        public string? Genre { get; set; }
        public string? Publisher { get; set; }
        public string? YearPublished { get; set; }
        public int Sold { get; set; }

    }
}

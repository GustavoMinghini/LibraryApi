namespace LibraryApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Edition { get; set; }
        public string Genre { get; set; }
        public int Volume { get; set; }
        public int Quantity { get; set; }

    }
}

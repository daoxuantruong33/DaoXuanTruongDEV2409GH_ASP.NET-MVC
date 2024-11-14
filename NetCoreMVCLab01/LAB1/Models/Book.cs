using Microsoft.AspNetCore.Mvc.Rendering;

namespace LAB1.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int TotalPage { get; set; }
        public string Sumary { get; set; }

        //Danh sách các cuốn sách (nhớ using system.collections generic
        public List<Book> GetBookList()
        {
            List<Book> books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Title = "Chí Phèo",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/images/avartar/1.jpg",
                    Price = 500000,
                    Sumary = "",
                    TotalPage = 250
                    
                },
                new Book()
                {
                    Id = 2,
                    Title = "Thị Nở",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/images/avartar/1.jpg",
                    Price = 500000,
                    Sumary = "",
                    TotalPage = 250

                },
                new Book()
                {
                    Id = 1,
                    Title = "Cậu vàng",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/images/avartar/1.jpg",
                    Price = 500000,
                    Sumary = "",
                    TotalPage = 250

                },
                new Book()
                {
                    Id = 1,
                    Title = "Lão Hạc",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/images/avartar/1.jpg",
                    Price = 500000,
                    Sumary = "",
                    TotalPage = 250

                },
            };
            return books;
        }

        //Chi tiết một cuốc sách theo id( nhớ using system.Linq
        public Book GetBookById(int id)
        {
            Book book = this.GetBookList().FirstOrDefault(b => b.Id == id);
            return book;
        }

        //selectlistitem authors (using microsoft.aspnetcore.mvc.rendering)
        public List<SelectListItem> Authors { get; } = new List<SelectListItem>()
        {
            new SelectListItem {Value="1", Text="Nam Cao"},
            new SelectListItem {Value="2", Text="Ngô Tất Tố"},
            new SelectListItem {Value="3", Text="Nguyễn Du"},
            new SelectListItem {Value="4", Text="Thích Nhất Hạnh"},
        };

        //selectlistitem genres
        public List<SelectListItem> Genres { get; } = new List<SelectListItem>()
        {
            new SelectListItem {Value="1", Text="Truyện tranh"},
            new SelectListItem {Value="2", Text="Văn học đương đại"},
            new SelectListItem {Value="3", Text="Phật học phổ thông"},
            new SelectListItem {Value="4", Text="Truyện cười"},
        };
    }
}

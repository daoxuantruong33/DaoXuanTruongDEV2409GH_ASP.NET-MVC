using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata.Ecma335;

namespace NetCoreMVCLab03.Models
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

        // danh sách các cuốn sách (nhớ using System.Collections.Generic)
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
                Image = "/image/avatar/1.jpg",
                Price = 1,
                Sumary = "",
                TotalPage = 1
                },
            new Book()
            {
                Id = 1,
                Title = "Chí Phèo",
                AuthorId = 1,
                GenreId = 1,
                Image = "/image/avatar/1.jpg",
                Price = 1,
                Sumary = "",
                TotalPage = 1
            },
            new Book()
            {
                Id = 1,
                Title = "Chí Phèo",
                AuthorId = 1,
                GenreId = 1,
                Image = "/image/avatar/1.jpg",
                Price = 1,
                Sumary = "",
                TotalPage = 1
            },
            new Book()
            {
                Id = 1,
                Title = "Chí Phèo",
                AuthorId = 1,
                GenreId = 1,
                Image = "/image/avatar/1.jpg",
                Price = 1,
                Sumary = "",
                TotalPage = 1
            },
        }; 
            return books;
        }

        // chi tiết một cuốn sách theo id (nhớ using System.Linq)
        public Book GetBookById(int id)
        {
            Book book = this.GetBookList().FirstOrDefault(b => b.Id == id);
            return book;
        }

        // SelectListItem Authors (using Microsoft.AspNetCore.Mvc.Rendering)
        public List<SelectListItem> Authors { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value="1", Text="Nam Cao"},
             new SelectListItem {Value="2", Text="Nam Cao"},
              new SelectListItem {Value="3", Text="Nam Cao"},
               new SelectListItem {Value="4", Text="Nam Cao"},
        };

        // selectlistitem genres
        public List<SelectListItem> Genres { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value="1", Text="Nam Cao"},
             new SelectListItem {Value="2", Text="Nam Cao"},
              new SelectListItem {Value="3", Text="Nam Cao"},
               new SelectListItem {Value="4", Text="Nam Cao"},
        };

    }
}

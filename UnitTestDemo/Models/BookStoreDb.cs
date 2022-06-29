using Microsoft.EntityFrameworkCore;

namespace UnitTestDemo.Models
{
    public class BookStoreDb : DbContext
    {
        public BookStoreDb(DbContextOptions<BookStoreDb> options) : base(options) { }
    }
}

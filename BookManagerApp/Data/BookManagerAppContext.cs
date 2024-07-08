using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookManagerApp.Components.Models;

namespace BookManagerApp.Data
{
    public class BookManagerAppContext : DbContext
    {
        public BookManagerAppContext (DbContextOptions<BookManagerAppContext> options)
            : base(options)
        {
        }

        public DbSet<BookManagerApp.Components.Models.Book> Book { get; set; } = default!;
    }
}

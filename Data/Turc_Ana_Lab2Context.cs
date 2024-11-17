using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Turc_Ana_Lab2.Models;

namespace Turc_Ana_Lab2.Data
{
    public class Turc_Ana_Lab2Context : DbContext
    {
        public Turc_Ana_Lab2Context (DbContextOptions<Turc_Ana_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Turc_Ana_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Turc_Ana_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Turc_Ana_Lab2.Models.Author> Author { get; set; } = default!;
    }
}

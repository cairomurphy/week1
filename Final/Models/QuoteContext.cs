using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class QuoteContext : DbContext
    {
        public QuoteContext(DbContextOptions<QuoteContext> options) : base(options)
        {
            //Leave blank for now

        }

        public DbSet<AddedQuote> Quotes { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<AddedQuote>().HasData(
                new AddedQuote
                {
                    QuoteId = 1,
                    Quote = "hello there",
                    Author = "Cairo"
               
                },
                new AddedQuote
                {
                    QuoteId = 2,
                    Quote = "gotcha",
                    Author = "Hilton"
                }
                
                );
        }
    }
}

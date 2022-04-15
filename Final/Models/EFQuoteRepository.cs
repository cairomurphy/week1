using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class EFQuoteRepository : IQuoteRepository
    {
        private QuoteContext context { get; set; }
        public EFQuoteRepository(QuoteContext temp)
        {
            context = temp;
        }

        public IQueryable<AddedQuote> Quotes => context.Quotes;

        public void CreateQuote(AddedQuote q)
        {
            context.Add(q);
            context.SaveChanges();
        }

        public void DeleteQuote(AddedQuote q)
        {
            context.Remove(q);
            context.SaveChanges();
        }

        public void SaveQuote(AddedQuote q)
        {
            context.SaveChanges(); 
        }

        public void UpdateQuote(AddedQuote q)
        {
            context.Update(q);
            context.SaveChanges();
        }
    }
}

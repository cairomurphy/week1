using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public interface IQuoteRepository
    {
        IQueryable<AddedQuote> Quotes { get; }

        public void SaveQuote(AddedQuote q);
        public void CreateQuote(AddedQuote q);
        public void DeleteQuote(AddedQuote q);
        public void UpdateQuote(AddedQuote q);
    }
}

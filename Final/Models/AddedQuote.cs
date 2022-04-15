using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class AddedQuote
    {
        [Key]
        [Required]
        public int QuoteId { get; set; }
        [Required(ErrorMessage ="You need to enter a quote")]
        public string Quote { get; set; }
        [Required(ErrorMessage = "You need to enter an author")]
        public string Author { get; set; }
        //how to do the date
        public string Date { get; set; }
        public string Subject { get; set; }
        public string Citation { get; set; }

    }
}

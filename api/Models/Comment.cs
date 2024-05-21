using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; }

        //.Net core automatically form the relationship within our database
       public int? StockID { get; set; } //? represents nullable type

       //Stock is a Navigation property
       public Stock? Stock { get; set; } 
    }
}
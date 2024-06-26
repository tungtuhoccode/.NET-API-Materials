using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Stock")]
    public class Stock
    {
        public int Id { get; set; }

        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        
        [Column(TypeName = "decimal(18, 2)")] //force SQL database to have 2 decimal places. This is applied to the attribute Purchase below
        public decimal Purchase { get; set; } 

        [Column(TypeName = "decimal(18, 2)")] 
        public decimal LastDiv { get; set; } 

        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }

       //Stock is a Navigation property
        public List<Comment> Comments { get; set; } = new List<Comment>();

    }
}
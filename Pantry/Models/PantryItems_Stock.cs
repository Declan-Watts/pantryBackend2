using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pantry.Models
{
    public class PantryItems_Stock
    {
        [Key]
        public Guid StockID { get; set; }
        public int Qty { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? DateBought { get; set; }

        //
        public Guid PantryItemsID { get; set; }
        public PantryItems PantryItems { get; set; }
    }
}

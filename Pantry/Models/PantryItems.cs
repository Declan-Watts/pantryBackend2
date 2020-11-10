using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Pantry.Models
{
    public class PantryItems
    {
        [Key]
        public Guid PantryItemsID { get; set; }
        public string Name { get; set; }

        public Guid CategoriesID { get; set; }
        
        public Categories Categories { get; set; }

        [JsonIgnore]
        public List<PantryItems_Stock> PantryItems_Stock { get; set; }
    }
}

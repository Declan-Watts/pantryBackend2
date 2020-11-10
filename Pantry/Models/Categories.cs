using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pantry.Models
{
    public class Categories
    {

        [Key]
        public Guid CategoriesID { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        [JsonIgnore]
        public List<PantryItems> PantryItems { get; set; }

    }
}

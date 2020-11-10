using System;
using Microsoft.EntityFrameworkCore;
using Pantry.Models;

namespace Pantry.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<PantryItems> PantryItems { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Pantry.Models.PantryItems_Stock> PantryItems_Stock { get; set; }
    }
}

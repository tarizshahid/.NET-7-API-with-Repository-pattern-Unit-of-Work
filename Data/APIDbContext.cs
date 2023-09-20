using FormulaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FormulaApi.Data
{
    public class APIDbContext : DbContext
    {
        public DbSet<Driver> Drivers { get; set; }
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options) { }
    }
}

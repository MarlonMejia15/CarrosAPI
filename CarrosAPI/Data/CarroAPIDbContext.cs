using CarrosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarrosAPI.Data
{
    public class CarroAPIDbContext:DbContext
    {
        public CarroAPIDbContext(DbContextOptions options): base (options) { 
        
        }

        public DbSet<Carros> Carros { get; set; }
        
    }
}

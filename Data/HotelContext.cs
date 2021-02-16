using Microsoft.EntityFrameworkCore;
using _2106Proj.Models;

namespace _2106Proj.Data
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options)
            : base(options)
        {
        }

        public DbSet<Payment> Payment { get; set; }
    }
}
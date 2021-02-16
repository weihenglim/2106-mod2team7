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
        public DbSet<ReservationInvoice> ReservationInvoice { get; set; }
        public DbSet<PostCharge> PostCharge { get; set; }
        public DbSet<ReceiptItem> ReceiptItem { get; set; }
    }
}
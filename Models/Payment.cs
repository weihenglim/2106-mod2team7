using System;
using System.ComponentModel.DataAnnotations;

namespace _2106Proj.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int GuestId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }
    }
}

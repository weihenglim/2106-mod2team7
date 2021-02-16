using System;
using System.ComponentModel.DataAnnotations;

namespace _2106Proj.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [Display(Name = "Guest ID")]
        public int GuestId { get; set; }

        [Display(Name = "Due Date")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [Display(Name = "Payment Method")]
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }
    }
}

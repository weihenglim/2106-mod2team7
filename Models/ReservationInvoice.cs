using System;
using System.ComponentModel.DataAnnotations;
namespace _2106Proj.Models
{
    public class ReservationInvoice : Payment
    {
        [Display(Name = "Reservation ID")]
        public int ReservationId { get; set; }

        [Display(Name = "Issue Date")]
        [DataType(DataType.Date)]
        public DateTime IssueDate { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
namespace _2106Proj.Models
{
    public class ReservationInvoice : Payment
    {
        public int ReservationId { get; set; }

        [DataType(DataType.Date)]
        public DateTime IssueDate { get; set; }
    }
}

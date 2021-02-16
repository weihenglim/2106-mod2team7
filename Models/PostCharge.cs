using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _2106Proj.Models
{
    public class PostCharge : Payment
    {
        [Display(Name = "Room ID")]
        public int RoomId { get; set; }

        [Display(Name = "Item List")]
        public IList<ReceiptItem> ItemList { get; set; }
    }
}

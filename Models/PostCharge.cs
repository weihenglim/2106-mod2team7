using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _2106Proj.Models
{
    public class PostCharge : Payment
    {
        public int RoomId { get; set; }
        public IList<ReceiptItem> ItemList { get; set; }
    }
}

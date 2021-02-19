using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2106Proj.Models
{
    interface iPostCharge
    {
        public IEnumerable<PostCharge> getAllCharges();
        public IEnumerable<PostCharge> getChargeByResID(int id);
        public PostCharge getChargeByID(int id);
        public PostCharge createNewCharge(int roomID, int ID, DateTime due, string method, decimal amount, int guestID);
        public void updateCharge(PostCharge Charge);
        public void deleteCharge(int id);
        public void addItem(int id, ReceiptItem item);
        public void removeItem(int id, int itemID);
        public decimal calculateTotal();
    }
}

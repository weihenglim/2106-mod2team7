using System;
using System.Collections.Generic;
using _2106Proj.Data;

namespace _2106Proj.Models.Controls
{
    public class PostChargeControl : iPostCharge
    {
        private readonly PostChargeGateway _chargeGateway;
        public PostChargeControl(PostChargeGateway chargeGateway)
        {
            _chargeGateway = chargeGateway;
        }

        public void addItem(int id, ReceiptItem item)
        {
            throw new NotImplementedException();
        }

        public decimal calculateTotal()
        {
            throw new NotImplementedException();
        }

        public PostCharge createNewCharge(int roomID, int ID, DateTime due, string method, decimal amount, int guestID)
        {
            throw new NotImplementedException();
        }

        public void deleteCharge(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PostCharge> getAllCharges()
        {
            throw new NotImplementedException();
        }

        public PostCharge getChargeByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PostCharge> getChargeByResID(int id)
        {
            throw new NotImplementedException();
        }

        public void removeItem(int id, int itemID)
        {
            throw new NotImplementedException();
        }

        public void updateCharge(PostCharge Charge)
        {
            throw new NotImplementedException();
        }
    }
}

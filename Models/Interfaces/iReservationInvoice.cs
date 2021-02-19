using System;
using System.Collections.Generic;

namespace _2106Proj.Models
{
    interface iReservationInvoice
    {
        public IEnumerable<ReservationInvoice> getAllInvoices();
        public IEnumerable<ReservationInvoice> getInvoiceByResID(int id);
        public ReservationInvoice getInvoiceByID(int id);
        public ReservationInvoice createNewInvoice(int resID, DateTime issue, int ID, DateTime due, string method, decimal amount, int guestID);
        public void updateInvoice(ReservationInvoice invoice);
        public void deleteInvoice(int id);
    }
}

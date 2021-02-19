using System;
using System.Collections.Generic;
using _2106Proj.Data;

namespace _2106Proj.Models
{
    public class ReservationInvoiceControl : iReservationInvoice
    {
        private readonly ReservationInvoiceGateway _invoiceGateway;
        public ReservationInvoiceControl(ReservationInvoiceGateway invoiceGateway)
        {
            _invoiceGateway = invoiceGateway;
        }

        public IEnumerable<ReservationInvoice> getAllInvoices()
        {
            return _invoiceGateway.retrieveAllInvoices();
        }

        public IEnumerable<ReservationInvoice> getInvoiceByResID(int id)
        {
            return _invoiceGateway.findByResID(id);
        }

        public ReservationInvoice getInvoiceByID(int id)
        {
            return _invoiceGateway.findByID(id);
        }

        public ReservationInvoice createNewInvoice(int resID, DateTime issue, int ID, DateTime due, string method, decimal amount, int guestID)
        {
            //TODO: Data validation
            ReservationInvoice invoice = new ReservationInvoice();
            invoice.Id = ID;
            invoice.ReservationId = resID;
            invoice.GuestId = guestID;
            invoice.IssueDate = issue;
            invoice.DueDate = due;
            invoice.PaymentMethod = method;
            invoice.Amount = amount;

            _invoiceGateway.insert(invoice);
            return invoice;
        }

        public void updateInvoice(ReservationInvoice invoice)
        {
            //TODO: Data validation
            _invoiceGateway.update(invoice);
        }

        public void deleteInvoice(int id)
        {
            var invoice = _invoiceGateway.findByID(id);
            _invoiceGateway.delete(invoice);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _2106Proj.Models;
using Microsoft.AspNetCore.Http;

namespace _2106Proj.Controllers
{
    public class ReservationInvoicesController : Controller
    {
        private readonly ReservationInvoiceControl _invoiceControl;

        public ReservationInvoicesController(ReservationInvoiceControl invoiceControl)
        {
            _invoiceControl = invoiceControl;
        }

        // GET: ReservationInvoices
        public async Task<IActionResult> Index(string searchString)
        {
            IEnumerable<ReservationInvoice> invoices;
            if (!String.IsNullOrEmpty(searchString))
            {
                invoices = _invoiceControl.getInvoiceByResID(Int32.Parse(searchString));
            }
            else
            {
                invoices = _invoiceControl.getAllInvoices();
            }

            return View(invoices);
        }

        // GET: ReservationInvoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationInvoice = _invoiceControl.getInvoiceByID(id.Value);

            if (reservationInvoice == null)
            {
                return NotFound();
            }

            return View(reservationInvoice);
        }

        // GET: ReservationInvoices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReservationInvoices/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservationId,IssueDate,Id,GuestId,DueDate,PaymentMethod,Amount")] ReservationInvoice formData)
        { 
            var reservationInvoice = _invoiceControl.createNewInvoice(ID: formData.Id, resID: formData.ReservationId, guestID: 
                formData.GuestId, issue: formData.IssueDate, due: formData.DueDate, method: formData.PaymentMethod, amount: formData.Amount);

            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(reservationInvoice);
        }

        // GET: ReservationInvoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationInvoice = _invoiceControl.getInvoiceByID(id.Value);
            if (reservationInvoice == null)
            {
                return NotFound();
            }
            return View(reservationInvoice);
        }

        // POST: ReservationInvoices/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservationId,IssueDate,Id,GuestId,DueDate,PaymentMethod,Amount")] ReservationInvoice formData)
        {
            if (id != formData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _invoiceControl.updateInvoice(formData);
                return RedirectToAction(nameof(Index));
            }
            return View(formData);
        }

        // GET: ReservationInvoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationInvoice = _invoiceControl.getInvoiceByID(id.Value);
            if (reservationInvoice == null)
            {
                return NotFound();
            }

            return View(reservationInvoice);
        }

        // POST: ReservationInvoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _invoiceControl.deleteInvoice(id);
            return RedirectToAction(nameof(Index));
        }

/*        private bool ReservationInvoiceExists(int id)
        {
            return _context.ReservationInvoice.Any(e => e.Id == id);
        }*/
    }
}

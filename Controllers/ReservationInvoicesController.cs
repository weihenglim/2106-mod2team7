using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _2106Proj.Data;
using _2106Proj.Models;

namespace _2106Proj.Controllers
{
    public class ReservationInvoicesController : Controller
    {
        private readonly HotelContext _context;

        public ReservationInvoicesController(HotelContext context)
        {
            _context = context;
        }

        // GET: ReservationInvoices
        public async Task<IActionResult> Index(string searchString)
        {
            var invoices = from i in _context.ReservationInvoice
                         select i;

            if (!String.IsNullOrEmpty(searchString))
            {
                invoices = invoices.Where(s => s.ReservationId.Equals(Int32.Parse(searchString)));
            }

            return View(await invoices.ToListAsync());
        }

        // GET: ReservationInvoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationInvoice = await _context.ReservationInvoice
                .FirstOrDefaultAsync(m => m.Id == id);
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservationId,IssueDate,Id,GuestId,DueDate,PaymentMethod,Amount")] ReservationInvoice reservationInvoice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservationInvoice);
                await _context.SaveChangesAsync();
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

            var reservationInvoice = await _context.ReservationInvoice.FindAsync(id);
            if (reservationInvoice == null)
            {
                return NotFound();
            }
            return View(reservationInvoice);
        }

        // POST: ReservationInvoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservationId,IssueDate,Id,GuestId,DueDate,PaymentMethod,Amount")] ReservationInvoice reservationInvoice)
        {
            if (id != reservationInvoice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservationInvoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationInvoiceExists(reservationInvoice.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reservationInvoice);
        }

        // GET: ReservationInvoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationInvoice = await _context.ReservationInvoice
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var reservationInvoice = await _context.ReservationInvoice.FindAsync(id);
            _context.ReservationInvoice.Remove(reservationInvoice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationInvoiceExists(int id)
        {
            return _context.ReservationInvoice.Any(e => e.Id == id);
        }
    }
}

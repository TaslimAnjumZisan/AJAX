using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AJAX.Data;
using AJAX.Models;

namespace AJAX.Controllers
{
    public class TransectionController : Controller
    {
        private readonly TransectionDbContext _context;

        public TransectionController(TransectionDbContext context)
        {
            _context = context;
        }

        // GET: Transection
        public async Task<IActionResult> Index()
        {
              return _context.Transections != null ? 
                          View(await _context.Transections.ToListAsync()) :
                          Problem("Entity set 'TransectionDbContext.Transections'  is null.");
        }


        // GET: Transection/AddOrEdit
        // GET: Transection/AddOrEdit/id
        public async Task<IActionResult> AddOrEdit(int id=0)
        {
            if(id == 0)
            return View(new TransectionModel());
            else
            {
                var transectionModel = await _context.Transections.FindAsync(id);
                if (transectionModel == null)
                {
                    return NotFound();
                }
                return View(transectionModel);

            }
        }

        // POST: Transection/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransectionId,AccountNumber,BenificiaryName,BankName,SWIFTCode,Account")] TransectionModel transectionModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transectionModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transectionModel);
        }

        // GET: Transection/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Transections == null)
            {
                return NotFound();
            }

            var transectionModel = await _context.Transections.FindAsync(id);
            if (transectionModel == null)
            {
                return NotFound();
            }
            return View(transectionModel);
        }

        // POST: Transection/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("TransectionId,AccountNumber,BenificiaryName,BankName,SWIFTCode,Account")] TransectionModel transectionModel)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(transectionModel);
                    await _context.SaveChangesAsync();
                }
                else
                {
                   try
                    {
                    _context.Update(transectionModel);
                    await _context.SaveChangesAsync();
                    }
                catch (DbUpdateConcurrencyException)
                   {
                        if (!TransectionModelExists(transectionModel.TransectionId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                   }
                }

                return Json(new { isValid = true, html = "" });
            }
            return Json(new { isValid = false, html = "" });
        }

        // GET: Transection/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Transections == null)
            {
                return NotFound();
            }

            var transectionModel = await _context.Transections
                .FirstOrDefaultAsync(m => m.TransectionId == id);
            if (transectionModel == null)
            {
                return NotFound();
            }

            return View(transectionModel);
        }

        // POST: Transection/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Transections == null)
            {
                return Problem("Entity set 'TransectionDbContext.Transections'  is null.");
            }
            var transectionModel = await _context.Transections.FindAsync(id);
            if (transectionModel != null)
            {
                _context.Transections.Remove(transectionModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransectionModelExists(int id)
        {
          return (_context.Transections?.Any(e => e.TransectionId == id)).GetValueOrDefault();
        }
    }
}

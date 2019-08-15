using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace RelProd.Models
{
    public class ChamadosController : Controller
    {
        private readonly RelProdContext _context;

        public ChamadosController(RelProdContext context)
        {
            _context = context;
        }

        // GET: Chamados
        public async Task<IActionResult> Index()
        {
            return View(await _context.Chamados.ToListAsync());
        }

        // GET: Chamados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chamados = await _context.Chamados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chamados == null)
            {
                return NotFound();
            }

            return View(chamados);
        }

        // GET: Chamados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chamados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Status,Setor,Responsavel,Data,hora")] Chamados chamados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chamados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chamados);
        }

        // GET: Chamados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chamados = await _context.Chamados.FindAsync(id);
            if (chamados == null)
            {
                return NotFound();
            }
            return View(chamados);
        }

        // POST: Chamados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Status,Setor,Responsavel,Data,hora")] Chamados chamados)
        {
            if (id != chamados.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chamados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChamadosExists(chamados.Id))
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
            return View(chamados);
        }

        // GET: Chamados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chamados = await _context.Chamados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chamados == null)
            {
                return NotFound();
            }

            return View(chamados);
        }

        // POST: Chamados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chamados = await _context.Chamados.FindAsync(id);
            _context.Chamados.Remove(chamados);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChamadosExists(int id)
        {
            return _context.Chamados.Any(e => e.Id == id);
        }
    }
}

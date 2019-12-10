using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RelProd.Models;
using RelProd.Models.Enuns;
using RelProd.Controllers;
using RelProd.Services;
using ClosedXML.Excel;
using OfficeOpenXml;

namespace RelProd.Models
{
    public class ChamadosController : Controller
    {
        private readonly RelProdContext _context;
		private readonly UsuarioServices _usuarioServices;
		private readonly BuscaService _buscaService;

	

		public ChamadosController(RelProdContext context, UsuarioServices usuarioService, BuscaService buscaService)
        {
            _context = context;
			_usuarioServices = usuarioService;
			_buscaService = buscaService;
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

			 
			var chamados = await _context.Chamados.Include(item => item.Responsavel).FirstOrDefaultAsync(m => m.Id == id);
		
			
			
			 
			
			
            if (chamados == null)
            {
                return NotFound();
            }

            return View(chamados);
        }

        // GET: Chamados/Create
        public IActionResult Create()
        {





			var TipoStatus = new List<SelectListItem>();
			
			





			TipoStatus.Add(new SelectListItem
			{
				Text = "Selecionar",
				Value = ""
			});

			foreach (Status i in Enum.GetValues(typeof(Status)))
			{
				TipoStatus.Add(new SelectListItem { Text = Enum.GetName(typeof(Status), i), Value = i.ToString() });
			}
			ViewBag.TipoStatus = TipoStatus;




			return View();
        }

        // POST: Chamados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Status,Setor,Responsavel,DataAbertura,Data,Hora,Solicitante,Descricao")] Chamados chamados)
        {


			chamados.Data = DateTime.Today;
			chamados.Hora = DateTime.Now;
			

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

			

			var TipoStatus = new List<SelectListItem>();

			TipoStatus.Add(new SelectListItem
			{
				Text = "Selecionar",
				Value = ""
			});

			foreach (Status i in Enum.GetValues(typeof(Status)))
			{
				TipoStatus.Add(new SelectListItem { Text = Enum.GetName(typeof(Status), i), Value = i.ToString() });
			}
			ViewBag.TipoStatus = TipoStatus;
			
			

			


			var Usuario = _usuarioServices.FindAll();
			 
			
			var ListTest = new List<SelectListItem>();

			ListTest.Add(new SelectListItem
			{
				Text = "Selecionar",
				Value = ""
			});

			foreach (var Item in Usuario)
			{
				ListTest.Add(new SelectListItem { Text = Item.Nome, Value = Item.Id.ToString() });
			}
			ViewBag.usuarios = ListTest; 


			return View(chamados);






		}

        // POST: Chamados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Status,Setor,DataAbertura,ResponsavelId,Data,Hora,Solicitante,Descricao")] Chamados chamados)
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

            var chamados = await _context.Chamados.Include(item => item.Responsavel)
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

		public async Task <IActionResult> Relatorio ( DateTime? minDate , DateTime maxDate )
		{

				var result = await _buscaService.FindByDateAsync(minDate, maxDate);
			return View(result);


			ExcelPackage pck = new ExcelPackage();
			ExcelWorksheets ws = pck.Workbook.Worksheets.Add("result");

			ws.Cells["A1"].Valus

			


		}
    }
}

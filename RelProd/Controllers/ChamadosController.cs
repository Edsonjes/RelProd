using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using RelProd.Models.Enuns;
using RelProd.Services;
using RelProd.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelProd.Models
{
	public class ChamadosController : Controller
	{
		private readonly RelProdContext _context;
		private readonly UsuarioServices _usuarioServices;
		private readonly BuscaService _buscaService;
		private readonly ExportService _exportService;



		public ChamadosController(RelProdContext context, UsuarioServices usuarioService, BuscaService buscaService, ExportService exportService)
		{
			_context = context;
			_usuarioServices = usuarioService;
			_buscaService = buscaService;
			_exportService = exportService;
		}

		// GET: Chamados
		public async Task<IActionResult> Index()
		{

			var Chamado = from c in _context.Chamados select c;
			Chamado = Chamado.OrderByDescending(c => c.DataAbertura);
			 
			return View(await Chamado.ToListAsync());





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

		public async Task<IActionResult> Relatorio (DateTime? dataMin, DateTime? dataMax)
		{


				var vm = new relatorioVM();

		  

				vm.listChamados = await _buscaService.FindByDateAsync(dataMin, dataMax);


				return View(vm);


		
		}

		public async Task<ActionResult> ExcelExport(DateTime? dataMin, DateTime maxDate)
		{

			var vm = new relatorioVM();

			vm.listChamados = await _exportService.FindByDateAsync(dataMin, maxDate);




			string[] col_names = new string[]
			{
				"Data",
				"Setor",
				"Solicitante",
				"Descrição"
			};
			byte[] resultado;

			using (var package = new ExcelPackage())
			{
				var worksheet = package.Workbook.Worksheets.Add("Atendimento");


				for (int i = 0; i < col_names.Length; i++)
				{
					worksheet.Cells[1, i + 1].Style.Font.Size = 14; //font da celula
					worksheet.Cells[1, i + 1].Value = col_names[i]; //valor da celula
					worksheet.Cells[1, i + 1].Style.Font.Bold = true;
				}
				int row = 3;

				foreach (Chamados item in vm.listChamados)
				{
					for (int col = 1; col <= 4; col++)
					{
						worksheet.Cells[row, col].Style.Font.Size = 12;

					}

					worksheet.Cells[row, 1].Value = item.DataAbertura.ToShortDateString();
					worksheet.Cells[row, 2].Value = item.Setor;
					worksheet.Cells[row, 3].Value = item.Solicitante;
					worksheet.Cells[row, 4].Value = item.Descricao;
					

					row = (row + 1);

				}
				resultado = package.GetAsByteArray(); 
			}
			return File(resultado, "application/vnd.ms-excel", "relatorio.xls");
		}
	}
}

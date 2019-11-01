using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RelProd.Models;
using System.Web;

using Microsoft.AspNetCore.Http;







namespace RelProd.Controllers
{
	public class UsuariosController : Controller
	{
	   private readonly RelProdContext _Ctx;
		public UsuariosController(RelProdContext context)
		{
			_Ctx = context;
		}
		

		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Login( Usuarios Usuario)
		{


			

			var consultaUsuario = _Ctx.Usuarios.Where(u => u.Email == Usuario.Email && u.Senha == Usuario.Senha).FirstOrDefault();

			if ( consultaUsuario != null)
			{



				ViewData.Add("Usuario", consultaUsuario);
				return Redirect("/Chamados/Index");
				



			}
			else
			{
				ModelState.AddModelError("", "Usuário ou senha ivalidos");
				return View("Index");
				
			}

			
		}
	}
}
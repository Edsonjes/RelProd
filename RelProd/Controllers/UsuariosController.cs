using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RelProd.Models;





namespace RelProd.Controllers
{
	public class UsuariosController : Controller
	{
		RelProdContext _Ctx;
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

				Session["UsuarioLogado"] = consultaUsuario.Email;
				



			}
			else
			{
				ViewBag.ErroAutenticacao = "Usuário ou senha invalidos.";
			}

			return View();
		}
	}
}
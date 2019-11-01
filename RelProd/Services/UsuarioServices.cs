using RelProd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelProd.Services
{
	public class UsuarioServices
	{
		private readonly RelProdContext _ctx;
		public UsuarioServices (RelProdContext ctx)
		{
			_ctx = ctx;
		}

		public List<Usuarios> FindAll()
		{
			return _ctx.Usuarios.OrderBy(x => x.Nome).ToList();
		}
	}
}

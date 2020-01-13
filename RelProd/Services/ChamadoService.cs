using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RelProd.Models;

namespace RelProd.Services
{
	public class ChamadoService
	{
		private readonly RelProdContext _ctx;
		public ChamadoService (RelProdContext ctx)
		{
			_ctx = ctx;
		}

		public List <Chamados> FindAll()
		{
			return (_ctx.Chamados.OrderBy(x => x.DataAbertura).ToList());
		}




	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using RelProd.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RelProd.Services
{
	public class BuscaService
	{
		private readonly RelProdContext ctx;

		public BuscaService(RelProdContext ctx)
		{
			this.ctx = ctx;
		}
		public async Task<List<Chamados>> FindByDateAsync(DateTime? dataMin, DateTime? dataMax)
		{


			var result = ctx.Chamados.Where(x => x.DataAbertura >= dataMin); 


			if (dataMin.HasValue)
			{
				result = result.Where(x => x.Data >= dataMin.Value);
			}
			if (dataMax.HasValue)
			{
				result = result.Where(x => x.Data <= dataMax.Value);
			}

			return await result
				.OrderByDescending(x => x.Data)
				.ToListAsync();
		}
	}
}


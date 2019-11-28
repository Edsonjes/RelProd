using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RelProd.Models;
using Microsoft.EntityFrameworkCore;

namespace RelProd.Services
{
	public class BuscaService
	{
		private readonly RelProdContext ctx;

		public  BuscaService (RelProdContext ctx)
		{
			this.ctx = ctx;
		}
		 public async Task<List <Chamados>> FindByDateAsync( DateTime? minDate, DateTime? maxDate )
		{
			

			var result = from obj in ctx.Chamados select obj;
			

			if (minDate.HasValue)
			{
				result = result.Where(x => x.Data >= minDate.Value);
			}
			if (maxDate.HasValue)
			{
				result = result.Where(x => x.Data <= maxDate.Value);
			}

			return await result
				.OrderByDescending (x => x.Data)
				.ToListAsync();

		

		}

	}
}

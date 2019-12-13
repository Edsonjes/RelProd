using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RelProd.Models;
using Microsoft.EntityFrameworkCore;

namespace RelProd.Services
{
	public class ExportService
	{
		private readonly RelProdContext ctx;

		public ExportService ( RelProdContext _ctx)
		{
			ctx = _ctx;
		}

		public async Task<List<Chamados>> FindByDateAsync(DateTime? dataMin, DateTime? maxDate)
		{


			var result = ctx.Chamados.Where(x => x.DataAbertura >= dataMin);




			return await result
				.OrderByDescending(x => x.Data)
				.ToListAsync();
		}
	}
}

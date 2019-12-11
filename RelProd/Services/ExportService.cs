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

		public async Task<List<Chamados>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
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
				.OrderByDescending(x => x.Data)
				.ToListAsync();
		}
	}
}

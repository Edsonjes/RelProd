using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RelProd.Models;

namespace RelProd.ViewModels
{
	public class relatorioVM
	{
		public DateTime?  dataMin { get; set; }
		public DateTime? dataMax { get; set; }
		public List<Chamados> listChamados { get; set; }
	}
}

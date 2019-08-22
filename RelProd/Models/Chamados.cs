using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using RelProd.Models.Enuns;

namespace RelProd.Models
{
	public class Chamados
	{
		public int Id { get; set; }
		public Status Status { get; set; } 
		public List<SelectListItem> TipoStatus { get; set; }
		public int idStatus { get; set; }
	    public string Setor { get; set; }
		public string Responsavel { get; set; }
		public DateTime Data { get; set; }
		public DateTime hora { get; set; }

		public Chamados ()
		{
			TipoStatus = new List<SelectListItem>();

			TipoStatus.Add(new SelectListItem
			{
				Value = ((int)Status.Aberto).ToString(),
				Text = Status.Aberto.ToString()
			});

			TipoStatus.Add(new SelectListItem
			{
				Value = ((int)Status.Encerrado).ToString(),
				Text = Status.Encerrado.ToString()
			});

			TipoStatus.Add(new SelectListItem
			{
				Value = ((int)Status.EmAtendimento).ToString(),
				Text = Status.EmAtendimento.ToString()
			});
		}

		public Chamados(int id,   string setor,  string responsavel, DateTime data, DateTime hora)
		{
			Id = id;
			Setor = setor;
			Responsavel = responsavel;
			Data = data;
			this.hora = hora;

						
		}


		 
	


	}
}
	


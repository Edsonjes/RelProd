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
		public int idStatus { get; set; }
	    public string Setor { get; set; }
		public string Responsavel { get; set; }
		public DateTime Data { get; set; }
		public DateTime hora { get; set; }

		public Chamados ()
		{

		}

		public Chamados(int id,   string setor, Status status,  string responsavel, DateTime data, DateTime hora)
		{
			Id = id;
			Setor = setor;
			Status = status;
			Responsavel = responsavel;
			Data = data;
			this.hora = hora;

						
		}
		 
						
		public List <Chamados> DropDownStatus()
		{
			

			var item = new List<Chamados>();
			foreach (int s in Status.GetValues(typeof(Status)))
			{
				item.Add(new Chamados
				{
			      Status = Status
				 

				 
				});
			}
			return item;
		}


	}
}
	


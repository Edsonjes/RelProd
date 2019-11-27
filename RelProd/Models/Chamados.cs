using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
		 public string Setor { get; set; }
		
		public Usuarios Responsavel { get; set; }
		public Nullable<int> ResponsavelId { get; set; }

		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]


		public DateTime? Data { get; set; }

		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
		public DateTime? Hora { get; set; }
	   public string Solicitante { get; set; }
		public string Descricao { get; set; }
		


		public Chamados ()
		{
			
		}

		public Chamados(int id, Status status, Usuarios usuario , string setor, DateTime data, DateTime hora, string solicitante, string descricao)
		{
			Id = id;
			Status = status;
			Setor = setor;
			Data = data;
			Hora = hora;
			Solicitante = solicitante;
			Descricao = descricao;
			Responsavel = usuario;
			

			
		}
	}
}
	


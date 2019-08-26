﻿using System;
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
		 public string Setor { get; set; }
		public string Responsavel { get; set; }
		public DateTime Data { get; set; }
		public DateTime Hora { get; set; }
	   public string Solicitante { get; set; }
		public string Descricao { get; set; }


		public Chamados ()
		{
			
		}

		public Chamados(int id, Status status, string setor, string responsavel, DateTime data, DateTime hora, string solicitante, string descricao)
		{
			Id = id;
			Status = status;
			Setor = setor;
			Responsavel = responsavel;
			Data = data;
			Hora = hora;
			Solicitante = solicitante;
			Descricao = descricao;
		}
	}
}
	


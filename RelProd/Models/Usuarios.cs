using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelProd.Models
{
	public class Usuarios
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public int Senha { get; set; }
		public string Email { get; set; }

		public Usuarios ()
		{

		}

		public Usuarios(int id, string nome, int senha, string email)
		{
			Id = id;
			Nome = nome;
			Senha = senha;
			Email = email;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RelProd.Models
{
    public class RelProdContext : DbContext
    {
        public RelProdContext (DbContextOptions<RelProdContext> options)
            : base(options)
        {
        }

        public DbSet<RelProd.Models.Chamados> Chamados { get; set; }
		public DbSet<RelProd.Models.Usuarios> Usuarios { get; set; }
    }
}

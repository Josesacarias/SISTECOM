using Datos.Maping;
using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DbContexSistema : DbContext
    {
        public DbSet<Contract> Contract { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbContexSistema(DbContextOptions<DbContexSistema> options) : base(options)
        {

        }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ContractMap());
        }
        

    }
}

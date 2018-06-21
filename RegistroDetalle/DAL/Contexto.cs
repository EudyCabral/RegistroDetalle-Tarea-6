using RegistroDetalle.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace RegistroDetalle.DAL
{
    public class Contexto :DbContext
    {
        public DbSet<Personas> personas { get; set; }
        public DbSet<Articulos> articulos { get; set; }
        public DbSet<CotizacionArticulos> Cotizacion { get; set; }
        public DbSet <CotizacionArticulosDetalle> Detalle { get; set; }

        public Contexto() : base("ConStr")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RegistroDetalle.ENTIDADES
{
    public class Articulos
    {
        [Key]
        public int ArticuloId { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }



        public Articulos()
        {
            ArticuloId = 0;
            Fecha = DateTime.Now;
            Nombre =string.Empty;
            Cantidad = 0;
            Descripcion = string.Empty;
          
        }
    }
}

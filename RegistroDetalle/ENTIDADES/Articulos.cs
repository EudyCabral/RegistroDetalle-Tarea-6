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
        public DateTime dateTime { get; set; }
        public string Nombre { get; set; }
     

        public Articulos()
        {
            ArticuloId = 0;
            this.dateTime = DateTime.Now;
            Nombre =string.Empty;
          
        }
    }
}

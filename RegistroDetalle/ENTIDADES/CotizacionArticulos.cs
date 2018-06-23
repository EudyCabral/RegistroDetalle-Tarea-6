using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RegistroDetalle.ENTIDADES
{
   public class CotizacionArticulos
    {
        [Key]
        public int CotizacionArticulosId { get; set; }
        public DateTime Fecha { get; set; }

        [StringLength(100)]
        public string Observaciones { get; set; }

        public virtual ICollection<CotizacionArticulosDetalle> Detalle{ get; set; }

        public CotizacionArticulos()
        {
            this.Detalle = new List<CotizacionArticulosDetalle>();

        }

        public void AgregarDetalle(int id ,int CotizacionArticulosId,int PersonaId ,int ArticuloId,string descripcion,int Cantidad,decimal Precio,decimal Importe)
        {
            this.Detalle.Add(new CotizacionArticulosDetalle(id, CotizacionArticulosId, PersonaId, ArticuloId,descripcion, Cantidad, Precio, Importe));
        }
   }
}

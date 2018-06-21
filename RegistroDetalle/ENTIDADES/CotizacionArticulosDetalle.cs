using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace RegistroDetalle.ENTIDADES
{
    public class CotizacionArticulosDetalle
    {
        [Key]

        public int Id { get; set; }
        public int CotizacionArticulosId { get; set; }
        public int PersonaId { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }

        [ForeignKey("PersonaId")]
     

        public virtual Personas personas { get; set; }
        

        public CotizacionArticulosDetalle()
        {
            Id = 0;
            CotizacionArticulosId = 0;
        }

        public CotizacionArticulosDetalle(int id, int cotizacionArticulosId, int personaId, int articuloId, int cantidad, decimal precio, decimal importe)
        {
            Id = id;
            CotizacionArticulosId = cotizacionArticulosId;
            PersonaId = personaId;
            ArticuloId = articuloId;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }
    }
}

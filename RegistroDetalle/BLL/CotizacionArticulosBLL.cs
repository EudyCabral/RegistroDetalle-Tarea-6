using RegistroDetalle.DAL;
using RegistroDetalle.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RegistroDetalle.BLL
{
    public class CotizacionArticulosBLL
    {

        public static bool Guardar(CotizacionArticulos CotizacionArticulos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Cotizacion.Add(CotizacionArticulos) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception) { throw; }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso=false;
            Contexto contexto = new Contexto();

            try
            {
                CotizacionArticulos cotizacionArticulos = contexto.Cotizacion.Find(id);
                cotizacionArticulos.Detalle.Count();
                contexto.Cotizacion.Remove(cotizacionArticulos);

                if (contexto.SaveChanges() > 0)
                {

                    paso = true;
                }
                contexto.Dispose();


            } catch (Exception) { throw; }
            return paso;
        }


        public static bool Editar(CotizacionArticulos cotizacionArticulos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try {
                Repositorio<CotizacionArticulosDetalle> repositorio = new Repositorio<CotizacionArticulosDetalle>(new Contexto());
                List<CotizacionArticulosDetalle> detalle = new List<CotizacionArticulosDetalle>();
                List<CotizacionArticulosDetalle> cotizacionArticulosDetalles = new List<CotizacionArticulosDetalle>();

                detalle = repositorio.GetList(x => x.CotizacionArticulosId == cotizacionArticulos.CotizacionArticulosId);

                for (int x = 0; x < cotizacionArticulos.Detalle.Count(); x++)
                {
                    cotizacionArticulosDetalles.Add(cotizacionArticulos.Detalle.ElementAt(x));
                }

                foreach (var item in detalle)
                {

                    if (cotizacionArticulos.Detalle.Count() != detalle.Count())
                    {
                        if (cotizacionArticulosDetalles.Exists(x => x.Id != item.Id))
                        {

                            repositorio.Eliminar(item.Id);
                        }
                    }

                }

                //recorrer el detalle
                foreach (var item in cotizacionArticulos.Detalle)
                {
                    //Muy importante indicar que pasara con la entidad del detalle
                    var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                    contexto.Entry(item).State = estado;
                }

                contexto.Entry(cotizacionArticulos).State = EntityState.Modified;
                if(contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception) { throw; }
            return paso;
        }


        public static CotizacionArticulos Buscar(int id)
        {
            CotizacionArticulos cotizacionArticulos = new CotizacionArticulos();
            Contexto contexto = new Contexto();

            try
            {
                cotizacionArticulos = contexto.Cotizacion.Find(id);
                if( cotizacionArticulos != null)
                {
                    cotizacionArticulos.Detalle.Count();

                    foreach (var item in cotizacionArticulos.Detalle)
                    {
                       
                        string s = item.articulos.Nombre;
                    }

                }
                contexto.Dispose();
            } catch (Exception) { throw; }
            return cotizacionArticulos;
        }

        public static List<CotizacionArticulos> GetList(Expression<Func<CotizacionArticulos,bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<CotizacionArticulos> cotizacionArticulos = new List<CotizacionArticulos>();

            try
            {
                cotizacionArticulos = contexto.Cotizacion.Where(expression).ToList();

                contexto.Dispose();
            } catch (Exception) { throw; }
            return cotizacionArticulos;

        }

        public static decimal CalcularImporte(decimal precio, int cantidad)
        {
            return Convert.ToDecimal(precio) * Convert.ToInt32(cantidad);
        }
    }
}

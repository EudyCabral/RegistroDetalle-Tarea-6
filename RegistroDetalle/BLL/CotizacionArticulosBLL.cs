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
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                CotizacionArticulos cotizacionArticulos = contexto.Cotizacion.Find(id);
               
              
               if(cotizacionArticulos != null)
                {
                    cotizacionArticulos.Detalle.Count();
                    contexto.Cotizacion.Remove(cotizacionArticulos);
                }
            
                   
                

                if (contexto.SaveChanges() > 0)
                {

                    paso = true;
                }
                contexto.Dispose();


            }
            catch (Exception) { throw; }
            return paso;
        }


        public static bool Editar(CotizacionArticulos cotizacionArticulos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var cotizaciones = CotizacionArticulosBLL.Buscar(cotizacionArticulos.CotizacionArticulosId);



                

                if (cotizaciones != null)
                {

                    foreach (var item in cotizaciones.Detalle)//recorrer el detalle aterior
                    {
                        //restar todas las visitas
                        contexto.articulos.Find(item.ArticuloId).Cantidad -= item.Cantidad;

                        //determinar si el item no esta en el detalle actual
                        if (!cotizacionArticulos.Detalle.ToList().Exists(v => v.Id == item.Id))
                        {
                            contexto.articulos.Find(item.ArticuloId).Cantidad -= item.Cantidad;
                            item.articulos = null; //quitar la ciudad para que EF no intente hacerle nada
                            contexto.Entry(item).State = EntityState.Deleted;
                        }
                    }

                    foreach (var item in cotizacionArticulos.Detalle)
                    {
                        //Muy importante indicar que pasara con la entidad del detalle
                        var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                        contexto.Entry(item).State = estado;
                    }

                    contexto.Entry(cotizacionArticulos).State = EntityState.Modified;
                }
                //recorrer el detalle
            

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                // contexto.Dispose();
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
                if (cotizacionArticulos != null)
                {
                    cotizacionArticulos.Detalle.Count();

                    foreach (var item in cotizacionArticulos.Detalle)
                    {

                        string s = item.articulos.Nombre;
                    }

                }
                contexto.Dispose();
            }
            catch (Exception) { throw; }
            return cotizacionArticulos;
        }

        public static List<CotizacionArticulos> GetList(Expression<Func<CotizacionArticulos, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<CotizacionArticulos> cotizacionArticulos = new List<CotizacionArticulos>();

            try
            {
                cotizacionArticulos = contexto.Cotizacion.Where(expression).ToList();

                contexto.Dispose();
            }
            catch (Exception) { throw; }
            return cotizacionArticulos;

        }

        public static decimal CalcularImporte(decimal precio, int cantidad)
        {
            return Convert.ToDecimal(precio) * Convert.ToInt32(cantidad);
        }



    }
}

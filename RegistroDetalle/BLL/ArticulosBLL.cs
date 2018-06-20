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
    public class ArticulosBLL
    {

        public static bool Guardar(Articulos articulos)
        {
            bool paso = false;
            //Creamos una instancia del contexto para poder conectar con la BD
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.articulos.Add(articulos) != null)
                {
                    contexto.SaveChanges(); //Guardar los cambios
                    paso = true;
                }

                contexto.Dispose();//siempre hay que cerrar la conexion
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Articulos articulos = contexto.articulos.Find(id);

                if (articulos != null)
                {
                    contexto.Entry(articulos).State = EntityState.Deleted;
                }

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                    contexto.Dispose();
                }
            }
            catch (Exception) { throw; }
            return paso;
        }

        public static bool Editar(Articulos articulos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Entry(articulos).State = EntityState.Modified;

                if (contexto.SaveChanges() > 0)
                {

                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception) { throw; }
            return paso;
        }



        public static Articulos Buscar(int id)
        {
            Contexto contexto = new Contexto();
           Articulos articulos = new Articulos();
            try
            {
                articulos = contexto.articulos.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return articulos;
        }



        public static List<Articulos> GetList(Expression<Func<Articulos, bool>> expression)
        {
            List<Articulos> articulos = new List<Articulos>();
            Contexto contexto = new Contexto();
            try
            {
                articulos = contexto.articulos.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

            return articulos;
        }
    }
}

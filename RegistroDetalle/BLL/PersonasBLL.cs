using RegistroDetalle.DAL;
using RegistroDetalle.ENTIDADES;
using RegistroDetalle.UI.REGISTROS;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RegistroDetalle.BLL
{
    public class PersonasBLL
    {
       

        public static bool Guardar(Personas persona)
        {
            bool paso = false;
            //Creamos una instancia del contexto para poder conectar con la BD
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.personas.Add(persona) != null)
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

            try {
                Personas personas = contexto.personas.Find(id);

                if(personas != null)
                {
                    contexto.Entry(personas).State = EntityState.Deleted;
                }

                if(contexto.SaveChanges()>0)
                {
                    paso = true;
                    contexto.Dispose();
                }
            } catch (Exception) { throw; }
            return paso;
        }

        public static bool Editar(Persona persona)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try {

                contexto.Entry(persona).State = EntityState.Modified;

                if (contexto.SaveChanges() > 0)
                {
                   
                    paso = true;
                }
                contexto.Dispose();
            } catch (Exception) { throw; }
            return paso;
        }

    

        public static Personas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Personas persona = new Personas();
            try
            {
                persona = contexto.personas.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return persona;
        }

        

        public static List<Personas> GetList(Expression<Func<Personas, bool>> expression)
        {
            List<Personas> Personas = new List<Personas>();
            Contexto contexto = new Contexto();
            try
            {
                Personas = contexto.personas.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

            return Personas;
        }

    }
}

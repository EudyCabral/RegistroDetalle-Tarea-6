using RegistroDetalle.ENTIDADES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegistroDetalle.UI.REGISTROS
{
    public partial class Articulo : Form
    {
        public Articulo()
        {
            InitializeComponent();
        }

        private void Articulo_Load(object sender, EventArgs e)
        {

        }
        private Articulos Llenaclase()
        {
            Articulos articulos = new Articulos();

            articulos.ArticuloId = Convert.ToInt32(articuloIdNumericUpDown.Value);
            articulos.Nombre = nombreTextBox.Text;
            articulos.Fecha = fechaDateTimePicker.Value;
            articulos.Descripcion = descripcionTextBox.Text;
            articulos.Cantidad = Convert.ToInt32(cantidadNumericUpDown.Value);
            articulos.Precio = Convert.ToDecimal(precioTextBox.Text);
          
            return articulos;
        }
        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool Paso = false;
            Articulos articulos = Llenaclase();

            if (ValidarGuardar())
            {
                MessageBox.Show("Favor Llenar Casilla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (articuloIdNumericUpDown.Value == 0)
                    Paso = BLL.ArticulosBLL.Guardar(articulos);
                else

                    Paso = BLL.ArticulosBLL.Editar(articulos);

                if (Paso)
                {
                    MessageBox.Show("Guardar", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No Pudo Guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                GeneralerrorProvider.Clear();
                Limpiar();
            }

        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                MessageBox.Show("Favor Llenar Casilla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                int id = Convert.ToInt32(articuloIdNumericUpDown.Value);
                Articulos articulos = BLL.ArticulosBLL.Buscar(id);

                if (articulos != null)
                {
                    articuloIdNumericUpDown.Value = articulos.ArticuloId;
                    nombreTextBox.Text = articulos.Nombre;
                    fechaDateTimePicker.Value = articulos.Fecha;
                    descripcionTextBox.Text = articulos.Descripcion;
                    cantidadNumericUpDown.Value = articulos.Cantidad;
                    precioTextBox.Text = articulos.Precio.ToString();
                    
                   
                }
                else
                {
                    MessageBox.Show("No fue Encontrado", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  
                }
                GeneralerrorProvider.Clear();
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (ValidarEliminar())
            {
                MessageBox.Show("Favor Llenar Casilla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                int id = Convert.ToInt32(articuloIdNumericUpDown.Value);

                if (BLL.ArticulosBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No fue Eliminado", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Limpiar();
                GeneralerrorProvider.Clear();
            }
        }

        public void Limpiar()
        {
            articuloIdNumericUpDown.Value = 0;
            nombreTextBox.Clear();
            fechaDateTimePicker.Value = DateTime.Now;
            descripcionTextBox.Clear();
            cantidadNumericUpDown.Value = 0;
            precioTextBox.Clear();
            GeneralerrorProvider.Clear();

           
        }

        private bool Validar()
        {
            bool error = false;
            if (articuloIdNumericUpDown.Value == 0)
            {
                GeneralerrorProvider.SetError(articuloIdNumericUpDown, "Llenar Casilla Persona ID");
                error = true;
            }

            return error;
        }
        //

        public bool ValidarEliminar()
        {
            bool Error = false;

            if (articuloIdNumericUpDown.Value == 0)
            {
                GeneralerrorProvider.SetError(articuloIdNumericUpDown, "Llenar Casilla Persona ID");
                Error = true;
            }
            return Error;
        }

        public bool ValidarGuardar()
        {
            bool Error = false;

            if (String.IsNullOrEmpty(nombreTextBox.Text))
            {
                GeneralerrorProvider.SetError(nombreTextBox, "Llenar Casilla de Nombre");
                Error = true;
            }


            if (String.IsNullOrEmpty(descripcionTextBox.Text))
            {
                GeneralerrorProvider.SetError(descripcionTextBox, "Llenar Casilla de Direccion");
                Error = true;
            }
           

            if(cantidadNumericUpDown.Value ==0)
            {
                GeneralerrorProvider.SetError(cantidadNumericUpDown, "Llenar Casilla de Cantidad");
                Error = true;
            }


            if (String.IsNullOrEmpty(precioTextBox.Text))
            {
                GeneralerrorProvider.SetError(precioTextBox, "Llenar Casilla de Cantidad");
                Error = true;
            }


            return Error;
        }
    }
}

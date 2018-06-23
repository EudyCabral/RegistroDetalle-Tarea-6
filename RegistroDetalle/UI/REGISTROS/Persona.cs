using RegistroDetalle.BLL;
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
    public partial class Persona : Form
    {
        public Persona()
        {
            InitializeComponent();
        }
        private Personas Llenaclase()
        {
            Personas personas = new Personas();

            personas.PersonaId = Convert.ToInt32(personaIdNumericUpDown.Value);
            personas.Nombres = nombresTextBox.Text;
            personas.Fecha = fechaDateTimePicker.Value;
            personas.Cedula = cedulaMaskedTextBox.Text;
            personas.Direccion = direccionTextBox.Text;
            personas.Telefono = telefonoMaskedTextBox.Text;
            
            return personas;
        }
        private void Guardarbutton_Click(object sender, EventArgs e)
        {
          
            bool Paso = false;
            Personas personas = Llenaclase();

            if (Validar())
            {
                MessageBox.Show("Favor Llenar Casilla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (personaIdNumericUpDown.Value == 0)
                    Paso = BLL.PersonasBLL.Guardar(personas);
                else

                    Paso = BLL.PersonasBLL.Editar(personas);

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

            if (ValidarBE())
            {
                MessageBox.Show("Favor Llenar Casilla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
               
                int id = Convert.ToInt32(personaIdNumericUpDown.Value);
                Personas personas = BLL.PersonasBLL.Buscar(id);

                if (personas != null)
                {
                    personaIdNumericUpDown.Value = personas.PersonaId;
                    nombresTextBox.Text = personas.Nombres;
                    fechaDateTimePicker.Value = personas.Fecha;
                    cedulaMaskedTextBox.Text = personas.Cedula;
                    direccionTextBox.Text = personas.Direccion;
                    telefonoMaskedTextBox.Text = personas.Telefono;
                    GeneralerrorProvider.Clear();
                }
                else
                {
                    MessageBox.Show("No fue Encontrado", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GeneralerrorProvider.Clear();
                }
            }
           
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (ValidarBE())
            {
                MessageBox.Show("Favor Llenar Casilla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                int id = Convert.ToInt32(personaIdNumericUpDown.Value);

                if (BLL.PersonasBLL.Eliminar(id))
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

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public void Limpiar()
        {
            personaIdNumericUpDown.Value = 0;
            nombresTextBox.Clear();
            fechaDateTimePicker.Value = DateTime.Now;
            cedulaMaskedTextBox.Clear();
            direccionTextBox.Clear();
            telefonoMaskedTextBox.Clear();
            GeneralerrorProvider.Clear();
        }


        public bool ValidarBE()
        {
            bool Error = false;

            if (personaIdNumericUpDown.Value == 0)
            {
                GeneralerrorProvider.SetError(personaIdNumericUpDown, "Llenar Casilla Persona ID");
                Error = true;
            }
            return Error;
        }

            public bool Validar()
        {
            bool Error = false;

          

            if (String.IsNullOrWhiteSpace(nombresTextBox.Text))
            {
                GeneralerrorProvider.SetError(nombresTextBox, "Llenar Casilla de Nombre");
                Error = true;
            }

            if (String.IsNullOrWhiteSpace(telefonoMaskedTextBox.Text))
            {
                GeneralerrorProvider.SetError(telefonoMaskedTextBox, "Llenar Casilla de Telefono");
                Error = true;
            }

            if (String.IsNullOrWhiteSpace(cedulaMaskedTextBox.Text))
            {
                GeneralerrorProvider.SetError(cedulaMaskedTextBox, "Llenar Casilla de Nombre");
                Error = true;
            }

            if (String.IsNullOrWhiteSpace(direccionTextBox.Text) )
                {
                    GeneralerrorProvider.SetError(direccionTextBox, "Llenar Casilla de Direccion");
                    Error = true;
                }
            
           
            return Error;
        }

        private void Persona_Load(object sender, EventArgs e)
        {

        }
    }
}

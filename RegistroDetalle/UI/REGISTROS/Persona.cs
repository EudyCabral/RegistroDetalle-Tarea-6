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
            if (personaIdNumericUpDown.Value == 0)
                Paso = BLL.PersonasBLL.Guardar(personas);
            else
               
                Paso = BLL.PersonasBLL.Editar(personas);

            if(Paso)
            {
                MessageBox.Show("Guardar", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No Pudo Guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(personaIdNumericUpDown.Value);
            Personas personas = BLL.PersonasBLL.Buscar(id);

            if(personas != null)
            {
                personaIdNumericUpDown.Value=personas.PersonaId ;
                nombresTextBox.Text = personas.Nombres ;
                fechaDateTimePicker.Value = personas.Fecha;
                cedulaMaskedTextBox.Text = personas.Cedula;
                direccionTextBox.Text = personas.Direccion;
                telefonoMaskedTextBox.Text = personas.Telefono;

            }
            else
            {
                MessageBox.Show("No fue Encontrado", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(personaIdNumericUpDown.Value);

            if(BLL.PersonasBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            MessageBox.Show("No fue Eliminado", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            personaIdNumericUpDown.Value = 0;
            nombresTextBox.Clear();
            fechaDateTimePicker.Value = DateTime.Now;
            cedulaMaskedTextBox.Clear();
            direccionTextBox.Clear();
            telefonoMaskedTextBox.Clear();
        }

      
    }
}

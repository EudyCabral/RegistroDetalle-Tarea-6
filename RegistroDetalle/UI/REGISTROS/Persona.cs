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

        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {

        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {

        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {

        }

      
    }
}

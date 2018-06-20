using RegistroDetalle.UI.CONSULTAS;
using RegistroDetalle.UI.REGISTROS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegistroDetalle
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void personaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persona p = new Persona();
            p.Show();
        }

        private void articuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Articulo a = new Articulo();
            a.Show();
        }

        private void personaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CPersona cp = new CPersona();
            cp.Show();
        }
    }
}

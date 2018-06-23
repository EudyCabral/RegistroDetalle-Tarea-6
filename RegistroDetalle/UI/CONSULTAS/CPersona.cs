using RegistroDetalle.ENTIDADES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace RegistroDetalle.UI.CONSULTAS
{
    public partial class CPersona : Form
    {
        public CPersona()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            //Inicializando el filtro en True
            Expression<Func<Personas, bool>> filtro = x => true;

            int id;
            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0://ID

                    if (Validar(1))
                    {
                        MessageBox.Show("Favor Llenar Casilla ", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Validar(2))
                    {
                        MessageBox.Show("Debe Digitar un Numero!", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        id = Convert.ToInt32(CriteriotextBox.Text);
                        if (FechacheckBox.Checked == true)
                        {
                            filtro = x => x.PersonaId == id
                           & (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                        }
                        else
                        {
                            filtro = x => x.PersonaId == id;
                        }
                        if (BLL.PersonasBLL.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show("Este ID, No Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        GeneralerrorProvider.Clear();
                    }
                    break;

                case 1:// nombre

                    if (Validar(1))
                    {
                        MessageBox.Show("Favor Llenar Casilla ", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Validar(3))
                    {
                        MessageBox.Show("Debe Digitar Un Nombre!", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (FechacheckBox.Checked == true)
                        {
                            filtro = x => x.Nombres.Contains(CriteriotextBox.Text)
                            && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                        }
                        else
                        {
                            filtro = x => x.Nombres.Contains(CriteriotextBox.Text);
                        }
                        if (BLL.PersonasBLL.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show("Este Nombre, No Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        GeneralerrorProvider.Clear();
                    }
                    break;
                case 2:// cedula

                    if (Validar(1))
                    {
                        MessageBox.Show("Favor Llenar Casilla ", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (Validar(4))
                    {
                        MessageBox.Show("Debe usar los Guiones", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (FechacheckBox.Checked == true)
                        {
                            filtro = x => x.Cedula.Equals(CriteriotextBox.Text)
                            && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                        }
                        else
                        {
                            filtro = x => x.Cedula.Equals(CriteriotextBox.Text);
                        }
                        if (BLL.PersonasBLL.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show("Esta Cedula, No Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        GeneralerrorProvider.Clear();
                    }

                    break;
                case 3:// direccion

                    if (Validar(1))
                    {
                        MessageBox.Show("Favor Llenar Casilla ", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (Validar(3))
                    {
                        MessageBox.Show("Debe Escribir una Direccion", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (FechacheckBox.Checked == true)
                        {
                            filtro = x => x.Direccion.Contains(CriteriotextBox.Text)
                        && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);

                        }
                        else
                        {
                            filtro = x => x.Direccion.Contains(CriteriotextBox.Text);

                        }
                        if (BLL.PersonasBLL.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show("Esta Direccion, No Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        GeneralerrorProvider.Clear();
                    }


                    break;
                case 4://telefono
                    if (Validar(1))
                    {
                        MessageBox.Show("Favor Llenar Casilla ", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (Validar(4))
                    {
                        MessageBox.Show("Debe usar los Guiones", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (FechacheckBox.Checked == true)
                        {
                            filtro = x => x.Telefono.Equals(CriteriotextBox.Text)
                      && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                        }
                        else
                        {
                            filtro = x => x.Telefono.Equals(CriteriotextBox.Text);

                        }

                        if (BLL.PersonasBLL.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show("Este Telefono, No Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        GeneralerrorProvider.Clear();
                    }
                    break;

                case 5:
                    filtro = x => true;
                    if (BLL.PersonasBLL.GetList(filtro).Count() == 0)
                    {
                        MessageBox.Show("Base de datos Vacia", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    GeneralerrorProvider.Clear();
                    break;



            }


            ConsultadataGridView.DataSource = BLL.PersonasBLL.GetList(filtro);



            GeneralerrorProvider.Clear();
        }

        private bool Validar(int error)
        {
            bool paso = false;
            int num = 0;

            if (error == 1 && string.IsNullOrEmpty(CriteriotextBox.Text))
            {
                GeneralerrorProvider.SetError(CriteriotextBox, "Por Favor, LLenar Casilla!");
                paso = true;
            }
            if (error == 2 && int.TryParse(CriteriotextBox.Text, out num) == false)
            {
                GeneralerrorProvider.SetError(CriteriotextBox, "Debe Digitar un Numero");
                paso = true;
            }

            if (error == 3 && int.TryParse(CriteriotextBox.Text, out num) == true)
            {
                GeneralerrorProvider.SetError(CriteriotextBox, "Debe Digitar Caracteres");
                paso = true;
            }

            if (error == 4 && int.TryParse(CriteriotextBox.Text, out num) == true)
            {
                GeneralerrorProvider.SetError(CriteriotextBox, "Debe usar los Guiones");
                paso = true;
            }

            return paso;
        }

        private void CPersona_Load(object sender, EventArgs e)
        {

        }
    }
}

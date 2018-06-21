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
    public partial class CArticulos : Form
    {
        public CArticulos()
        {
            InitializeComponent();
        }

                

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            //Inicializando el filtro en True
            Expression<Func<Articulos, bool>> filtro = x => true;

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
                            filtro = x => x.ArticuloId == id
                           & (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                        }
                        else
                        {
                            filtro = x => x.ArticuloId == id;
                        }
                        if (BLL.ArticulosBLL.GetList(filtro).Count() == 0)
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
                            filtro = x => x.Nombre.Contains(CriteriotextBox.Text)
                            && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                        }
                        else
                        {
                            filtro = x => x.Nombre.Contains(CriteriotextBox.Text);
                        }
                        if (BLL.ArticulosBLL.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show("Este Nombre, No Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        GeneralerrorProvider.Clear();
                    }
                    break;
                case 2:// Descripcion

                    if (Validar(1))
                    {
                        MessageBox.Show("Favor Llenar Casilla ", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (Validar(3))
                    {
                        MessageBox.Show("Debe usar caracteres", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (FechacheckBox.Checked == true)
                        {
                            filtro = x => x.Descripcion.Contains(CriteriotextBox.Text)
                            && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                        }
                        else
                        {
                            filtro = x => x.Descripcion.Contains(CriteriotextBox.Text);
                        }
                        if (BLL.ArticulosBLL.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show("Esta Descripcion, No Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        GeneralerrorProvider.Clear();
                    }

                    break;
                case 3:// Cantidad

                    if (Validar(1))
                    {
                        MessageBox.Show("Favor Llenar Casilla ", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (Validar(2))
                    {
                        MessageBox.Show("Dijite Numeros", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        int cant = Convert.ToInt32(CriteriotextBox.Text);
                        if (FechacheckBox.Checked == true)
                        {
                            filtro = x => x.Cantidad == cant
                        && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);

                        }
                        else
                        {
                            filtro = x => x.Cantidad==cant;

                        }
                        if (BLL.ArticulosBLL.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show("Esta Cantidad, No Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        GeneralerrorProvider.Clear();
                    }

                    break;

                case 4:
                    filtro = x => true;
                    if (BLL.ArticulosBLL.GetList(filtro).Count() == 0)
                    {
                        MessageBox.Show("Base de datos Vacia", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    GeneralerrorProvider.Clear();
                    break;



            }


            ConsultadataGridView.DataSource = BLL.ArticulosBLL.GetList(filtro);



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

    }
}

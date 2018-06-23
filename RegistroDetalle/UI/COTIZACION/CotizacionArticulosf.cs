using RegistroDetalle.DAL;
using RegistroDetalle.ENTIDADES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegistroDetalle.UI.COTIZACION
{
    public partial class CotizacionArticulosf : Form
    {
        decimal importe = 0;
        public CotizacionArticulosf()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);
            return retorno;

        }


        private decimal ToDecimal(object valor)
        {
            decimal retorno = 0;
            decimal.TryParse(valor.ToString(), out retorno);
            return retorno;

        }
        private void LlenarComboBox()
        {
            Repositorio<Personas> repositorio = new Repositorio<Personas>(new Contexto());
            personaComboBox.DataSource = repositorio.GetList(c => true);
            personaComboBox.ValueMember = "PersonaId";
            personaComboBox.DisplayMember = "Nombres";

            Repositorio<Articulos> repositorioa = new Repositorio<Articulos>(new Contexto());
            articuloComboBox.DataSource = repositorioa.GetList(c => true);
            articuloComboBox.ValueMember = "ArticuloId";
            articuloComboBox.DisplayMember = "Nombre";
        }

        private CotizacionArticulos LlenaClase()
        {
            CotizacionArticulos cotizacionArticulos = new CotizacionArticulos();

            cotizacionArticulos.CotizacionArticulosId = Convert.ToInt32(cotizacionArticulosIdnumericUpDown.Value);
            cotizacionArticulos.Fecha = fechaDateTimePicker.Value;
            cotizacionArticulos.Observaciones = observacionesTextBox.Text;
           

            //Agregar cada linea del Grid al detalle
            foreach (DataGridViewRow item in detalledataGridView.Rows)
            {
                
                cotizacionArticulos.AgregarDetalle
                    (ToInt(item.Cells["id"].Value),
                    cotizacionArticulos.CotizacionArticulosId,
                      ToInt(item.Cells["PersonaId"].Value),
                      ToInt(item.Cells["ArticuloId"].Value),
                      Convert.ToString(item.Cells["Descripcion"].Value),
                       ToInt(item.Cells["Cantidad"].Value),
                    ToDecimal(item.Cells["Precio"].Value),
                    ToDecimal(item.Cells["Importe"].Value)
                   // Convert.ToString(item.Cells["articulos"].Value)



                  );
            }
            return cotizacionArticulos;
        }

        private void LlenarCampos(CotizacionArticulos cotizacionArticulos)
        {
            importe = 0;
            cotizacionArticulosIdnumericUpDown.Value = cotizacionArticulos.CotizacionArticulosId;
            fechaDateTimePicker.Value = cotizacionArticulos.Fecha;
            observacionesTextBox.Text = cotizacionArticulos.Observaciones;

            foreach (var item in cotizacionArticulos.Detalle)
            {
                importe += item.Importe;
            }
            TotaltextBox.Text = importe.ToString();
            //Cargar el detalle al Grid
            detalledataGridView.DataSource = cotizacionArticulos.Detalle;

            //Ocultar columnas
            detalledataGridView.Columns["Id"].Visible = false;
            detalledataGridView.Columns["PersonaId"].Visible = false;
            detalledataGridView.Columns["CotizacionArticulosId"].Visible = false;
            detalledataGridView.Columns["articulos"].Visible = false;




        }


        private void Buscarbutton_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(cotizacionArticulosIdnumericUpDown.Value);
            CotizacionArticulos cotizacionArticulos = BLL.CotizacionArticulosBLL.Buscar(id);

            if (cotizacionArticulos != null)
            {
                LlenarCampos(cotizacionArticulos);
                
            }
            else
                MessageBox.Show("No se encontro!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Removerbutton_Click(object sender, EventArgs e)
        {
            if (detalledataGridView.Rows.Count > 0
               && detalledataGridView.CurrentRow != null)
            {
                //convertir el grid en la lista
                List<CotizacionArticulosDetalle> detalle = (List<CotizacionArticulosDetalle>)detalledataGridView.DataSource;

                //remover la fila

                detalle.RemoveAt(detalledataGridView.CurrentRow.Index);

                // Cargar el detalle al Grid
                detalledataGridView.DataSource = null;
                detalledataGridView.DataSource = detalle;
            }
        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            List<CotizacionArticulosDetalle> detalle = new List<CotizacionArticulosDetalle>();
            CotizacionArticulos cotizacionArticulos = new CotizacionArticulos();

            if (detalledataGridView.DataSource != null)
            {
                cotizacionArticulos.Detalle = (List<CotizacionArticulosDetalle>)detalledataGridView.DataSource;
            }

            //Agregar un nuevo detalle con los datos introducidos.
            cotizacionArticulos.Detalle.Add(
                new CotizacionArticulosDetalle(
                    id: 0,
                   personaId: (int)personaComboBox.SelectedValue,
                   cotizacionArticulosId: (int)Convert.ToInt32(cotizacionArticulosIdnumericUpDown.Value),
                    articuloId: (int)articuloComboBox.SelectedValue,
                     descripcion: (string)BLL.ArticulosBLL.RetornarDescripcion(articuloComboBox.Text),
                    cantidad: (int)Convert.ToInt32(cantidadnumericUpDown.Value),
                    precio: (decimal)Convert.ToDecimal(precioTextBox.Text),
                    importe: (decimal)Convert.ToDecimal(importeTextBox.Text)
                    //Articulo: new Articulos(articuloComboBox.Text)
                ));

            //Cargar el detalle al Grid
            detalledataGridView.DataSource = null;
            detalledataGridView.DataSource = cotizacionArticulos.Detalle;

            
            importe += BLL.CotizacionArticulosBLL.CalcularImporte(Convert.ToDecimal(precioTextBox.Text), Convert.ToInt32(cantidadnumericUpDown.Value));
            



            TotaltextBox.Text = importe.ToString();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            CotizacionArticulos cotizacionArticulos = LlenaClase();
            bool Paso = false;

            /*  if (HayErrores())
              {
                  MessageBox.Show("Favor revisar todos los campos", "Validación",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                  return;
              }*/



            //Determinar si es Guardar o Modificar
            if (cotizacionArticulosIdnumericUpDown.Value == 0)
                Paso = BLL.CotizacionArticulosBLL.Guardar(cotizacionArticulos);
            else
            {
                //todo: validar que exista.
                Paso = BLL.CotizacionArticulosBLL.Editar(cotizacionArticulos);


                //Esto es para en caso de que se elimine algun elemento del datagrid y se modifique que elimine el detalle 


            }



            //Informar el resultado
            if (Paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se pudo guardar!!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(cotizacionArticulosIdnumericUpDown.Value);

            //todo: validar que exista
            if (BLL.CotizacionArticulosBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
                MessageBox.Show("No se pudo eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();

        }

        public void Limpiar()
        {
            cotizacionArticulosIdnumericUpDown.Value = 0;
            fechaDateTimePicker.Value = DateTime.Now;
            observacionesTextBox.Clear();
            TotaltextBox.Clear();
            cantidadnumericUpDown.Value = 0;
            importeTextBox.Clear();
            detalledataGridView.DataSource = null;
            //  MyerrorProvider.Clear();
        }

        private void CotizacionArticulosf_Load(object sender, EventArgs e)
        {

        }

        private void personaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void articuloComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (var item in BLL.ArticulosBLL.GetList(x => x.Nombre == articuloComboBox.Text))
            {
                precioTextBox.Text = item.Precio.ToString();



            }

        }



        private void precioTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void cantidadnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            decimal precio = Convert.ToDecimal(precioTextBox.Text);
            int cantidad = Convert.ToInt32(cantidadnumericUpDown.Value);


            importeTextBox.Text = BLL.CotizacionArticulosBLL.CalcularImporte(precio, cantidad).ToString();

        }

        private void importeTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

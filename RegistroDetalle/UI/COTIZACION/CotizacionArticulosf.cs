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
            personaComboBox.DisplayMember = "Nombre";

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
                    (
                      ToInt(item.Cells["Id"].Value),
                      ToInt(item.Cells["CotizacionArticulosId"].Value),
                      ToInt(item.Cells["PersonaId"].Value),
                      ToInt(item.Cells["ArticuloId"].Value),
                       ToInt(item.Cells[" Cantidad"].Value),
                    ToDecimal(item.Cells["Precio"].Value),
                    ToDecimal(item.Cells["Importe"].Value)

              
        
                  );
            }
            return cotizacionArticulos;
        }

        private void LlenarCampos(CotizacionArticulos cotizacionArticulos)
        {
            cotizacionArticulosIdnumericUpDown.Value = cotizacionArticulos.CotizacionArticulosId;
            fechaDateTimePicker.Value = cotizacionArticulos.Fecha;
            observacionesTextBox.Text = cotizacionArticulos.Observaciones;

            //Cargar el detalle al Grid
            detalledataGridView.DataSource = cotizacionArticulos.Detalle;

            //Ocultar columnas
            detalledataGridView.Columns["Id"].Visible = false;
            detalledataGridView.Columns["ArticuloId"].Visible = true;
            detalledataGridView.Columns["PersonaId"].Visible = false;
            detalledataGridView.Columns["CotizacionArticulosId"].Visible = false;
            


        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(cotizacionArticulosIdnumericUpDown.Value);
            CotizacionArticulos cotizacionArticulos = BLL.CotizacionArticulosBLL.Buscar(id);

            if ( cotizacionArticulos != null)
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

            if (detalledataGridView.DataSource != null)
            {
                detalle = (List<CotizacionArticulosDetalle>)detalledataGridView.DataSource;
            }

            //Agregar un nuevo detalle con los datos introducidos.
            detalle.Add(
                new CotizacionArticulosDetalle(
                   
                    articuloId: (int)articuloComboBox.SelectedValue,
                     descripcion: (string)articuloComboBox.Text,
                    cantidad: (int)Convert.ToInt32(cantidadTextBox.Text),
                    precio: (int)Convert.ToInt32(precioTextBox.Text),
                    importe: (int)Convert.ToInt32(importeTextBox.Text)
                ));

            //Cargar el detalle al Grid
            detalledataGridView.DataSource = null;
            detalledataGridView.DataSource = detalle;
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
            
            foreach (var item in BLL.ArticulosBLL.GetList(x => x.Descripcion == articuloComboBox.Text))
            {
                precioTextBox.Text = item.Precio.ToString();
                


            }

        }

        private void cantidadTextBox_TextChanged(object sender, EventArgs e)
        {
            decimal precio = Convert.ToDecimal(precioTextBox.Text);
            int cantidad = Convert.ToInt32(cantidadTextBox.Text);
            decimal resultado = BLL.CotizacionArticulosBLL.CalcularImporte(precio, cantidad);

            importeTextBox.Text = Convert.ToString(resultado.ToString());
        }
    }
}

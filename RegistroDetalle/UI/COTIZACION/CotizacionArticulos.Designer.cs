namespace RegistroDetalle.UI.COTIZACION
{
    partial class CotizacionArticulos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label cotizacionArticulosIdLabel;
            System.Windows.Forms.Label fechaLabel;
            System.Windows.Forms.Label observacionesLabel;
            System.Windows.Forms.Label personaIdLabel;
            System.Windows.Forms.Label articuloIdLabel;
            System.Windows.Forms.Label cantidadLabel;
            System.Windows.Forms.Label precioLabel;
            System.Windows.Forms.Label importeLabel;
            this.fechaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.observacionesTextBox = new System.Windows.Forms.TextBox();
            this.personaComboBox = new System.Windows.Forms.ComboBox();
            this.articuloComboBox = new System.Windows.Forms.ComboBox();
            this.cantidadTextBox = new System.Windows.Forms.TextBox();
            this.precioTextBox = new System.Windows.Forms.TextBox();
            this.importeTextBox = new System.Windows.Forms.TextBox();
            this.Agregarbutton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Nuevobutton = new System.Windows.Forms.Button();
            this.Guardarbutton = new System.Windows.Forms.Button();
            this.Eliminarbutton = new System.Windows.Forms.Button();
            this.Buscarbutton = new System.Windows.Forms.Button();
            this.cotizacionArticulosIdnumericUpDown = new System.Windows.Forms.NumericUpDown();
            cotizacionArticulosIdLabel = new System.Windows.Forms.Label();
            fechaLabel = new System.Windows.Forms.Label();
            observacionesLabel = new System.Windows.Forms.Label();
            personaIdLabel = new System.Windows.Forms.Label();
            articuloIdLabel = new System.Windows.Forms.Label();
            cantidadLabel = new System.Windows.Forms.Label();
            precioLabel = new System.Windows.Forms.Label();
            importeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cotizacionArticulosIdnumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // cotizacionArticulosIdLabel
            // 
            cotizacionArticulosIdLabel.AutoSize = true;
            cotizacionArticulosIdLabel.Location = new System.Drawing.Point(12, 17);
            cotizacionArticulosIdLabel.Name = "cotizacionArticulosIdLabel";
            cotizacionArticulosIdLabel.Size = new System.Drawing.Size(114, 13);
            cotizacionArticulosIdLabel.TabIndex = 1;
            cotizacionArticulosIdLabel.Text = "Cotizacion Articulos Id:";
            // 
            // fechaLabel
            // 
            fechaLabel.AutoSize = true;
            fechaLabel.Location = new System.Drawing.Point(416, 15);
            fechaLabel.Name = "fechaLabel";
            fechaLabel.Size = new System.Drawing.Size(40, 13);
            fechaLabel.TabIndex = 3;
            fechaLabel.Text = "Fecha:";
            // 
            // fechaDateTimePicker
            // 
            this.fechaDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaDateTimePicker.Location = new System.Drawing.Point(462, 11);
            this.fechaDateTimePicker.Name = "fechaDateTimePicker";
            this.fechaDateTimePicker.Size = new System.Drawing.Size(106, 20);
            this.fechaDateTimePicker.TabIndex = 4;
            // 
            // observacionesLabel
            // 
            observacionesLabel.AutoSize = true;
            observacionesLabel.Location = new System.Drawing.Point(9, 397);
            observacionesLabel.Name = "observacionesLabel";
            observacionesLabel.Size = new System.Drawing.Size(81, 13);
            observacionesLabel.TabIndex = 5;
            observacionesLabel.Text = "Observaciones:";
            observacionesLabel.Click += new System.EventHandler(this.observacionesLabel_Click);
            // 
            // observacionesTextBox
            // 
            this.observacionesTextBox.Location = new System.Drawing.Point(12, 413);
            this.observacionesTextBox.Multiline = true;
            this.observacionesTextBox.Name = "observacionesTextBox";
            this.observacionesTextBox.Size = new System.Drawing.Size(189, 61);
            this.observacionesTextBox.TabIndex = 6;
            // 
            // personaIdLabel
            // 
            personaIdLabel.AutoSize = true;
            personaIdLabel.Location = new System.Drawing.Point(12, 75);
            personaIdLabel.Name = "personaIdLabel";
            personaIdLabel.Size = new System.Drawing.Size(52, 13);
            personaIdLabel.TabIndex = 7;
            personaIdLabel.Text = "Persona :";
            // 
            // personaComboBox
            // 
            this.personaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.personaComboBox.FormattingEnabled = true;
            this.personaComboBox.Location = new System.Drawing.Point(65, 72);
            this.personaComboBox.Name = "personaComboBox";
            this.personaComboBox.Size = new System.Drawing.Size(207, 21);
            this.personaComboBox.TabIndex = 8;
            // 
            // articuloIdLabel
            // 
            articuloIdLabel.AutoSize = true;
            articuloIdLabel.Location = new System.Drawing.Point(47, 118);
            articuloIdLabel.Name = "articuloIdLabel";
            articuloIdLabel.Size = new System.Drawing.Size(45, 13);
            articuloIdLabel.TabIndex = 9;
            articuloIdLabel.Text = "Articulo ";
            articuloIdLabel.Click += new System.EventHandler(this.articuloIdLabel_Click);
            // 
            // articuloComboBox
            // 
            this.articuloComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.articuloComboBox.FormattingEnabled = true;
            this.articuloComboBox.Location = new System.Drawing.Point(12, 134);
            this.articuloComboBox.Name = "articuloComboBox";
            this.articuloComboBox.Size = new System.Drawing.Size(121, 21);
            this.articuloComboBox.TabIndex = 10;
            // 
            // cantidadLabel
            // 
            cantidadLabel.AutoSize = true;
            cantidadLabel.Location = new System.Drawing.Point(191, 118);
            cantidadLabel.Name = "cantidadLabel";
            cantidadLabel.Size = new System.Drawing.Size(49, 13);
            cantidadLabel.TabIndex = 11;
            cantidadLabel.Text = "Cantidad";
            // 
            // cantidadTextBox
            // 
            this.cantidadTextBox.Location = new System.Drawing.Point(168, 135);
            this.cantidadTextBox.Name = "cantidadTextBox";
            this.cantidadTextBox.Size = new System.Drawing.Size(100, 20);
            this.cantidadTextBox.TabIndex = 12;
            // 
            // precioLabel
            // 
            precioLabel.AutoSize = true;
            precioLabel.Location = new System.Drawing.Point(326, 118);
            precioLabel.Name = "precioLabel";
            precioLabel.Size = new System.Drawing.Size(37, 13);
            precioLabel.TabIndex = 13;
            precioLabel.Text = "Precio";
            precioLabel.Click += new System.EventHandler(this.precioLabel_Click);
            // 
            // precioTextBox
            // 
            this.precioTextBox.Location = new System.Drawing.Point(299, 135);
            this.precioTextBox.Name = "precioTextBox";
            this.precioTextBox.Size = new System.Drawing.Size(100, 20);
            this.precioTextBox.TabIndex = 14;
            // 
            // importeLabel
            // 
            importeLabel.AutoSize = true;
            importeLabel.Location = new System.Drawing.Point(455, 118);
            importeLabel.Name = "importeLabel";
            importeLabel.Size = new System.Drawing.Size(42, 13);
            importeLabel.TabIndex = 15;
            importeLabel.Text = "Importe";
            importeLabel.Click += new System.EventHandler(this.importeLabel_Click);
            // 
            // importeTextBox
            // 
            this.importeTextBox.Location = new System.Drawing.Point(428, 134);
            this.importeTextBox.Name = "importeTextBox";
            this.importeTextBox.Size = new System.Drawing.Size(100, 20);
            this.importeTextBox.TabIndex = 16;
            // 
            // Agregarbutton
            // 
            this.Agregarbutton.Location = new System.Drawing.Point(534, 131);
            this.Agregarbutton.Name = "Agregarbutton";
            this.Agregarbutton.Size = new System.Drawing.Size(75, 23);
            this.Agregarbutton.TabIndex = 17;
            this.Agregarbutton.Text = "Agregar";
            this.Agregarbutton.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 161);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(597, 233);
            this.dataGridView1.TabIndex = 18;
            // 
            // Nuevobutton
            // 
            this.Nuevobutton.Location = new System.Drawing.Point(219, 433);
            this.Nuevobutton.Name = "Nuevobutton";
            this.Nuevobutton.Size = new System.Drawing.Size(75, 23);
            this.Nuevobutton.TabIndex = 19;
            this.Nuevobutton.Text = "Nuevo";
            this.Nuevobutton.UseVisualStyleBackColor = true;
            // 
            // Guardarbutton
            // 
            this.Guardarbutton.Location = new System.Drawing.Point(329, 433);
            this.Guardarbutton.Name = "Guardarbutton";
            this.Guardarbutton.Size = new System.Drawing.Size(75, 23);
            this.Guardarbutton.TabIndex = 20;
            this.Guardarbutton.Text = "Guardar";
            this.Guardarbutton.UseVisualStyleBackColor = true;
            // 
            // Eliminarbutton
            // 
            this.Eliminarbutton.Location = new System.Drawing.Point(462, 433);
            this.Eliminarbutton.Name = "Eliminarbutton";
            this.Eliminarbutton.Size = new System.Drawing.Size(75, 23);
            this.Eliminarbutton.TabIndex = 21;
            this.Eliminarbutton.Text = "Eliminar";
            this.Eliminarbutton.UseVisualStyleBackColor = true;
            // 
            // Buscarbutton
            // 
            this.Buscarbutton.Location = new System.Drawing.Point(247, 12);
            this.Buscarbutton.Name = "Buscarbutton";
            this.Buscarbutton.Size = new System.Drawing.Size(75, 23);
            this.Buscarbutton.TabIndex = 22;
            this.Buscarbutton.Text = "Buscar";
            this.Buscarbutton.UseVisualStyleBackColor = true;
            // 
            // cotizacionArticulosIdnumericUpDown
            // 
            this.cotizacionArticulosIdnumericUpDown.Location = new System.Drawing.Point(121, 15);
            this.cotizacionArticulosIdnumericUpDown.Name = "cotizacionArticulosIdnumericUpDown";
            this.cotizacionArticulosIdnumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.cotizacionArticulosIdnumericUpDown.TabIndex = 23;
            // 
            // CotizacionArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 506);
            this.Controls.Add(this.cotizacionArticulosIdnumericUpDown);
            this.Controls.Add(this.Buscarbutton);
            this.Controls.Add(this.Eliminarbutton);
            this.Controls.Add(this.Guardarbutton);
            this.Controls.Add(this.Nuevobutton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Agregarbutton);
            this.Controls.Add(importeLabel);
            this.Controls.Add(this.importeTextBox);
            this.Controls.Add(precioLabel);
            this.Controls.Add(this.precioTextBox);
            this.Controls.Add(cantidadLabel);
            this.Controls.Add(this.cantidadTextBox);
            this.Controls.Add(articuloIdLabel);
            this.Controls.Add(this.articuloComboBox);
            this.Controls.Add(personaIdLabel);
            this.Controls.Add(this.personaComboBox);
            this.Controls.Add(observacionesLabel);
            this.Controls.Add(this.observacionesTextBox);
            this.Controls.Add(fechaLabel);
            this.Controls.Add(this.fechaDateTimePicker);
            this.Controls.Add(cotizacionArticulosIdLabel);
            this.Name = "CotizacionArticulos";
            this.Text = "Cotizacion de Articulos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cotizacionArticulosIdnumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker fechaDateTimePicker;
        private System.Windows.Forms.TextBox observacionesTextBox;
        private System.Windows.Forms.ComboBox personaComboBox;
        private System.Windows.Forms.ComboBox articuloComboBox;
        private System.Windows.Forms.TextBox cantidadTextBox;
        private System.Windows.Forms.TextBox precioTextBox;
        private System.Windows.Forms.TextBox importeTextBox;
        private System.Windows.Forms.Button Agregarbutton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Nuevobutton;
        private System.Windows.Forms.Button Guardarbutton;
        private System.Windows.Forms.Button Eliminarbutton;
        private System.Windows.Forms.Button Buscarbutton;
        private System.Windows.Forms.NumericUpDown cotizacionArticulosIdnumericUpDown;
    }
}
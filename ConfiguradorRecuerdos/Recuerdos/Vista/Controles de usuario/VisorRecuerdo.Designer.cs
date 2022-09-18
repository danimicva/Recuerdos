namespace Recuerdos.Vista.Controles_de_usuario
{
    partial class VisorRecuerdo
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.gbDetalles = new System.Windows.Forms.GroupBox();
            this.selectorFecha = new Recuerdos.Vista.Controles_de_usuario.SelectorFecha();
            this.lblFecha = new System.Windows.Forms.Label();
            this.btnDeshacer = new System.Windows.Forms.Button();
            this.tbDetallesDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.tbDetallesFuente = new System.Windows.Forms.TextBox();
            this.lblFuente = new System.Windows.Forms.Label();
            this.btnDetallesQuitarEvento = new System.Windows.Forms.Button();
            this.btnDetallesNuevoEvento = new System.Windows.Forms.Button();
            this.cbDetallesEvento = new System.Windows.Forms.ComboBox();
            this.lblDetallesEvento = new System.Windows.Forms.Label();
            this.tbDetallesLugar = new System.Windows.Forms.TextBox();
            this.lblDetallesLugar = new System.Windows.Forms.Label();
            this.lblDetallesRuta = new System.Windows.Forms.Label();
            this.pbFotoElegida = new System.Windows.Forms.PictureBox();
            this.gbDetalles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoElegida)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDetalles
            // 
            this.gbDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDetalles.Controls.Add(this.selectorFecha);
            this.gbDetalles.Controls.Add(this.lblFecha);
            this.gbDetalles.Controls.Add(this.btnDeshacer);
            this.gbDetalles.Controls.Add(this.tbDetallesDescripcion);
            this.gbDetalles.Controls.Add(this.lblDescripcion);
            this.gbDetalles.Controls.Add(this.btnGuardar);
            this.gbDetalles.Controls.Add(this.tbDetallesFuente);
            this.gbDetalles.Controls.Add(this.lblFuente);
            this.gbDetalles.Controls.Add(this.btnDetallesQuitarEvento);
            this.gbDetalles.Controls.Add(this.btnDetallesNuevoEvento);
            this.gbDetalles.Controls.Add(this.cbDetallesEvento);
            this.gbDetalles.Controls.Add(this.lblDetallesEvento);
            this.gbDetalles.Controls.Add(this.tbDetallesLugar);
            this.gbDetalles.Controls.Add(this.lblDetallesLugar);
            this.gbDetalles.Controls.Add(this.lblDetallesRuta);
            this.gbDetalles.Location = new System.Drawing.Point(0, 0);
            this.gbDetalles.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbDetalles.Name = "gbDetalles";
            this.gbDetalles.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbDetalles.Size = new System.Drawing.Size(777, 180);
            this.gbDetalles.TabIndex = 3;
            this.gbDetalles.TabStop = false;
            this.gbDetalles.Text = "Detalles";
            // 
            // selectorFecha
            // 
            this.selectorFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectorFecha.Fecha = null;
            this.selectorFecha.Location = new System.Drawing.Point(456, 115);
            this.selectorFecha.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.selectorFecha.MinimumSize = new System.Drawing.Size(310, 62);
            this.selectorFecha.Name = "selectorFecha";
            this.selectorFecha.Size = new System.Drawing.Size(310, 62);
            this.selectorFecha.TabIndex = 14;
            // 
            // lblFecha
            // 
            this.lblFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(380, 115);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(41, 15);
            this.lblFecha.TabIndex = 13;
            this.lblFecha.Text = "Fecha:";
            // 
            // btnDeshacer
            // 
            this.btnDeshacer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeshacer.Location = new System.Drawing.Point(4, 147);
            this.btnDeshacer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDeshacer.Name = "btnDeshacer";
            this.btnDeshacer.Size = new System.Drawing.Size(124, 27);
            this.btnDeshacer.TabIndex = 7;
            this.btnDeshacer.Text = "Deshacer";
            this.btnDeshacer.UseVisualStyleBackColor = true;
            this.btnDeshacer.Click += new System.EventHandler(this.btnDeshacer_Click);
            // 
            // tbDetallesDescripcion
            // 
            this.tbDetallesDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDetallesDescripcion.Location = new System.Drawing.Point(456, 52);
            this.tbDetallesDescripcion.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbDetallesDescripcion.Multiline = true;
            this.tbDetallesDescripcion.Name = "tbDetallesDescripcion";
            this.tbDetallesDescripcion.Size = new System.Drawing.Size(314, 54);
            this.tbDetallesDescripcion.TabIndex = 11;
            this.tbDetallesDescripcion.TextChanged += new System.EventHandler(this.tbCualquiera_TextChanged);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(380, 52);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(72, 15);
            this.lblDescripcion.TabIndex = 10;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardar.Location = new System.Drawing.Point(136, 147);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(124, 27);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // tbDetallesFuente
            // 
            this.tbDetallesFuente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDetallesFuente.Location = new System.Drawing.Point(456, 19);
            this.tbDetallesFuente.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbDetallesFuente.Name = "tbDetallesFuente";
            this.tbDetallesFuente.Size = new System.Drawing.Size(314, 23);
            this.tbDetallesFuente.TabIndex = 9;
            this.tbDetallesFuente.TextChanged += new System.EventHandler(this.tbCualquiera_TextChanged);
            // 
            // lblFuente
            // 
            this.lblFuente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFuente.AutoSize = true;
            this.lblFuente.Location = new System.Drawing.Point(380, 23);
            this.lblFuente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFuente.Name = "lblFuente";
            this.lblFuente.Size = new System.Drawing.Size(46, 15);
            this.lblFuente.TabIndex = 8;
            this.lblFuente.Text = "Fuente:";
            // 
            // btnDetallesQuitarEvento
            // 
            this.btnDetallesQuitarEvento.Location = new System.Drawing.Point(325, 79);
            this.btnDetallesQuitarEvento.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDetallesQuitarEvento.Name = "btnDetallesQuitarEvento";
            this.btnDetallesQuitarEvento.Size = new System.Drawing.Size(24, 27);
            this.btnDetallesQuitarEvento.TabIndex = 7;
            this.btnDetallesQuitarEvento.Text = "X";
            this.btnDetallesQuitarEvento.UseVisualStyleBackColor = true;
            this.btnDetallesQuitarEvento.Click += new System.EventHandler(this.btnQuitarEvento_Click);
            // 
            // btnDetallesNuevoEvento
            // 
            this.btnDetallesNuevoEvento.Location = new System.Drawing.Point(354, 79);
            this.btnDetallesNuevoEvento.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDetallesNuevoEvento.Name = "btnDetallesNuevoEvento";
            this.btnDetallesNuevoEvento.Size = new System.Drawing.Size(21, 27);
            this.btnDetallesNuevoEvento.TabIndex = 6;
            this.btnDetallesNuevoEvento.Text = "+";
            this.btnDetallesNuevoEvento.UseVisualStyleBackColor = true;
            this.btnDetallesNuevoEvento.Click += new System.EventHandler(this.btnDetallesNuevoEvento_Click);
            // 
            // cbDetallesEvento
            // 
            this.cbDetallesEvento.FormattingEnabled = true;
            this.cbDetallesEvento.Location = new System.Drawing.Point(61, 82);
            this.cbDetallesEvento.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbDetallesEvento.Name = "cbDetallesEvento";
            this.cbDetallesEvento.Size = new System.Drawing.Size(256, 23);
            this.cbDetallesEvento.TabIndex = 5;
            this.cbDetallesEvento.SelectedIndexChanged += new System.EventHandler(this.cbDetallesEvento_SelectedIndexChanged);
            // 
            // lblDetallesEvento
            // 
            this.lblDetallesEvento.AutoSize = true;
            this.lblDetallesEvento.Location = new System.Drawing.Point(11, 85);
            this.lblDetallesEvento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDetallesEvento.Name = "lblDetallesEvento";
            this.lblDetallesEvento.Size = new System.Drawing.Size(46, 15);
            this.lblDetallesEvento.TabIndex = 4;
            this.lblDetallesEvento.Text = "Evento:";
            // 
            // tbDetallesLugar
            // 
            this.tbDetallesLugar.Location = new System.Drawing.Point(61, 52);
            this.tbDetallesLugar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbDetallesLugar.Name = "tbDetallesLugar";
            this.tbDetallesLugar.Size = new System.Drawing.Size(314, 23);
            this.tbDetallesLugar.TabIndex = 3;
            this.tbDetallesLugar.TextChanged += new System.EventHandler(this.tbCualquiera_TextChanged);
            // 
            // lblDetallesLugar
            // 
            this.lblDetallesLugar.AutoSize = true;
            this.lblDetallesLugar.Location = new System.Drawing.Point(11, 55);
            this.lblDetallesLugar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDetallesLugar.Name = "lblDetallesLugar";
            this.lblDetallesLugar.Size = new System.Drawing.Size(40, 15);
            this.lblDetallesLugar.TabIndex = 2;
            this.lblDetallesLugar.Text = "Lugar:";
            // 
            // lblDetallesRuta
            // 
            this.lblDetallesRuta.Location = new System.Drawing.Point(9, 23);
            this.lblDetallesRuta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDetallesRuta.MaximumSize = new System.Drawing.Size(366, 15);
            this.lblDetallesRuta.MinimumSize = new System.Drawing.Size(366, 15);
            this.lblDetallesRuta.Name = "lblDetallesRuta";
            this.lblDetallesRuta.Size = new System.Drawing.Size(366, 15);
            this.lblDetallesRuta.TabIndex = 0;
            this.lblDetallesRuta.Text = "Ruta: ";
            // 
            // pbFotoElegida
            // 
            this.pbFotoElegida.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbFotoElegida.Location = new System.Drawing.Point(0, 199);
            this.pbFotoElegida.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbFotoElegida.Name = "pbFotoElegida";
            this.pbFotoElegida.Size = new System.Drawing.Size(778, 465);
            this.pbFotoElegida.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFotoElegida.TabIndex = 2;
            this.pbFotoElegida.TabStop = false;
            // 
            // VisorRecuerdo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbDetalles);
            this.Controls.Add(this.pbFotoElegida);
            this.MinimumSize = new System.Drawing.Size(778, 664);
            this.Name = "VisorRecuerdo";
            this.Size = new System.Drawing.Size(778, 664);
            this.gbDetalles.ResumeLayout(false);
            this.gbDetalles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoElegida)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox gbDetalles;
        private Button btnDeshacer;
        private TextBox tbDetallesDescripcion;
        private Button btnGuardar;
        private TextBox tbDetallesFuente;
        private Label lblFuente;
        private Button btnDetallesQuitarEvento;
        private Button btnDetallesNuevoEvento;
        private ComboBox cbDetallesEvento;
        private Label lblDetallesEvento;
        private TextBox tbDetallesLugar;
        private Label lblDetallesLugar;
        private Label lblDetallesRuta;
        private PictureBox pbFotoElegida;
        private Label lblFecha;
        private Label lblDescripcion;
        private SelectorFecha selectorFecha;
    }
}

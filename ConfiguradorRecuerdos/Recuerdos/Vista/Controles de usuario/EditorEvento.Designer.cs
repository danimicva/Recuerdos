namespace Recuerdos.Vista.Controles_de_usuario
{
    partial class EditorEvento
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
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.tbLugar = new System.Windows.Forms.TextBox();
            this.lblLugar = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.gbPersonas = new System.Windows.Forms.GroupBox();
            this.lblPersonas = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.selectorFecha1 = new Recuerdos.Vista.Controles_de_usuario.SelectorFecha();
            this.gbPersonas.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescripcion.Location = new System.Drawing.Point(89, 132);
            this.tbDescripcion.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbDescripcion.Multiline = true;
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.Size = new System.Drawing.Size(300, 93);
            this.tbDescripcion.TabIndex = 10;
            this.tbDescripcion.TextChanged += new System.EventHandler(this.tbTodos_TextChanged);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(4, 135);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(72, 15);
            this.lblDescripcion.TabIndex = 11;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // tbLugar
            // 
            this.tbLugar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLugar.Location = new System.Drawing.Point(89, 35);
            this.tbLugar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbLugar.Name = "tbLugar";
            this.tbLugar.Size = new System.Drawing.Size(300, 23);
            this.tbLugar.TabIndex = 7;
            this.tbLugar.TextChanged += new System.EventHandler(this.tbTodos_TextChanged);
            // 
            // lblLugar
            // 
            this.lblLugar.AutoSize = true;
            this.lblLugar.Location = new System.Drawing.Point(5, 38);
            this.lblLugar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLugar.Name = "lblLugar";
            this.lblLugar.Size = new System.Drawing.Size(40, 15);
            this.lblLugar.TabIndex = 8;
            this.lblLugar.Text = "Lugar:";
            // 
            // tbNombre
            // 
            this.tbNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNombre.Location = new System.Drawing.Point(89, 5);
            this.tbNombre.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(300, 23);
            this.tbNombre.TabIndex = 6;
            this.tbNombre.TextChanged += new System.EventHandler(this.tbTodos_TextChanged);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(5, 8);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(54, 15);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(4, 70);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(41, 15);
            this.lblFecha.TabIndex = 13;
            this.lblFecha.Text = "Fecha:";
            // 
            // gbPersonas
            // 
            this.gbPersonas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPersonas.Controls.Add(this.lblPersonas);
            this.gbPersonas.Controls.Add(this.btnEditar);
            this.gbPersonas.Location = new System.Drawing.Point(5, 226);
            this.gbPersonas.Name = "gbPersonas";
            this.gbPersonas.Size = new System.Drawing.Size(384, 73);
            this.gbPersonas.TabIndex = 14;
            this.gbPersonas.TabStop = false;
            this.gbPersonas.Text = "Personas";
            // 
            // lblPersonas
            // 
            this.lblPersonas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPersonas.Location = new System.Drawing.Point(6, 19);
            this.lblPersonas.Name = "lblPersonas";
            this.lblPersonas.Size = new System.Drawing.Size(238, 46);
            this.lblPersonas.TabIndex = 1;
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.Location = new System.Drawing.Point(302, 19);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(76, 46);
            this.btnEditar.TabIndex = 0;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // selectorFecha1
            // 
            this.selectorFecha1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectorFecha1.Fechas = null;
            this.selectorFecha1.Location = new System.Drawing.Point(89, 64);
            this.selectorFecha1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.selectorFecha1.MinimumSize = new System.Drawing.Size(310, 62);
            this.selectorFecha1.Name = "selectorFecha1";
            this.selectorFecha1.Size = new System.Drawing.Size(310, 62);
            this.selectorFecha1.TabIndex = 15;
            // 
            // EditorEvento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.selectorFecha1);
            this.Controls.Add(this.gbPersonas);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.tbDescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.tbLugar);
            this.Controls.Add(this.lblLugar);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.lblNombre);
            this.Enabled = false;
            this.MinimumSize = new System.Drawing.Size(389, 299);
            this.Name = "EditorEvento";
            this.Size = new System.Drawing.Size(389, 299);
            this.gbPersonas.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox tbDescripcion;
        private Label lblDescripcion;
        private TextBox tbLugar;
        private Label lblLugar;
        private TextBox tbNombre;
        private Label lblNombre;
        private Label lblFecha;
        private GroupBox gbPersonas;
        private Label lblPersonas;
        private Button btnEditar;
        private SelectorFecha selectorFecha1;
    }
}

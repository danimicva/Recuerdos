namespace ConfiguradorRecuerdos
{
    partial class Configurador
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvFotos = new System.Windows.Forms.ListView();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.tbLugar = new System.Windows.Forms.TextBox();
            this.lblLugar = new System.Windows.Forms.Label();
            this.tbAnno = new System.Windows.Forms.TextBox();
            this.tbMes = new System.Windows.Forms.TextBox();
            this.lblFechaSep2 = new System.Windows.Forms.Label();
            this.tbDia = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblFechaSep1 = new System.Windows.Forms.Label();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.cbConLugar = new System.Windows.Forms.CheckBox();
            this.cbSoloSinFecha = new System.Windows.Forms.CheckBox();
            this.tbFiltroCantidad = new System.Windows.Forms.TextBox();
            this.lblFiltroCantidad = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnDeshacer = new System.Windows.Forms.Button();
            this.gbInfo.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvFotos
            // 
            this.lvFotos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvFotos.AutoArrange = false;
            this.lvFotos.FullRowSelect = true;
            this.lvFotos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvFotos.HideSelection = false;
            this.lvFotos.Location = new System.Drawing.Point(12, 122);
            this.lvFotos.Name = "lvFotos";
            this.lvFotos.ShowGroups = false;
            this.lvFotos.Size = new System.Drawing.Size(328, 487);
            this.lvFotos.TabIndex = 0;
            this.lvFotos.UseCompatibleStateImageBehavior = false;
            this.lvFotos.View = System.Windows.Forms.View.Details;
            this.lvFotos.SelectedIndexChanged += new System.EventHandler(this.lvFotos_SelectedIndexChanged);
            // 
            // gbInfo
            // 
            this.gbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInfo.Controls.Add(this.tbLugar);
            this.gbInfo.Controls.Add(this.lblLugar);
            this.gbInfo.Controls.Add(this.tbAnno);
            this.gbInfo.Controls.Add(this.tbMes);
            this.gbInfo.Controls.Add(this.lblFechaSep2);
            this.gbInfo.Controls.Add(this.tbDia);
            this.gbInfo.Controls.Add(this.lblFecha);
            this.gbInfo.Controls.Add(this.tbNombre);
            this.gbInfo.Controls.Add(this.lblNombre);
            this.gbInfo.Controls.Add(this.lblFechaSep1);
            this.gbInfo.Location = new System.Drawing.Point(346, 122);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(226, 105);
            this.gbInfo.TabIndex = 1;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Información";
            // 
            // tbLugar
            // 
            this.tbLugar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLugar.Location = new System.Drawing.Point(60, 70);
            this.tbLugar.Name = "tbLugar";
            this.tbLugar.Size = new System.Drawing.Size(160, 20);
            this.tbLugar.TabIndex = 5;
            this.tbLugar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputs_KeyPress_Guardar);
            // 
            // lblLugar
            // 
            this.lblLugar.AutoSize = true;
            this.lblLugar.Location = new System.Drawing.Point(7, 73);
            this.lblLugar.Name = "lblLugar";
            this.lblLugar.Size = new System.Drawing.Size(37, 13);
            this.lblLugar.TabIndex = 8;
            this.lblLugar.Text = "Lugar:";
            // 
            // tbAnno
            // 
            this.tbAnno.Location = new System.Drawing.Point(128, 45);
            this.tbAnno.Name = "tbAnno";
            this.tbAnno.Size = new System.Drawing.Size(42, 20);
            this.tbAnno.TabIndex = 4;
            this.tbAnno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputs_KeyPress_Guardar);
            // 
            // tbMes
            // 
            this.tbMes.Location = new System.Drawing.Point(93, 45);
            this.tbMes.Name = "tbMes";
            this.tbMes.Size = new System.Drawing.Size(22, 20);
            this.tbMes.TabIndex = 3;
            this.tbMes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputs_KeyPress_Guardar);
            // 
            // lblFechaSep2
            // 
            this.lblFechaSep2.AutoSize = true;
            this.lblFechaSep2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaSep2.Location = new System.Drawing.Point(115, 45);
            this.lblFechaSep2.Name = "lblFechaSep2";
            this.lblFechaSep2.Size = new System.Drawing.Size(13, 20);
            this.lblFechaSep2.TabIndex = 6;
            this.lblFechaSep2.Text = "/";
            // 
            // tbDia
            // 
            this.tbDia.Location = new System.Drawing.Point(60, 45);
            this.tbDia.Name = "tbDia";
            this.tbDia.Size = new System.Drawing.Size(22, 20);
            this.tbDia.TabIndex = 2;
            this.tbDia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputs_KeyPress_Guardar);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(7, 48);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha:";
            // 
            // tbNombre
            // 
            this.tbNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNombre.Location = new System.Drawing.Point(60, 17);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(160, 20);
            this.tbNombre.TabIndex = 1;
            this.tbNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputs_KeyPress_Guardar);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(7, 20);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblFechaSep1
            // 
            this.lblFechaSep1.AutoSize = true;
            this.lblFechaSep1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaSep1.Location = new System.Drawing.Point(81, 45);
            this.lblFechaSep1.Name = "lblFechaSep1";
            this.lblFechaSep1.Size = new System.Drawing.Size(13, 20);
            this.lblFechaSep1.TabIndex = 4;
            this.lblFechaSep1.Text = "/";
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.cbConLugar);
            this.gbFiltros.Controls.Add(this.cbSoloSinFecha);
            this.gbFiltros.Controls.Add(this.tbFiltroCantidad);
            this.gbFiltros.Controls.Add(this.lblFiltroCantidad);
            this.gbFiltros.Location = new System.Drawing.Point(12, 13);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(560, 103);
            this.gbFiltros.TabIndex = 99;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros";
            // 
            // cbConLugar
            // 
            this.cbConLugar.AutoSize = true;
            this.cbConLugar.Location = new System.Drawing.Point(199, 19);
            this.cbConLugar.Name = "cbConLugar";
            this.cbConLugar.Size = new System.Drawing.Size(71, 17);
            this.cbConLugar.TabIndex = 3;
            this.cbConLugar.Text = "Con lugar";
            this.cbConLugar.UseVisualStyleBackColor = true;
            // 
            // cbSoloSinFecha
            // 
            this.cbSoloSinFecha.AutoSize = true;
            this.cbSoloSinFecha.Location = new System.Drawing.Point(118, 19);
            this.cbSoloSinFecha.Name = "cbSoloSinFecha";
            this.cbSoloSinFecha.Size = new System.Drawing.Size(75, 17);
            this.cbSoloSinFecha.TabIndex = 2;
            this.cbSoloSinFecha.Text = "Con fecha";
            this.cbSoloSinFecha.UseVisualStyleBackColor = true;
            // 
            // tbFiltroCantidad
            // 
            this.tbFiltroCantidad.Location = new System.Drawing.Point(65, 17);
            this.tbFiltroCantidad.Name = "tbFiltroCantidad";
            this.tbFiltroCantidad.Size = new System.Drawing.Size(37, 20);
            this.tbFiltroCantidad.TabIndex = 1;
            this.tbFiltroCantidad.Text = "100";
            // 
            // lblFiltroCantidad
            // 
            this.lblFiltroCantidad.AutoSize = true;
            this.lblFiltroCantidad.Location = new System.Drawing.Point(7, 20);
            this.lblFiltroCantidad.Name = "lblFiltroCantidad";
            this.lblFiltroCantidad.Size = new System.Drawing.Size(52, 13);
            this.lblFiltroCantidad.TabIndex = 0;
            this.lblFiltroCantidad.Text = "Cantidad:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Enabled = false;
            this.btnGuardar.Location = new System.Drawing.Point(474, 586);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(98, 23);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnDeshacer
            // 
            this.btnDeshacer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeshacer.Enabled = false;
            this.btnDeshacer.Location = new System.Drawing.Point(370, 586);
            this.btnDeshacer.Name = "btnDeshacer";
            this.btnDeshacer.Size = new System.Drawing.Size(98, 23);
            this.btnDeshacer.TabIndex = 2;
            this.btnDeshacer.Text = "Deshacer";
            this.btnDeshacer.UseVisualStyleBackColor = true;
            this.btnDeshacer.Click += new System.EventHandler(this.btnDeshacer_Click);
            // 
            // Configurador
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 621);
            this.Controls.Add(this.btnDeshacer);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gbFiltros);
            this.Controls.Add(this.gbInfo);
            this.Controls.Add(this.lvFotos);
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "Configurador";
            this.Text = "Configurador";
            this.Load += new System.EventHandler(this.Configurador_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Configurador_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Configurador_DragEnter);
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvFotos;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox tbLugar;
        private System.Windows.Forms.Label lblLugar;
        private System.Windows.Forms.TextBox tbAnno;
        private System.Windows.Forms.TextBox tbMes;
        private System.Windows.Forms.Label lblFechaSep2;
        private System.Windows.Forms.TextBox tbDia;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblFechaSep1;
        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.CheckBox cbConLugar;
        private System.Windows.Forms.CheckBox cbSoloSinFecha;
        private System.Windows.Forms.TextBox tbFiltroCantidad;
        private System.Windows.Forms.Label lblFiltroCantidad;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnDeshacer;
    }
}


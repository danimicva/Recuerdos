
namespace Recuerdos.Vista
{
    partial class Procesador
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Procesador));
            this.pbFotoElegida = new System.Windows.Forms.PictureBox();
            this.gbDetalles = new System.Windows.Forms.GroupBox();
            this.tbDetallesFuente = new System.Windows.Forms.TextBox();
            this.lblFuente = new System.Windows.Forms.Label();
            this.btnQuitarEvento = new System.Windows.Forms.Button();
            this.btnDetallesNuevoEvento = new System.Windows.Forms.Button();
            this.cbDetallesEvento = new System.Windows.Forms.ComboBox();
            this.lblDetallesEvento = new System.Windows.Forms.Label();
            this.tbDetallesLugar = new System.Windows.Forms.TextBox();
            this.lblDetallesLugar = new System.Windows.Forms.Label();
            this.lblDetallesRuta = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.lvFicheros = new System.Windows.Forms.ListView();
            this.cNombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cTipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblCambios = new System.Windows.Forms.Label();
            this.btnDeshacer = new System.Windows.Forms.Button();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoElegida)).BeginInit();
            this.gbDetalles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbFotoElegida
            // 
            this.pbFotoElegida.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbFotoElegida.Location = new System.Drawing.Point(632, 12);
            this.pbFotoElegida.Name = "pbFotoElegida";
            this.pbFotoElegida.Size = new System.Drawing.Size(850, 657);
            this.pbFotoElegida.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFotoElegida.TabIndex = 0;
            this.pbFotoElegida.TabStop = false;
            // 
            // gbDetalles
            // 
            this.gbDetalles.Controls.Add(this.tbDescripcion);
            this.gbDetalles.Controls.Add(this.lblDescripcion);
            this.gbDetalles.Controls.Add(this.tbDetallesFuente);
            this.gbDetalles.Controls.Add(this.lblFuente);
            this.gbDetalles.Controls.Add(this.btnQuitarEvento);
            this.gbDetalles.Controls.Add(this.btnDetallesNuevoEvento);
            this.gbDetalles.Controls.Add(this.cbDetallesEvento);
            this.gbDetalles.Controls.Add(this.lblDetallesEvento);
            this.gbDetalles.Controls.Add(this.tbDetallesLugar);
            this.gbDetalles.Controls.Add(this.lblDetallesLugar);
            this.gbDetalles.Controls.Add(this.lblDetallesRuta);
            this.gbDetalles.Location = new System.Drawing.Point(12, 12);
            this.gbDetalles.Name = "gbDetalles";
            this.gbDetalles.Size = new System.Drawing.Size(502, 197);
            this.gbDetalles.TabIndex = 1;
            this.gbDetalles.TabStop = false;
            this.gbDetalles.Text = "Detalles";
            // 
            // tbDetallesFuente
            // 
            this.tbDetallesFuente.Location = new System.Drawing.Point(52, 98);
            this.tbDetallesFuente.Name = "tbDetallesFuente";
            this.tbDetallesFuente.Size = new System.Drawing.Size(341, 20);
            this.tbDetallesFuente.TabIndex = 9;
            this.tbDetallesFuente.TextChanged += new System.EventHandler(this.tbCualquiera_TextChanged);
            // 
            // lblFuente
            // 
            this.lblFuente.AutoSize = true;
            this.lblFuente.Location = new System.Drawing.Point(9, 101);
            this.lblFuente.Name = "lblFuente";
            this.lblFuente.Size = new System.Drawing.Size(43, 13);
            this.lblFuente.TabIndex = 8;
            this.lblFuente.Text = "Fuente:";
            // 
            // btnQuitarEvento
            // 
            this.btnQuitarEvento.Location = new System.Drawing.Point(179, 69);
            this.btnQuitarEvento.Name = "btnQuitarEvento";
            this.btnQuitarEvento.Size = new System.Drawing.Size(104, 23);
            this.btnQuitarEvento.TabIndex = 7;
            this.btnQuitarEvento.Text = "Quitar evento";
            this.btnQuitarEvento.UseVisualStyleBackColor = true;
            this.btnQuitarEvento.Click += new System.EventHandler(this.btnQuitarEvento_Click);
            // 
            // btnDetallesNuevoEvento
            // 
            this.btnDetallesNuevoEvento.Location = new System.Drawing.Point(289, 69);
            this.btnDetallesNuevoEvento.Name = "btnDetallesNuevoEvento";
            this.btnDetallesNuevoEvento.Size = new System.Drawing.Size(104, 23);
            this.btnDetallesNuevoEvento.TabIndex = 6;
            this.btnDetallesNuevoEvento.Text = "Nuevo evento";
            this.btnDetallesNuevoEvento.UseVisualStyleBackColor = true;
            this.btnDetallesNuevoEvento.Click += new System.EventHandler(this.btnDetallesNuevoEvento_Click);
            // 
            // cbDetallesEvento
            // 
            this.cbDetallesEvento.FormattingEnabled = true;
            this.cbDetallesEvento.Location = new System.Drawing.Point(52, 71);
            this.cbDetallesEvento.Name = "cbDetallesEvento";
            this.cbDetallesEvento.Size = new System.Drawing.Size(121, 21);
            this.cbDetallesEvento.TabIndex = 5;
            this.cbDetallesEvento.SelectedIndexChanged += new System.EventHandler(this.cbDetallesEvento_SelectedIndexChanged);
            // 
            // lblDetallesEvento
            // 
            this.lblDetallesEvento.AutoSize = true;
            this.lblDetallesEvento.Location = new System.Drawing.Point(9, 74);
            this.lblDetallesEvento.Name = "lblDetallesEvento";
            this.lblDetallesEvento.Size = new System.Drawing.Size(44, 13);
            this.lblDetallesEvento.TabIndex = 4;
            this.lblDetallesEvento.Text = "Evento:";
            // 
            // tbDetallesLugar
            // 
            this.tbDetallesLugar.Location = new System.Drawing.Point(52, 45);
            this.tbDetallesLugar.Name = "tbDetallesLugar";
            this.tbDetallesLugar.Size = new System.Drawing.Size(341, 20);
            this.tbDetallesLugar.TabIndex = 3;
            this.tbDetallesLugar.TextChanged += new System.EventHandler(this.tbCualquiera_TextChanged);
            // 
            // lblDetallesLugar
            // 
            this.lblDetallesLugar.AutoSize = true;
            this.lblDetallesLugar.Location = new System.Drawing.Point(9, 48);
            this.lblDetallesLugar.Name = "lblDetallesLugar";
            this.lblDetallesLugar.Size = new System.Drawing.Size(37, 13);
            this.lblDetallesLugar.TabIndex = 2;
            this.lblDetallesLugar.Text = "Lugar:";
            // 
            // lblDetallesRuta
            // 
            this.lblDetallesRuta.AutoSize = true;
            this.lblDetallesRuta.Location = new System.Drawing.Point(7, 20);
            this.lblDetallesRuta.Name = "lblDetallesRuta";
            this.lblDetallesRuta.Size = new System.Drawing.Size(36, 13);
            this.lblDetallesRuta.TabIndex = 0;
            this.lblDetallesRuta.Text = "Ruta: ";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "carpeta.jpg");
            this.imageList1.Images.SetKeyName(1, "fichero.jpg");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 215);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvFicheros);
            this.splitContainer1.Size = new System.Drawing.Size(599, 454);
            this.splitContainer1.SplitterDistance = 199;
            this.splitContainer1.TabIndex = 4;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(199, 454);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // lvFicheros
            // 
            this.lvFicheros.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cNombre,
            this.cTipo});
            this.lvFicheros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFicheros.HideSelection = false;
            this.lvFicheros.Location = new System.Drawing.Point(0, 0);
            this.lvFicheros.Name = "lvFicheros";
            this.lvFicheros.Size = new System.Drawing.Size(396, 454);
            this.lvFicheros.SmallImageList = this.imageList1;
            this.lvFicheros.TabIndex = 0;
            this.lvFicheros.UseCompatibleStateImageBehavior = false;
            this.lvFicheros.View = System.Windows.Forms.View.Details;
            this.lvFicheros.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            // 
            // cNombre
            // 
            this.cNombre.Text = "Nombre";
            // 
            // cTipo
            // 
            this.cTipo.Text = "Tipo";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(520, 157);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(106, 23);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblCambios
            // 
            this.lblCambios.AutoSize = true;
            this.lblCambios.Location = new System.Drawing.Point(520, 22);
            this.lblCambios.Name = "lblCambios";
            this.lblCambios.Size = new System.Drawing.Size(50, 13);
            this.lblCambios.TabIndex = 6;
            this.lblCambios.Text = "Cambios:";
            // 
            // btnDeshacer
            // 
            this.btnDeshacer.Location = new System.Drawing.Point(520, 186);
            this.btnDeshacer.Name = "btnDeshacer";
            this.btnDeshacer.Size = new System.Drawing.Size(106, 23);
            this.btnDeshacer.TabIndex = 7;
            this.btnDeshacer.Text = "Deshacer";
            this.btnDeshacer.UseVisualStyleBackColor = true;
            this.btnDeshacer.Click += new System.EventHandler(this.btnDeshacer_Click);
            // 
            // textBox1
            // 
            this.tbDescripcion.Location = new System.Drawing.Point(81, 124);
            this.tbDescripcion.Multiline = true;
            this.tbDescripcion.Name = "textBox1";
            this.tbDescripcion.Size = new System.Drawing.Size(312, 67);
            this.tbDescripcion.TabIndex = 11;
            this.tbDescripcion.TextChanged += new System.EventHandler(this.tbCualquiera_TextChanged);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(9, 127);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.TabIndex = 10;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // Procesador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1494, 681);
            this.Controls.Add(this.btnDeshacer);
            this.Controls.Add(this.lblCambios);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.gbDetalles);
            this.Controls.Add(this.pbFotoElegida);
            this.MinimumSize = new System.Drawing.Size(1000, 500);
            this.Name = "Procesador";
            this.Text = "Procesador";
            this.Load += new System.EventHandler(this.Procesador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoElegida)).EndInit();
            this.gbDetalles.ResumeLayout(false);
            this.gbDetalles.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFotoElegida;
        private System.Windows.Forms.GroupBox gbDetalles;
        private System.Windows.Forms.Button btnDetallesNuevoEvento;
        private System.Windows.Forms.ComboBox cbDetallesEvento;
        private System.Windows.Forms.Label lblDetallesEvento;
        private System.Windows.Forms.TextBox tbDetallesLugar;
        private System.Windows.Forms.Label lblDetallesLugar;
        private System.Windows.Forms.Label lblDetallesRuta;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListView lvFicheros;
        private System.Windows.Forms.ColumnHeader cNombre;
        private System.Windows.Forms.ColumnHeader cTipo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblCambios;
        private System.Windows.Forms.Button btnDeshacer;
        private System.Windows.Forms.Button btnQuitarEvento;
        private System.Windows.Forms.TextBox tbDetallesFuente;
        private System.Windows.Forms.Label lblFuente;
        private System.Windows.Forms.TextBox tbDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
    }
}
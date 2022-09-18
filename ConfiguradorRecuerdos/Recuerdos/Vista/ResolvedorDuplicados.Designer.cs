
namespace Recuerdos.Vista
{
    partial class ResolvedorDuplicados
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
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.dgvDuplicados = new System.Windows.Forms.DataGridView();
            this.cRuta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnElegirDefinitiva = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuplicados)).BeginInit();
            this.SuspendLayout();
            // 
            // pbImagen
            // 
            this.pbImagen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbImagen.Location = new System.Drawing.Point(13, 13);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(686, 787);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImagen.TabIndex = 2;
            this.pbImagen.TabStop = false;
            // 
            // dgvDuplicados
            // 
            this.dgvDuplicados.AllowUserToAddRows = false;
            this.dgvDuplicados.AllowUserToDeleteRows = false;
            this.dgvDuplicados.AllowUserToResizeRows = false;
            this.dgvDuplicados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDuplicados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDuplicados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cRuta});
            this.dgvDuplicados.Location = new System.Drawing.Point(705, 13);
            this.dgvDuplicados.MultiSelect = false;
            this.dgvDuplicados.Name = "dgvDuplicados";
            this.dgvDuplicados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDuplicados.Size = new System.Drawing.Size(452, 744);
            this.dgvDuplicados.TabIndex = 3;
            this.dgvDuplicados.SelectionChanged += new System.EventHandler(this.dgvDuplicados_SelectionChanged);
            this.dgvDuplicados.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDuplicados_KeyDown);
            // 
            // cRuta
            // 
            this.cRuta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cRuta.HeaderText = "Ruta";
            this.cRuta.Name = "cRuta";
            this.cRuta.ReadOnly = true;
            this.cRuta.Width = 55;
            // 
            // btnElegirDefinitiva
            // 
            this.btnElegirDefinitiva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnElegirDefinitiva.Enabled = false;
            this.btnElegirDefinitiva.Location = new System.Drawing.Point(705, 763);
            this.btnElegirDefinitiva.Name = "btnElegirDefinitiva";
            this.btnElegirDefinitiva.Size = new System.Drawing.Size(451, 37);
            this.btnElegirDefinitiva.TabIndex = 4;
            this.btnElegirDefinitiva.Text = "ElegirFoto";
            this.btnElegirDefinitiva.UseVisualStyleBackColor = true;
            this.btnElegirDefinitiva.Click += new System.EventHandler(this.btnElegirDefinitiva_Click);
            // 
            // ResolvedorDuplicados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 812);
            this.Controls.Add(this.btnElegirDefinitiva);
            this.Controls.Add(this.dgvDuplicados);
            this.Controls.Add(this.pbImagen);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "ResolvedorDuplicados";
            this.Text = "ResolvedorDuplicados";
            this.Load += new System.EventHandler(this.ResolvedorDuplicados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuplicados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbImagen;
        private System.Windows.Forms.DataGridView dgvDuplicados;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRuta;
        private System.Windows.Forms.Button btnElegirDefinitiva;
    }
}
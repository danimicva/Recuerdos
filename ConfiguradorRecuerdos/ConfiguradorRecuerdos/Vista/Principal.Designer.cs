
namespace Recuerdos.Vista
{
    partial class Principal
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslProceso = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbAcciones = new System.Windows.Forms.GroupBox();
            this.btnAccionParar = new System.Windows.Forms.Button();
            this.btnAccionCalcularMd5 = new System.Windows.Forms.Button();
            this.btnAccionActualizarBiblioteca = new System.Windows.Forms.Button();
            this.btnAccionBuscarDuplicados = new System.Windows.Forms.Button();
            this.btnCambiarBiblioteca = new System.Windows.Forms.Button();
            this.gbResumen = new System.Windows.Forms.GroupBox();
            this.lblResumenConMd5 = new System.Windows.Forms.Label();
            this.lblPerdidos = new System.Windows.Forms.Label();
            this.lblNuevos = new System.Windows.Forms.Label();
            this.lblParaRevisar = new System.Windows.Forms.Label();
            this.lblTotalRecuerdos = new System.Windows.Forms.Label();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.gbAcciones.SuspendLayout();
            this.gbResumen.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslProceso,
            this.tsslEstado});
            this.statusStrip1.Location = new System.Drawing.Point(0, 463);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(760, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslProceso
            // 
            this.tsslProceso.Name = "tsslProceso";
            this.tsslProceso.Size = new System.Drawing.Size(120, 17);
            this.tsslProceso.Text = "Mostrando biblioteca";
            // 
            // tsslEstado
            // 
            this.tsslEstado.Name = "tsslEstado";
            this.tsslEstado.Size = new System.Drawing.Size(0, 17);
            // 
            // gbAcciones
            // 
            this.gbAcciones.Controls.Add(this.btnAccionParar);
            this.gbAcciones.Controls.Add(this.btnAccionCalcularMd5);
            this.gbAcciones.Controls.Add(this.btnAccionActualizarBiblioteca);
            this.gbAcciones.Controls.Add(this.btnAccionBuscarDuplicados);
            this.gbAcciones.Location = new System.Drawing.Point(12, 151);
            this.gbAcciones.Name = "gbAcciones";
            this.gbAcciones.Size = new System.Drawing.Size(200, 185);
            this.gbAcciones.TabIndex = 2;
            this.gbAcciones.TabStop = false;
            this.gbAcciones.Text = "Acciones";
            // 
            // btnAccionParar
            // 
            this.btnAccionParar.Enabled = false;
            this.btnAccionParar.Location = new System.Drawing.Point(6, 156);
            this.btnAccionParar.Name = "btnAccionParar";
            this.btnAccionParar.Size = new System.Drawing.Size(188, 23);
            this.btnAccionParar.TabIndex = 4;
            this.btnAccionParar.Text = "Parar";
            this.btnAccionParar.UseVisualStyleBackColor = true;
            this.btnAccionParar.Click += new System.EventHandler(this.btnAccionParar_Click);
            // 
            // btnAccionCalcularMd5
            // 
            this.btnAccionCalcularMd5.Location = new System.Drawing.Point(6, 48);
            this.btnAccionCalcularMd5.Name = "btnAccionCalcularMd5";
            this.btnAccionCalcularMd5.Size = new System.Drawing.Size(188, 23);
            this.btnAccionCalcularMd5.TabIndex = 3;
            this.btnAccionCalcularMd5.Text = "Calcular Md5";
            this.btnAccionCalcularMd5.UseVisualStyleBackColor = true;
            this.btnAccionCalcularMd5.Click += new System.EventHandler(this.btnAccionesCalcularMd5_Click);
            // 
            // btnAccionActualizarBiblioteca
            // 
            this.btnAccionActualizarBiblioteca.Location = new System.Drawing.Point(6, 19);
            this.btnAccionActualizarBiblioteca.Name = "btnAccionActualizarBiblioteca";
            this.btnAccionActualizarBiblioteca.Size = new System.Drawing.Size(188, 23);
            this.btnAccionActualizarBiblioteca.TabIndex = 2;
            this.btnAccionActualizarBiblioteca.Text = "Actualizar biblioteca";
            this.btnAccionActualizarBiblioteca.UseVisualStyleBackColor = true;
            this.btnAccionActualizarBiblioteca.Click += new System.EventHandler(this.btnAccionesActualizarBiblioteca_Click);
            // 
            // btnAccionBuscarDuplicados
            // 
            this.btnAccionBuscarDuplicados.Location = new System.Drawing.Point(6, 77);
            this.btnAccionBuscarDuplicados.Name = "btnAccionBuscarDuplicados";
            this.btnAccionBuscarDuplicados.Size = new System.Drawing.Size(188, 23);
            this.btnAccionBuscarDuplicados.TabIndex = 1;
            this.btnAccionBuscarDuplicados.Text = "Buscar duplicados";
            this.btnAccionBuscarDuplicados.UseVisualStyleBackColor = true;
            this.btnAccionBuscarDuplicados.Click += new System.EventHandler(this.btnAccionesBuscarDuplicados_Click);
            // 
            // btnCambiarBiblioteca
            // 
            this.btnCambiarBiblioteca.Location = new System.Drawing.Point(559, 11);
            this.btnCambiarBiblioteca.Name = "btnCambiarBiblioteca";
            this.btnCambiarBiblioteca.Size = new System.Drawing.Size(188, 23);
            this.btnCambiarBiblioteca.TabIndex = 3;
            this.btnCambiarBiblioteca.Text = "Cambiar biblioteca";
            this.btnCambiarBiblioteca.UseVisualStyleBackColor = true;
            this.btnCambiarBiblioteca.Click += new System.EventHandler(this.btnCambiarBiblioteca_Click);
            // 
            // gbResumen
            // 
            this.gbResumen.Controls.Add(this.lblResumenConMd5);
            this.gbResumen.Controls.Add(this.lblPerdidos);
            this.gbResumen.Controls.Add(this.lblNuevos);
            this.gbResumen.Controls.Add(this.lblParaRevisar);
            this.gbResumen.Controls.Add(this.lblTotalRecuerdos);
            this.gbResumen.Location = new System.Drawing.Point(12, 12);
            this.gbResumen.Name = "gbResumen";
            this.gbResumen.Size = new System.Drawing.Size(200, 133);
            this.gbResumen.TabIndex = 0;
            this.gbResumen.TabStop = false;
            this.gbResumen.Text = "Resumen";
            // 
            // lblResumenConMd5
            // 
            this.lblResumenConMd5.AutoSize = true;
            this.lblResumenConMd5.Location = new System.Drawing.Point(7, 100);
            this.lblResumenConMd5.Name = "lblResumenConMd5";
            this.lblResumenConMd5.Size = new System.Drawing.Size(56, 13);
            this.lblResumenConMd5.TabIndex = 4;
            this.lblResumenConMd5.Text = "Con Md5: ";
            // 
            // lblPerdidos
            // 
            this.lblPerdidos.AutoSize = true;
            this.lblPerdidos.Location = new System.Drawing.Point(7, 80);
            this.lblPerdidos.Name = "lblPerdidos";
            this.lblPerdidos.Size = new System.Drawing.Size(51, 13);
            this.lblPerdidos.TabIndex = 3;
            this.lblPerdidos.Text = "Perdidos:";
            // 
            // lblNuevos
            // 
            this.lblNuevos.AutoSize = true;
            this.lblNuevos.Location = new System.Drawing.Point(7, 60);
            this.lblNuevos.Name = "lblNuevos";
            this.lblNuevos.Size = new System.Drawing.Size(47, 13);
            this.lblNuevos.TabIndex = 2;
            this.lblNuevos.Text = "Nuevos:";
            // 
            // lblParaRevisar
            // 
            this.lblParaRevisar.AutoSize = true;
            this.lblParaRevisar.Location = new System.Drawing.Point(7, 40);
            this.lblParaRevisar.Name = "lblParaRevisar";
            this.lblParaRevisar.Size = new System.Drawing.Size(51, 13);
            this.lblParaRevisar.TabIndex = 1;
            this.lblParaRevisar.Text = "A revisar:";
            // 
            // lblTotalRecuerdos
            // 
            this.lblTotalRecuerdos.AutoSize = true;
            this.lblTotalRecuerdos.Location = new System.Drawing.Point(7, 20);
            this.lblTotalRecuerdos.Name = "lblTotalRecuerdos";
            this.lblTotalRecuerdos.Size = new System.Drawing.Size(34, 13);
            this.lblTotalRecuerdos.TabIndex = 0;
            this.lblTotalRecuerdos.Text = "Total:";
            // 
            // btnProcesar
            // 
            this.btnProcesar.Location = new System.Drawing.Point(218, 12);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(335, 123);
            this.btnProcesar.TabIndex = 5;
            this.btnProcesar.Text = "Procesar biblioteca";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 485);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.gbResumen);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnCambiarBiblioteca);
            this.Controls.Add(this.gbAcciones);
            this.Name = "Principal";
            this.Text = "Biblioteca";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Principal_FormClosed);
            this.Load += new System.EventHandler(this.Principal_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.gbAcciones.ResumeLayout(false);
            this.gbResumen.ResumeLayout(false);
            this.gbResumen.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslProceso;
        private System.Windows.Forms.ToolStripStatusLabel tsslEstado;
        private System.Windows.Forms.GroupBox gbAcciones;
        private System.Windows.Forms.Button btnAccionParar;
        private System.Windows.Forms.Button btnAccionCalcularMd5;
        private System.Windows.Forms.Button btnAccionActualizarBiblioteca;
        private System.Windows.Forms.Button btnAccionBuscarDuplicados;
        private System.Windows.Forms.Button btnCambiarBiblioteca;
        private System.Windows.Forms.GroupBox gbResumen;
        private System.Windows.Forms.Label lblResumenConMd5;
        private System.Windows.Forms.Label lblPerdidos;
        private System.Windows.Forms.Label lblNuevos;
        private System.Windows.Forms.Label lblParaRevisar;
        private System.Windows.Forms.Label lblTotalRecuerdos;
        private System.Windows.Forms.Button btnProcesar;
    }
}
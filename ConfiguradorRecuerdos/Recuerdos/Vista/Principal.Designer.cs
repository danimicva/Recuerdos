
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
            this.btnGestionarEventos = new System.Windows.Forms.Button();
            this.btnActualizarBBDD = new System.Windows.Forms.Button();
            this.gbEventos = new System.Windows.Forms.GroupBox();
            this.lblTotalEventos = new System.Windows.Forms.Label();
            this.btnPersonas = new System.Windows.Forms.Button();
            this.gbPersonas = new System.Windows.Forms.GroupBox();
            this.lblTotalPersonas = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.gbAcciones.SuspendLayout();
            this.gbResumen.SuspendLayout();
            this.gbEventos.SuspendLayout();
            this.gbPersonas.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslProceso,
            this.tsslEstado});
            this.statusStrip1.Location = new System.Drawing.Point(0, 538);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(887, 22);
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
            this.gbAcciones.Location = new System.Drawing.Point(14, 174);
            this.gbAcciones.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbAcciones.Name = "gbAcciones";
            this.gbAcciones.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbAcciones.Size = new System.Drawing.Size(233, 213);
            this.gbAcciones.TabIndex = 2;
            this.gbAcciones.TabStop = false;
            this.gbAcciones.Text = "Acciones";
            // 
            // btnAccionParar
            // 
            this.btnAccionParar.Enabled = false;
            this.btnAccionParar.Location = new System.Drawing.Point(7, 180);
            this.btnAccionParar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAccionParar.Name = "btnAccionParar";
            this.btnAccionParar.Size = new System.Drawing.Size(219, 27);
            this.btnAccionParar.TabIndex = 4;
            this.btnAccionParar.Text = "Parar";
            this.btnAccionParar.UseVisualStyleBackColor = true;
            this.btnAccionParar.Click += new System.EventHandler(this.btnAccionParar_Click);
            // 
            // btnAccionCalcularMd5
            // 
            this.btnAccionCalcularMd5.Enabled = false;
            this.btnAccionCalcularMd5.Location = new System.Drawing.Point(7, 55);
            this.btnAccionCalcularMd5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAccionCalcularMd5.Name = "btnAccionCalcularMd5";
            this.btnAccionCalcularMd5.Size = new System.Drawing.Size(219, 27);
            this.btnAccionCalcularMd5.TabIndex = 3;
            this.btnAccionCalcularMd5.Text = "Calcular Md5";
            this.btnAccionCalcularMd5.UseVisualStyleBackColor = true;
            this.btnAccionCalcularMd5.Click += new System.EventHandler(this.btnAccionesCalcularMd5_Click);
            // 
            // btnAccionActualizarBiblioteca
            // 
            this.btnAccionActualizarBiblioteca.Enabled = false;
            this.btnAccionActualizarBiblioteca.Location = new System.Drawing.Point(7, 22);
            this.btnAccionActualizarBiblioteca.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAccionActualizarBiblioteca.Name = "btnAccionActualizarBiblioteca";
            this.btnAccionActualizarBiblioteca.Size = new System.Drawing.Size(219, 27);
            this.btnAccionActualizarBiblioteca.TabIndex = 2;
            this.btnAccionActualizarBiblioteca.Text = "Actualizar biblioteca";
            this.btnAccionActualizarBiblioteca.UseVisualStyleBackColor = true;
            this.btnAccionActualizarBiblioteca.Click += new System.EventHandler(this.btnAccionesActualizarBiblioteca_Click);
            // 
            // btnAccionBuscarDuplicados
            // 
            this.btnAccionBuscarDuplicados.Enabled = false;
            this.btnAccionBuscarDuplicados.Location = new System.Drawing.Point(7, 89);
            this.btnAccionBuscarDuplicados.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAccionBuscarDuplicados.Name = "btnAccionBuscarDuplicados";
            this.btnAccionBuscarDuplicados.Size = new System.Drawing.Size(219, 27);
            this.btnAccionBuscarDuplicados.TabIndex = 1;
            this.btnAccionBuscarDuplicados.Text = "Buscar duplicados";
            this.btnAccionBuscarDuplicados.UseVisualStyleBackColor = true;
            this.btnAccionBuscarDuplicados.Click += new System.EventHandler(this.btnAccionesBuscarDuplicados_Click);
            // 
            // btnCambiarBiblioteca
            // 
            this.btnCambiarBiblioteca.Location = new System.Drawing.Point(652, 13);
            this.btnCambiarBiblioteca.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCambiarBiblioteca.Name = "btnCambiarBiblioteca";
            this.btnCambiarBiblioteca.Size = new System.Drawing.Size(219, 27);
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
            this.gbResumen.Location = new System.Drawing.Point(14, 14);
            this.gbResumen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbResumen.Name = "gbResumen";
            this.gbResumen.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbResumen.Size = new System.Drawing.Size(102, 153);
            this.gbResumen.TabIndex = 0;
            this.gbResumen.TabStop = false;
            this.gbResumen.Text = "Recuerdos";
            // 
            // lblResumenConMd5
            // 
            this.lblResumenConMd5.AutoSize = true;
            this.lblResumenConMd5.Location = new System.Drawing.Point(8, 115);
            this.lblResumenConMd5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResumenConMd5.Name = "lblResumenConMd5";
            this.lblResumenConMd5.Size = new System.Drawing.Size(62, 15);
            this.lblResumenConMd5.TabIndex = 4;
            this.lblResumenConMd5.Text = "Con Md5: ";
            // 
            // lblPerdidos
            // 
            this.lblPerdidos.AutoSize = true;
            this.lblPerdidos.Location = new System.Drawing.Point(8, 92);
            this.lblPerdidos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPerdidos.Name = "lblPerdidos";
            this.lblPerdidos.Size = new System.Drawing.Size(56, 15);
            this.lblPerdidos.TabIndex = 3;
            this.lblPerdidos.Text = "Perdidos:";
            // 
            // lblNuevos
            // 
            this.lblNuevos.AutoSize = true;
            this.lblNuevos.Location = new System.Drawing.Point(8, 69);
            this.lblNuevos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNuevos.Name = "lblNuevos";
            this.lblNuevos.Size = new System.Drawing.Size(50, 15);
            this.lblNuevos.TabIndex = 2;
            this.lblNuevos.Text = "Nuevos:";
            // 
            // lblParaRevisar
            // 
            this.lblParaRevisar.AutoSize = true;
            this.lblParaRevisar.Location = new System.Drawing.Point(8, 46);
            this.lblParaRevisar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblParaRevisar.Name = "lblParaRevisar";
            this.lblParaRevisar.Size = new System.Drawing.Size(55, 15);
            this.lblParaRevisar.TabIndex = 1;
            this.lblParaRevisar.Text = "A revisar:";
            // 
            // lblTotalRecuerdos
            // 
            this.lblTotalRecuerdos.AutoSize = true;
            this.lblTotalRecuerdos.Location = new System.Drawing.Point(8, 23);
            this.lblTotalRecuerdos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalRecuerdos.Name = "lblTotalRecuerdos";
            this.lblTotalRecuerdos.Size = new System.Drawing.Size(35, 15);
            this.lblTotalRecuerdos.TabIndex = 0;
            this.lblTotalRecuerdos.Text = "Total:";
            // 
            // btnProcesar
            // 
            this.btnProcesar.Enabled = false;
            this.btnProcesar.Location = new System.Drawing.Point(253, 14);
            this.btnProcesar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(391, 61);
            this.btnProcesar.TabIndex = 5;
            this.btnProcesar.Text = "Procesar biblioteca";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // btnGestionarEventos
            // 
            this.btnGestionarEventos.Enabled = false;
            this.btnGestionarEventos.Location = new System.Drawing.Point(253, 83);
            this.btnGestionarEventos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGestionarEventos.Name = "btnGestionarEventos";
            this.btnGestionarEventos.Size = new System.Drawing.Size(391, 61);
            this.btnGestionarEventos.TabIndex = 6;
            this.btnGestionarEventos.Text = "Gestionar Eventos";
            this.btnGestionarEventos.UseVisualStyleBackColor = true;
            this.btnGestionarEventos.Click += new System.EventHandler(this.btnGestionarEventos_Click);
            // 
            // btnActualizarBBDD
            // 
            this.btnActualizarBBDD.Enabled = false;
            this.btnActualizarBBDD.Location = new System.Drawing.Point(652, 48);
            this.btnActualizarBBDD.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnActualizarBBDD.Name = "btnActualizarBBDD";
            this.btnActualizarBBDD.Size = new System.Drawing.Size(219, 27);
            this.btnActualizarBBDD.TabIndex = 7;
            this.btnActualizarBBDD.Text = "Actualizar BBDD";
            this.btnActualizarBBDD.UseVisualStyleBackColor = true;
            this.btnActualizarBBDD.Click += new System.EventHandler(this.btnActualizarBBDD_Click);
            // 
            // gbEventos
            // 
            this.gbEventos.Controls.Add(this.lblTotalEventos);
            this.gbEventos.Location = new System.Drawing.Point(124, 15);
            this.gbEventos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbEventos.Name = "gbEventos";
            this.gbEventos.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbEventos.Size = new System.Drawing.Size(121, 73);
            this.gbEventos.TabIndex = 5;
            this.gbEventos.TabStop = false;
            this.gbEventos.Text = "Eventos";
            // 
            // lblTotalEventos
            // 
            this.lblTotalEventos.AutoSize = true;
            this.lblTotalEventos.Location = new System.Drawing.Point(9, 23);
            this.lblTotalEventos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalEventos.Name = "lblTotalEventos";
            this.lblTotalEventos.Size = new System.Drawing.Size(35, 15);
            this.lblTotalEventos.TabIndex = 0;
            this.lblTotalEventos.Text = "Total:";
            // 
            // btnPersonas
            // 
            this.btnPersonas.Enabled = false;
            this.btnPersonas.Location = new System.Drawing.Point(253, 150);
            this.btnPersonas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPersonas.Name = "btnPersonas";
            this.btnPersonas.Size = new System.Drawing.Size(391, 61);
            this.btnPersonas.TabIndex = 8;
            this.btnPersonas.Text = "Gestionar Personas";
            this.btnPersonas.UseVisualStyleBackColor = true;
            this.btnPersonas.Click += new System.EventHandler(this.btnPersonas_Click);
            // 
            // gbPersonas
            // 
            this.gbPersonas.Controls.Add(this.lblTotalPersonas);
            this.gbPersonas.Location = new System.Drawing.Point(124, 94);
            this.gbPersonas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbPersonas.Name = "gbPersonas";
            this.gbPersonas.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbPersonas.Size = new System.Drawing.Size(121, 73);
            this.gbPersonas.TabIndex = 6;
            this.gbPersonas.TabStop = false;
            this.gbPersonas.Text = "Personas";
            // 
            // lblTotalPersonas
            // 
            this.lblTotalPersonas.AutoSize = true;
            this.lblTotalPersonas.Location = new System.Drawing.Point(10, 23);
            this.lblTotalPersonas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalPersonas.Name = "lblTotalPersonas";
            this.lblTotalPersonas.Size = new System.Drawing.Size(35, 15);
            this.lblTotalPersonas.TabIndex = 0;
            this.lblTotalPersonas.Text = "Total:";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 560);
            this.Controls.Add(this.gbPersonas);
            this.Controls.Add(this.btnPersonas);
            this.Controls.Add(this.gbEventos);
            this.Controls.Add(this.btnActualizarBBDD);
            this.Controls.Add(this.btnGestionarEventos);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.gbResumen);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnCambiarBiblioteca);
            this.Controls.Add(this.gbAcciones);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Principal";
            this.Text = "Biblioteca";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Principal_FormClosed);
            this.Load += new System.EventHandler(this.Principal_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.gbAcciones.ResumeLayout(false);
            this.gbResumen.ResumeLayout(false);
            this.gbResumen.PerformLayout();
            this.gbEventos.ResumeLayout(false);
            this.gbEventos.PerformLayout();
            this.gbPersonas.ResumeLayout(false);
            this.gbPersonas.PerformLayout();
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
        private Button btnGestionarEventos;
        private Button btnActualizarBBDD;
        private GroupBox gbEventos;
        private Label lblTotalEventos;
        private Button btnPersonas;
        private GroupBox gbPersonas;
        private Label lblTotalPersonas;
    }
}
﻿namespace Recuerdos.Vista.Gestores
{
    partial class GestorEventos
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
            this.lbEventos = new System.Windows.Forms.ListBox();
            this.gbEvento = new System.Windows.Forms.GroupBox();
            this.evEvento = new Recuerdos.Vista.Controles_de_usuario.EditorEvento();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnDeshacer = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.gbEvento.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbEventos
            // 
            this.lbEventos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbEventos.FormattingEnabled = true;
            this.lbEventos.ItemHeight = 15;
            this.lbEventos.Location = new System.Drawing.Point(12, 12);
            this.lbEventos.Name = "lbEventos";
            this.lbEventos.Size = new System.Drawing.Size(256, 349);
            this.lbEventos.TabIndex = 1;
            this.lbEventos.SelectedIndexChanged += new System.EventHandler(this.lbEventos_SelectedIndexChanged);
            // 
            // gbEvento
            // 
            this.gbEvento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbEvento.Controls.Add(this.evEvento);
            this.gbEvento.Location = new System.Drawing.Point(274, 12);
            this.gbEvento.Name = "gbEvento";
            this.gbEvento.Size = new System.Drawing.Size(415, 346);
            this.gbEvento.TabIndex = 2;
            this.gbEvento.TabStop = false;
            this.gbEvento.Text = "Información";
            // 
            // evEvento
            // 
            this.evEvento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.evEvento.Enabled = false;
            this.evEvento.Evento = null;
            this.evEvento.Location = new System.Drawing.Point(6, 19);
            this.evEvento.MinimumSize = new System.Drawing.Size(360, 221);
            this.evEvento.Modificado = false;
            this.evEvento.Name = "evEvento";
            this.evEvento.Size = new System.Drawing.Size(401, 321);
            this.evEvento.TabIndex = 0;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(614, 364);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBorrar.Location = new System.Drawing.Point(274, 364);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 23);
            this.btnBorrar.TabIndex = 5;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnDeshacer
            // 
            this.btnDeshacer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeshacer.Location = new System.Drawing.Point(533, 364);
            this.btnDeshacer.Name = "btnDeshacer";
            this.btnDeshacer.Size = new System.Drawing.Size(75, 23);
            this.btnDeshacer.TabIndex = 6;
            this.btnDeshacer.Text = "Deshacer";
            this.btnDeshacer.UseVisualStyleBackColor = true;
            this.btnDeshacer.Click += new System.EventHandler(this.btnDeshacer_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNuevo.Location = new System.Drawing.Point(355, 364);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 7;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCerrar.Location = new System.Drawing.Point(12, 367);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 8;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // GestorEventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(697, 397);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnDeshacer);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gbEvento);
            this.Controls.Add(this.lbEventos);
            this.MinimumSize = new System.Drawing.Size(690, 436);
            this.Name = "GestorEventos";
            this.Text = "Gestionar eventos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GestorEventos_FormClosed);
            this.Load += new System.EventHandler(this.GestorEventos_Load);
            this.gbEvento.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox lbEventos;
        private GroupBox gbEvento;
        private Button btnGuardar;
        private Button btnBorrar;
        private Button btnDeshacer;
        private Button btnNuevo;
        private Button btnCerrar;
        private Controles_de_usuario.EditorEvento evEvento;
    }
}
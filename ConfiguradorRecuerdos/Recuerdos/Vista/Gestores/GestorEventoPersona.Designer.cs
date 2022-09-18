namespace Recuerdos.Vista.Gestores
{
    partial class GestorEventoPersona
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
            this.lbIncluidos = new System.Windows.Forms.ListBox();
            this.lbTodos = new System.Windows.Forms.ListBox();
            this.btnAnadir = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblTodasPersonas = new System.Windows.Forms.Label();
            this.lblIncluidas = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbIncluidos
            // 
            this.lbIncluidos.FormattingEnabled = true;
            this.lbIncluidos.ItemHeight = 15;
            this.lbIncluidos.Location = new System.Drawing.Point(297, 27);
            this.lbIncluidos.Name = "lbIncluidos";
            this.lbIncluidos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbIncluidos.Size = new System.Drawing.Size(197, 379);
            this.lbIncluidos.TabIndex = 0;
            this.lbIncluidos.SelectedValueChanged += new System.EventHandler(this.lbTodos_SelectedValueChanged);
            // 
            // lbTodos
            // 
            this.lbTodos.FormattingEnabled = true;
            this.lbTodos.ItemHeight = 15;
            this.lbTodos.Location = new System.Drawing.Point(12, 27);
            this.lbTodos.Name = "lbTodos";
            this.lbTodos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbTodos.Size = new System.Drawing.Size(198, 379);
            this.lbTodos.TabIndex = 1;
            this.lbTodos.SelectedValueChanged += new System.EventHandler(this.lbTodos_SelectedValueChanged);
            // 
            // btnAnadir
            // 
            this.btnAnadir.Location = new System.Drawing.Point(216, 180);
            this.btnAnadir.Name = "btnAnadir";
            this.btnAnadir.Size = new System.Drawing.Size(75, 23);
            this.btnAnadir.TabIndex = 2;
            this.btnAnadir.Text = "<--";
            this.btnAnadir.UseVisualStyleBackColor = true;
            this.btnAnadir.Click += new System.EventHandler(this.btnAnadir_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(216, 209);
            this.btnQuitar.MaximumSize = new System.Drawing.Size(75, 23);
            this.btnQuitar.MinimumSize = new System.Drawing.Size(75, 23);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(75, 23);
            this.btnQuitar.TabIndex = 3;
            this.btnQuitar.Text = "-->";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(12, 415);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(178, 23);
            this.btnNuevo.TabIndex = 4;
            this.btnNuevo.Text = "Nueva persona";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(410, 415);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(84, 23);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(316, 415);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblTodasPersonas
            // 
            this.lblTodasPersonas.AutoSize = true;
            this.lblTodasPersonas.Location = new System.Drawing.Point(12, 9);
            this.lblTodasPersonas.Name = "lblTodasPersonas";
            this.lblTodasPersonas.Size = new System.Drawing.Size(60, 15);
            this.lblTodasPersonas.TabIndex = 7;
            this.lblTodasPersonas.Text = "Personas: ";
            // 
            // lblIncluidas
            // 
            this.lblIncluidas.AutoSize = true;
            this.lblIncluidas.Location = new System.Drawing.Point(297, 9);
            this.lblIncluidas.Name = "lblIncluidas";
            this.lblIncluidas.Size = new System.Drawing.Size(74, 15);
            this.lblIncluidas.TabIndex = 8;
            this.lblIncluidas.Text = "En el evento:";
            // 
            // GestorEventoPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(506, 450);
            this.Controls.Add(this.lblIncluidas);
            this.Controls.Add(this.lblTodasPersonas);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnAnadir);
            this.Controls.Add(this.lbTodos);
            this.Controls.Add(this.lbIncluidos);
            this.MaximumSize = new System.Drawing.Size(522, 489);
            this.MinimumSize = new System.Drawing.Size(522, 489);
            this.Name = "GestorEventoPersona";
            this.Text = "Asignar personas a eventos";
            this.Load += new System.EventHandler(this.GestorEventoPersona_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox lbIncluidos;
        private ListBox lbTodos;
        private Button btnAnadir;
        private Button btnQuitar;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnCancelar;
        private Label lblTodasPersonas;
        private Label lblIncluidas;
    }
}
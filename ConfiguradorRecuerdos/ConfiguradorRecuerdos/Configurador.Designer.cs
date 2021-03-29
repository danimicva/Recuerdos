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
            this.SuspendLayout();
            // 
            // lvFotos
            // 
            this.lvFotos.AllowColumnReorder = true;
            this.lvFotos.FullRowSelect = true;
            this.lvFotos.HideSelection = false;
            this.lvFotos.Location = new System.Drawing.Point(60, 58);
            this.lvFotos.Name = "lvFotos";
            this.lvFotos.Size = new System.Drawing.Size(348, 335);
            this.lvFotos.TabIndex = 0;
            this.lvFotos.UseCompatibleStateImageBehavior = false;
            this.lvFotos.View = System.Windows.Forms.View.Details;
            this.lvFotos.SelectedIndexChanged += new System.EventHandler(this.lvFotos_SelectedIndexChanged);
            // 
            // Configurador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lvFotos);
            this.Name = "Configurador";
            this.Text = "Configurador";
            this.Load += new System.EventHandler(this.Configurador_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvFotos;
    }
}


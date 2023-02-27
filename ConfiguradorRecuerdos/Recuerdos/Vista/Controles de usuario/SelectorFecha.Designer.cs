namespace Recuerdos.Vista.Controles_de_usuario
{
    partial class SelectorFecha
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
            this.rbExacta = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.tbAno2 = new System.Windows.Forms.TextBox();
            this.tbMes2 = new System.Windows.Forms.TextBox();
            this.tbDia2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbAno1 = new System.Windows.Forms.TextBox();
            this.tbMes1 = new System.Windows.Forms.TextBox();
            this.tbDia1 = new System.Windows.Forms.TextBox();
            this.rbRango = new System.Windows.Forms.RadioButton();
            this.rbAproximada = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rbVacia = new System.Windows.Forms.RadioButton();
            this.lblVarios = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rbExacta
            // 
            this.rbExacta.AutoSize = true;
            this.rbExacta.Location = new System.Drawing.Point(54, 2);
            this.rbExacta.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbExacta.Name = "rbExacta";
            this.rbExacta.Size = new System.Drawing.Size(59, 19);
            this.rbExacta.TabIndex = 2;
            this.rbExacta.Text = "Exacta";
            this.rbExacta.UseVisualStyleBackColor = true;
            this.rbExacta.CheckedChanged += new System.EventHandler(this.rbExacta_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(136, 28);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 22);
            this.label5.TabIndex = 13;
            this.label5.Text = "-";
            this.label5.Visible = false;
            // 
            // tbAno2
            // 
            this.tbAno2.Enabled = false;
            this.tbAno2.Location = new System.Drawing.Point(238, 30);
            this.tbAno2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbAno2.Name = "tbAno2";
            this.tbAno2.Size = new System.Drawing.Size(33, 23);
            this.tbAno2.TabIndex = 10;
            this.tbAno2.Visible = false;
            this.tbAno2.TextChanged += new System.EventHandler(this.tbTodos_TextChanged);
            // 
            // tbMes2
            // 
            this.tbMes2.Enabled = false;
            this.tbMes2.Location = new System.Drawing.Point(202, 30);
            this.tbMes2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbMes2.Name = "tbMes2";
            this.tbMes2.Size = new System.Drawing.Size(22, 23);
            this.tbMes2.TabIndex = 9;
            this.tbMes2.Visible = false;
            this.tbMes2.TextChanged += new System.EventHandler(this.tbTodos_TextChanged);
            // 
            // tbDia2
            // 
            this.tbDia2.Enabled = false;
            this.tbDia2.Location = new System.Drawing.Point(166, 30);
            this.tbDia2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbDia2.Name = "tbDia2";
            this.tbDia2.Size = new System.Drawing.Size(22, 23);
            this.tbDia2.TabIndex = 8;
            this.tbDia2.Visible = false;
            this.tbDia2.TextChanged += new System.EventHandler(this.tbTodos_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(188, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 22);
            this.label3.TabIndex = 11;
            this.label3.Text = "/";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(224, 29);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 22);
            this.label4.TabIndex = 12;
            this.label4.Text = "/";
            this.label4.Visible = false;
            // 
            // tbAno1
            // 
            this.tbAno1.Enabled = false;
            this.tbAno1.Location = new System.Drawing.Point(85, 30);
            this.tbAno1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbAno1.Name = "tbAno1";
            this.tbAno1.Size = new System.Drawing.Size(33, 23);
            this.tbAno1.TabIndex = 7;
            this.tbAno1.Visible = false;
            this.tbAno1.TextChanged += new System.EventHandler(this.tbTodos_TextChanged);
            // 
            // tbMes1
            // 
            this.tbMes1.Enabled = false;
            this.tbMes1.Location = new System.Drawing.Point(49, 30);
            this.tbMes1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbMes1.Name = "tbMes1";
            this.tbMes1.Size = new System.Drawing.Size(22, 23);
            this.tbMes1.TabIndex = 6;
            this.tbMes1.Visible = false;
            this.tbMes1.TextChanged += new System.EventHandler(this.tbTodos_TextChanged);
            // 
            // tbDia1
            // 
            this.tbDia1.Enabled = false;
            this.tbDia1.Location = new System.Drawing.Point(14, 30);
            this.tbDia1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbDia1.Name = "tbDia1";
            this.tbDia1.Size = new System.Drawing.Size(22, 23);
            this.tbDia1.TabIndex = 5;
            this.tbDia1.Visible = false;
            this.tbDia1.TextChanged += new System.EventHandler(this.tbTodos_TextChanged);
            // 
            // rbRango
            // 
            this.rbRango.AutoSize = true;
            this.rbRango.Location = new System.Drawing.Point(203, 2);
            this.rbRango.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbRango.Name = "rbRango";
            this.rbRango.Size = new System.Drawing.Size(59, 19);
            this.rbRango.TabIndex = 4;
            this.rbRango.Text = "Rango";
            this.rbRango.UseVisualStyleBackColor = true;
            this.rbRango.CheckedChanged += new System.EventHandler(this.rbExacta_CheckedChanged);
            // 
            // rbAproximada
            // 
            this.rbAproximada.AutoSize = true;
            this.rbAproximada.Location = new System.Drawing.Point(113, 2);
            this.rbAproximada.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbAproximada.Name = "rbAproximada";
            this.rbAproximada.Size = new System.Drawing.Size(90, 19);
            this.rbAproximada.TabIndex = 3;
            this.rbAproximada.Text = "Aproximada";
            this.rbAproximada.UseVisualStyleBackColor = true;
            this.rbAproximada.CheckedChanged += new System.EventHandler(this.rbExacta_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(36, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "/";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(71, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "/";
            this.label2.Visible = false;
            // 
            // rbVacia
            // 
            this.rbVacia.AutoSize = true;
            this.rbVacia.Checked = true;
            this.rbVacia.Location = new System.Drawing.Point(2, 2);
            this.rbVacia.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbVacia.Name = "rbVacia";
            this.rbVacia.Size = new System.Drawing.Size(52, 19);
            this.rbVacia.TabIndex = 1;
            this.rbVacia.TabStop = true;
            this.rbVacia.Text = "Vacía";
            this.rbVacia.UseVisualStyleBackColor = true;
            // 
            // lblVarios
            // 
            this.lblVarios.AutoSize = true;
            this.lblVarios.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.lblVarios.Location = new System.Drawing.Point(262, 4);
            this.lblVarios.Name = "lblVarios";
            this.lblVarios.Size = new System.Drawing.Size(46, 15);
            this.lblVarios.TabIndex = 14;
            this.lblVarios.Text = "(varios)";
            // 
            // SelectorFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblVarios);
            this.Controls.Add(this.rbVacia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbAno2);
            this.Controls.Add(this.tbAno1);
            this.Controls.Add(this.tbMes2);
            this.Controls.Add(this.tbDia2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rbExacta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rbAproximada);
            this.Controls.Add(this.rbRango);
            this.Controls.Add(this.tbMes1);
            this.Controls.Add(this.tbDia1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(310, 62);
            this.Name = "SelectorFecha";
            this.Size = new System.Drawing.Size(310, 62);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbExacta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbAno2;
        private System.Windows.Forms.TextBox tbMes2;
        private System.Windows.Forms.TextBox tbDia2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbAno1;
        private System.Windows.Forms.TextBox tbMes1;
        private System.Windows.Forms.TextBox tbDia1;
        private System.Windows.Forms.RadioButton rbRango;
        private System.Windows.Forms.RadioButton rbAproximada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private RadioButton rbVacia;
        private Label lblVarios;
    }
}

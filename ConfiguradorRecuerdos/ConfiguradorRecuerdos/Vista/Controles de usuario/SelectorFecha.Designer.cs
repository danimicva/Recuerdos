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
            this.gbFecha = new System.Windows.Forms.GroupBox();
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
            this.gbFecha.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbExacta
            // 
            this.rbExacta.AutoSize = true;
            this.rbExacta.Checked = true;
            this.rbExacta.Location = new System.Drawing.Point(6, 19);
            this.rbExacta.Name = "rbExacta";
            this.rbExacta.Size = new System.Drawing.Size(58, 17);
            this.rbExacta.TabIndex = 0;
            this.rbExacta.TabStop = true;
            this.rbExacta.Text = "Exacta";
            this.rbExacta.UseVisualStyleBackColor = true;
            this.rbExacta.CheckedChanged += new System.EventHandler(this.rbExacta_CheckedChanged);
            // 
            // gbFecha
            // 
            this.gbFecha.Controls.Add(this.label5);
            this.gbFecha.Controls.Add(this.tbAno2);
            this.gbFecha.Controls.Add(this.tbMes2);
            this.gbFecha.Controls.Add(this.tbDia2);
            this.gbFecha.Controls.Add(this.label3);
            this.gbFecha.Controls.Add(this.label4);
            this.gbFecha.Controls.Add(this.tbAno1);
            this.gbFecha.Controls.Add(this.tbMes1);
            this.gbFecha.Controls.Add(this.tbDia1);
            this.gbFecha.Controls.Add(this.rbRango);
            this.gbFecha.Controls.Add(this.rbAproximada);
            this.gbFecha.Controls.Add(this.rbExacta);
            this.gbFecha.Controls.Add(this.label1);
            this.gbFecha.Controls.Add(this.label2);
            this.gbFecha.Location = new System.Drawing.Point(0, 0);
            this.gbFecha.Name = "gbFecha";
            this.gbFecha.Size = new System.Drawing.Size(230, 80);
            this.gbFecha.TabIndex = 1;
            this.gbFecha.TabStop = false;
            this.gbFecha.Text = "Fecha";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(103, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 22);
            this.label5.TabIndex = 13;
            this.label5.Text = "-";
            // 
            // tbAno2
            // 
            this.tbAno2.Location = new System.Drawing.Point(187, 43);
            this.tbAno2.Name = "tbAno2";
            this.tbAno2.Size = new System.Drawing.Size(29, 20);
            this.tbAno2.TabIndex = 10;
            // 
            // tbMes2
            // 
            this.tbMes2.Location = new System.Drawing.Point(156, 43);
            this.tbMes2.Name = "tbMes2";
            this.tbMes2.Size = new System.Drawing.Size(19, 20);
            this.tbMes2.TabIndex = 9;
            // 
            // tbDia2
            // 
            this.tbDia2.Location = new System.Drawing.Point(126, 43);
            this.tbDia2.Name = "tbDia2";
            this.tbDia2.Size = new System.Drawing.Size(19, 20);
            this.tbDia2.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(144, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 22);
            this.label3.TabIndex = 11;
            this.label3.Text = "/";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(174, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 22);
            this.label4.TabIndex = 12;
            this.label4.Text = "/";
            // 
            // tbAno1
            // 
            this.tbAno1.Location = new System.Drawing.Point(66, 43);
            this.tbAno1.Name = "tbAno1";
            this.tbAno1.Size = new System.Drawing.Size(29, 20);
            this.tbAno1.TabIndex = 5;
            // 
            // tbMes1
            // 
            this.tbMes1.Location = new System.Drawing.Point(35, 43);
            this.tbMes1.Name = "tbMes1";
            this.tbMes1.Size = new System.Drawing.Size(19, 20);
            this.tbMes1.TabIndex = 4;
            // 
            // tbDia1
            // 
            this.tbDia1.Location = new System.Drawing.Point(5, 43);
            this.tbDia1.Name = "tbDia1";
            this.tbDia1.Size = new System.Drawing.Size(19, 20);
            this.tbDia1.TabIndex = 3;
            // 
            // rbRango
            // 
            this.rbRango.AutoSize = true;
            this.rbRango.Location = new System.Drawing.Point(159, 19);
            this.rbRango.Name = "rbRango";
            this.rbRango.Size = new System.Drawing.Size(57, 17);
            this.rbRango.TabIndex = 2;
            this.rbRango.Text = "Rango";
            this.rbRango.UseVisualStyleBackColor = true;
            this.rbRango.CheckedChanged += new System.EventHandler(this.rbExacta_CheckedChanged);
            // 
            // rbAproximada
            // 
            this.rbAproximada.AutoSize = true;
            this.rbAproximada.Location = new System.Drawing.Point(70, 19);
            this.rbAproximada.Name = "rbAproximada";
            this.rbAproximada.Size = new System.Drawing.Size(80, 17);
            this.rbAproximada.TabIndex = 1;
            this.rbAproximada.Text = "Aproximada";
            this.rbAproximada.UseVisualStyleBackColor = true;
            this.rbAproximada.CheckedChanged += new System.EventHandler(this.rbExacta_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "/";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(53, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "/";
            // 
            // SelectorFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbFecha);
            this.MaximumSize = new System.Drawing.Size(230, 80);
            this.MinimumSize = new System.Drawing.Size(230, 80);
            this.Name = "SelectorFecha";
            this.Size = new System.Drawing.Size(230, 80);
            this.gbFecha.ResumeLayout(false);
            this.gbFecha.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbExacta;
        private System.Windows.Forms.GroupBox gbFecha;
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
    }
}

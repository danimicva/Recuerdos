using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recuerdos.Utils
{
    public partial class FrmPedirTexto : Form
    {
        private readonly string mTitulo;
        private readonly string mTexto;

        public string Input = "";

        public FrmPedirTexto(string titulo = "", string texto = "") {
            InitializeComponent();
            mTitulo = titulo;
            mTexto = texto;

            DialogResult = DialogResult.Cancel;
        }

        private void FrmPedirTexto_Load(object sender, EventArgs e) {
            Text = mTitulo;
            lblTexto.Text = mTexto;
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(tbInput.Text)) {
                MessageBox.Show("Tienes que poner algo");
                return;
            }

            Input = tbInput.Text;
            DialogResult = DialogResult.OK;

            Close();
        }

        private void tbInput_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyValue == (int) Keys.Enter)
                btnOk.PerformClick();
        }
    }
}

using Recuerdos.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recuerdos.Vista
{
    public partial class ResolvedorDuplicados : Form
    {
        
        private Biblioteca mBiblioteca;
        private List<Recuerdo> mDuplicados;
        private Image mImagenActual = null;
        private bool mAñadiendo = false;

        public ResolvedorDuplicados(Biblioteca biblioteca) {
            InitializeComponent();
            mBiblioteca = biblioteca;
        }

        private void ResolvedorDuplicados_Load(object sender, EventArgs e) {
            buscarDuplicados();
        }

        private void buscarDuplicados() {
            
            mDuplicados = null;

            foreach (Recuerdo r in mBiblioteca.Recuerdos.Where(r => 
                        !string.IsNullOrEmpty(r.Md5) 
                        && !r.Ruta.Contains("mp4") // TODO a quitar cuando haya tipo de dato o cuando se puedan ver vídeos
                    )) {
                List<Recuerdo> temp = mBiblioteca.Recuerdos.Where(rr => rr.Md5 == r.Md5).ToList();
                if(temp.Count > 1) {
                    mDuplicados = temp;
                    break;
                }
            }

            if(mDuplicados == null) {
                MessageBox.Show("¡No quedan duplicados en la biblioteca!");
                Close();
                return;
            }

            cargarDuplicados();
        }

        private void cargarDuplicados() {

            mAñadiendo = true;
            
            btnElegirDefinitiva.Enabled = false;
            dgvDuplicados.Rows.Clear();
            foreach(Recuerdo r in mDuplicados) {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = r;
                DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                cell.Value = r.Ruta;
                row.Cells.Add(cell);
                dgvDuplicados.Rows.Add(row);
            }
            dgvDuplicados.ClearSelection();
            mAñadiendo = false;
            dgvDuplicados.Rows[0].Selected = true;
            dgvDuplicados.Focus();
        }

        private void btnElegirDefinitiva_Click(object sender, EventArgs e) {
            if(dgvDuplicados.SelectedRows.Count == 0) {
                MessageBox.Show("Tienes que elegir una fila.");
                return;
            }

            Recuerdo elegido = dgvDuplicados.SelectedRows[0].Tag as Recuerdo;
            if(elegido == null) {
                MessageBox.Show("La fila elegida no tiene un recuerdo en el Tag");
                return;
            }

            if(MessageBox.Show("¿Estás seguro que quieres la foto con ruta: " + elegido.Ruta + "?" + Environment.NewLine + "Se borrarán las demás fotos.",
                    "Elegir foto", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                if (mImagenActual != null)
                    mImagenActual.Dispose();

                mDuplicados.Remove(elegido);

                mBiblioteca.BorrarRecuerdos(mDuplicados);

                //MessageBox.Show("Duplicados borrados correctamente.");
                buscarDuplicados();
            }
        }

        private void dgvDuplicados_SelectionChanged(object sender, EventArgs e) {

            if (mAñadiendo)
                return;
           
            btnElegirDefinitiva.Enabled = dgvDuplicados.SelectedRows.Count == 1;

            if (dgvDuplicados.SelectedRows.Count == 0)
                return;

            Recuerdo elegido = dgvDuplicados.SelectedRows[0].Tag as Recuerdo;
            if (elegido == null)
                return;

            try {
                if (mImagenActual != null)
                    mImagenActual.Dispose();

                mImagenActual = Image.FromFile(elegido.Ruta);
                pbImagen.Image = mImagenActual;
            } catch (Exception) {
                MessageBox.Show("No se encuentra la ruta de la imagen: " + mDuplicados[0].Ruta);
                Close();
            }
        }

        private void dgvDuplicados_KeyDown(object sender, KeyEventArgs e) {

            if (e.KeyCode == Keys.Enter) {

                e.SuppressKeyPress = true;

                if (dgvDuplicados.SelectedRows.Count == 1)
                    btnElegirDefinitiva.PerformClick();
            }
        }
    }
}

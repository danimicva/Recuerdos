using Recuerdos.Modelo;
using Recuerdos.Sql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recuerdos.Vista
{
    public partial class Procesador : Form {
        private Biblioteca mBiblioteca;
        private List<Recuerdo> mRecuerdosSeleccionados = new List<Recuerdo>();
        private Image mImagenMostrada = null;
        private List<Recuerdo> mRecuerdosModificados = new List<Recuerdo>();
        
        
        private TreeNode mLastSelected = null;

        private bool mActualizandoUI = false;

        public Procesador(Biblioteca biblioteca) {
            InitializeComponent();
            mBiblioteca = biblioteca;
        }

        private void Procesador_Load(object sender, EventArgs e) {
            
            iniciarUI();
            actualizarUI();
        }


        #region Gestión del explorador

        private void PopulateTreeView() {
            TreeNode rootNode;

            DirectoryInfo info = new DirectoryInfo(mBiblioteca.Ruta);
            if (info.Exists) {
                rootNode = new TreeNode(info.Name) {
                    Tag = info
                };
                GetDirectories(info.GetDirectories(), rootNode);
                treeView1.Nodes.Add(rootNode);
            }
        }

        private void GetDirectories(DirectoryInfo[] subDirs, TreeNode nodeToAddTo) {

            TreeNode aNode;
            DirectoryInfo[] subSubDirs;
            foreach (DirectoryInfo subDir in subDirs.Where(s => s.Name != Biblioteca.NombrePapelera)) {
                aNode = new TreeNode(subDir.Name, 0, 0);
                aNode.Tag = subDir;
                aNode.ImageKey = "folder";
                subSubDirs = subDir.GetDirectories();
                if (subSubDirs.Length != 0) {
                    GetDirectories(subSubDirs, aNode);
                }
                nodeToAddTo.Nodes.Add(aNode);
            }
        }

        void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {

            TreeNode newSelected = e.Node;
            lvFicheros.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;

            if (mLastSelected != null) {
                mLastSelected.NodeFont = new System.Drawing.Font(
                mLastSelected.TreeView.Font,
                mLastSelected.TreeView.Font.Style);
            }

            newSelected.NodeFont = new Font(
                newSelected.TreeView.Font,
                newSelected.TreeView.Font.Style | FontStyle.Bold);

            // Si no no se ve bien el texto
            newSelected.Text = newSelected.Text;

            /*
            foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories().Where(s => s.Name != Biblioteca.NombrePapelera)) {
                item = new ListViewItem(dir.Name, 0);
                subItems = new ListViewItem.ListViewSubItem[]
                    {new ListViewItem.ListViewSubItem(item, "Directory"),
             new ListViewItem.ListViewSubItem(item,
                dir.LastAccessTime.ToShortDateString())};
                item.SubItems.AddRange(subItems);
                lvFicheros.Items.Add(item);
            }
            */
            foreach (FileInfo file in nodeDirInfo.GetFiles().Where(f => f.Name != GestorBBDD.NombreBBDD)) {
                item = new ListViewItem(file.Name, 1);
                subItems = new ListViewItem.ListViewSubItem[]
                    { new ListViewItem.ListViewSubItem(item, "File")};
                item.Tag = file;
                item.SubItems.AddRange(subItems);
                lvFicheros.Items.Add(item);
            }

            lvFicheros.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            mLastSelected = newSelected;
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {

            if (mImagenMostrada != null) {
                mImagenMostrada.Dispose();
                pbFotoElegida.Image = null;
            }

            actualizarSeleccionados();


            if (mRecuerdosSeleccionados.Count == 1) {
                mImagenMostrada = Image.FromFile(mRecuerdosSeleccionados[0].Ruta);
                pbFotoElegida.Image = mImagenMostrada;
            }

        }

        private void actualizarSeleccionados() {
            mRecuerdosSeleccionados.Clear();

            foreach (ListViewItem item in lvFicheros.SelectedItems) {
                FileInfo file = item.Tag as FileInfo;
                if (file == null)
                    throw new Exception("El item del listview no tiene Tag");

                Recuerdo r = mBiblioteca.Recuerdos.FirstOrDefault(rr => rr.Ruta == file.FullName);
                if (r == null)
                    throw new Exception("No se encuentra el recuerdo para el fichero: " + file.FullName);

                mRecuerdosSeleccionados.Add(r);
            }

            actualizarUI();
        }


        #endregion


        #region Gestion UI


        private void iniciarUI() {

            mActualizandoUI = true;

            PopulateTreeView();

            mBiblioteca.Eventos.ForEach(e => {
                cbDetallesEvento.Items.Add(e);
            });

            //Tremendamente inseguro, cambiarlo en algún momento
            if (treeView1.Nodes.Count > 0) {
                treeView1_NodeMouseClick(null, new TreeNodeMouseClickEventArgs(treeView1.Nodes[0], MouseButtons.Left, 0, 0, 0));
                treeView1.SelectedNode = treeView1.Nodes[0];
                treeView1.Nodes[0].Expand();
                treeView1.Focus();
            }

            mActualizandoUI = false;

        }

        private void actualizarUI() {

            bool haySeleccionados = mRecuerdosSeleccionados.Count() > 0;
            mActualizandoUI = true;


            tbDetallesLugar.Enabled = haySeleccionados;
            cbDetallesEvento.Enabled = haySeleccionados;
            lblCambios.Text = "Cambios: " + mRecuerdosModificados.Count();


            if (haySeleccionados) {
                tbDetallesLugar.Text = mRecuerdosSeleccionados.Any(r => r.Lugar != mRecuerdosSeleccionados[0].Lugar) ? "(varios)" : mRecuerdosSeleccionados[0].Lugar;
                if (mRecuerdosSeleccionados.Any(r => r.Evento != mRecuerdosSeleccionados[0].Evento)) {
                    cbDetallesEvento.SelectedItem = null;
                    cbDetallesEvento.Text = "(varios)";
                } else
                    cbDetallesEvento.SelectedItem = mRecuerdosSeleccionados[0].Evento;
            } else {
                tbDetallesLugar.Text = "";
                cbDetallesEvento.SelectedItem = null;
                
            }

            mActualizandoUI = false;
        }

        #endregion

        #region Eventos de controles


        private void btnDetallesNuevoEvento_Click(object sender, EventArgs e) {
            EventoForm form = new EventoForm(mBiblioteca);
            if (form.ShowDialog() == DialogResult.OK) {
                cbDetallesEvento.Items.Add(form.Evento);
                // ´ñadirlo ya lo selecciona y se desencadena todo
                //cbDetallesEvento.SelectedItem = form.Evento;
                //elegirEvento(form.Evento);
            }
        }


        private void cbDetallesEvento_SelectedIndexChanged(object sender, EventArgs e) {

            if (mActualizandoUI)
                return;

            Evento evento = cbDetallesEvento.SelectedItem as Evento;

            mRecuerdosSeleccionados.ForEach(r => {
                if (r.Evento != evento) {
                    r.Evento = evento;
                    if(!mRecuerdosModificados.Contains(r))
                        mRecuerdosModificados.Add(r);
                }
                //mBiblioteca.GuardarRecuerdo(r);
            });

            actualizarUI();
        }

        private void btnGuardar_Click(object sender, EventArgs e) {
            mRecuerdosModificados.ForEach(r => {
                mBiblioteca.GuardarRecuerdo(r);
            });

            mRecuerdosModificados.Clear();
            actualizarUI();
        }


        private void btnDeshacer_Click(object sender, EventArgs e) {
            mBiblioteca.RecuperarRecuerdos(mRecuerdosModificados);
            mRecuerdosModificados.Clear();
            actualizarUI();
        }

        private void btnQuitarEvento_Click(object sender, EventArgs e) {
            cbDetallesEvento.SelectedItem = null;
        }


        private void tbCualquiera_TextChanged(object sender, EventArgs e) {


            if (mActualizandoUI)
                return;

            mRecuerdosSeleccionados.ForEach(r => {

                if (sender == tbDetallesLugar)
                    r.Lugar = tbDetallesLugar.Text;
                else if (sender == tbDetallesFuente)
                    r.Fuente = tbDetallesFuente.Text;
                else if (sender == tbDescripcion)
                    r.Descripcion = tbDescripcion.Text;
                
                if (!mRecuerdosModificados.Contains(r))
                    mRecuerdosModificados.Add(r);
                
            });

            actualizarUI();

        }

        #endregion

    }
}

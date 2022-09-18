using Recuerdos.Modelo;
using Recuerdos.Modelo.BBDD;
using System.Data;

namespace Recuerdos.Vista
{
    public partial class Procesador : Form {
        private readonly Biblioteca mBiblioteca;
        
        private TreeNode? mLastSelected = null;


        public Procesador(Biblioteca biblioteca) {
            InitializeComponent();
            mBiblioteca = biblioteca;
        }

        private void Procesador_Load(object sender, EventArgs e) {
            
            iniciarUI(); 

        }

        #region Gestión del explorador

        private void PopulateTreeView() {
            TreeNode rootNode;

            DirectoryInfo info = new(mBiblioteca.Ruta);
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
                aNode = new(subDir.Name, 0, 0) {
                    Tag = subDir,
                    ImageKey = "folder"
                };
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
                ListViewItem item = new(file.Name, 1);
                ListViewItem.ListViewSubItem[] subItems = new ListViewItem.ListViewSubItem[]
                    { new ListViewItem.ListViewSubItem(item, "File")};
                item.Tag = file;
                item.SubItems.AddRange(subItems);
                lvFicheros.Items.Add(item);
            }

            lvFicheros.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            mLastSelected = newSelected;
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {

            List<Recuerdo> rec = new();

            foreach (ListViewItem item in lvFicheros.SelectedItems) {
                if (item.Tag is not FileInfo file)
                    throw new Exception("El item del listview no tiene Tag");

                Recuerdo? r = mBiblioteca.Recuerdos.FirstOrDefault(rr => rr.Ruta == file.FullName);
                if (r == null)
                    throw new Exception("No se encuentra el recuerdo para el fichero: " + file.FullName);

                rec.Add(r);
            }


            visorRecuerdo1.Recuerdos = rec;

        }


        #endregion


        #region Gestion UI


        private void iniciarUI() {

            visorRecuerdo1.Biblioteca = mBiblioteca;
            
            PopulateTreeView();

            //Tremendamente inseguro, cambiarlo en algún momento
            if (treeView1.Nodes.Count > 0) {
                treeView1_NodeMouseClick(this, new TreeNodeMouseClickEventArgs(treeView1.Nodes[0], MouseButtons.Left, 0, 0, 0));
                treeView1.SelectedNode = treeView1.Nodes[0];
                treeView1.Nodes[0].Expand();
                treeView1.Focus();
            }

        }

        #endregion


    }
}

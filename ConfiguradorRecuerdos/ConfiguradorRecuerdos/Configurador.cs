using ConfiguradorRecuerdos.Nucleo;
using ConfiguradorRecuerdos.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace ConfiguradorRecuerdos
{
    public partial class Configurador : Form
    {

        private static  Size tamanoImagenes = new Size(100, 100);

        private SelectedListViewItemCollection mFotosSeleccionadas;
        private Biblioteca mBiblioteca;

        public Configurador()
        {
            InitializeComponent();
        }

        private void Configurador_Load(object sender, EventArgs e)
        {
            //solicitarConfiguracion();
            cargarDirectorio("D:\\Recuerdos\\Fotos por año\\");
        }

        private void solicitarConfiguracion()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    cargarDirectorio(fbd.SelectedPath);
            }
        }

        private void cargarDirectorio(string ruta)
        {
            mBiblioteca = new Biblioteca(ruta);

            listarImagenes();

        }

        private void listarImagenes() {

            int max = 100;

            int.TryParse(tbFiltroCantidad.Text, out max);


            List<ListViewItem> items = new List<ListViewItem>();
            ImageList imageListSmall = new ImageList();

            for (int i = 0; i < mBiblioteca.Recuerdos.Count && i < max; i++) {
                Recuerdo a = mBiblioteca.Recuerdos[i];
                items.Add(new ListViewItem(a.Ruta, i) {Tag = a});
                imageListSmall.Images.Add(UtilsImagen.generarImagen(a.Ruta, tamanoImagenes));
            }

            lvFotos.Items.AddRange(items.ToArray());

            // Create columns for the items and subitems.
            // Width of -2 indicates auto-size.
            lvFotos.Columns.Add("Item Column", 300, HorizontalAlignment.Left);

            imageListSmall.ImageSize = new Size(100, 100);
            imageListSmall.ColorDepth = ColorDepth.Depth32Bit;

            //Assign the ImageList objects to the ListView.
            lvFotos.SmallImageList = imageListSmall;

            //lvFotos.Items[0].Selected = true;
        }

        private void inputs_KeyPress_Guardar(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Enter)
                GuardarCambios();
            else {
                lvFotos.Enabled = false;
                btnDeshacer.Enabled = true;
                btnGuardar.Enabled= true;
            }
        }

        private void GuardarCambios() {

            foreach (ListViewItem item in mFotosSeleccionadas) {
                Recuerdo a = (Recuerdo) item.Tag;
                if (tbNombre.Text != "<varios>")
                    a.Nombre = tbNombre.Text;
                if (tbDia.Text != "<?>")
                    a.Dia = string.IsNullOrEmpty(tbDia.Text) ? (int?) null : int.Parse(tbDia.Text);
                if (tbMes.Text != "<?>")
                    a.Mes = string.IsNullOrEmpty(tbMes.Text) ? (int?) null : int.Parse(tbMes.Text);
                if (tbAnno.Text != "<?>")
                    a.Año = string.IsNullOrEmpty(tbAnno.Text) ? (int?) null : int.Parse(tbAnno.Text);
                if (tbLugar.Text != "<varios>")
                    a.Lugar = tbLugar.Text;
            }

            lvFotos.Enabled = true;
            btnDeshacer.Enabled = false;
            btnGuardar.Enabled = false;
            mBiblioteca.GuardarSql();
        }

        private void lvFotos_SelectedIndexChanged(object sender, EventArgs e) {

            mFotosSeleccionadas = lvFotos.SelectedItems;

            cargarInformacionSeleccion();
        }

        private void cargarInformacionSeleccion() {
            reiniciarInputs();

            if (mFotosSeleccionadas.Count == 0)
                return;

            List<Recuerdo> archivos = new List<Recuerdo>();
            foreach(ListViewItem item in mFotosSeleccionadas)
                archivos.Add((Recuerdo) item.Tag);


            tbNombre.Text = archivos.Count == 1 || !archivos.Any(a => a.Nombre != archivos[0].Nombre) ? archivos[0].Nombre : "<varios>";
            tbDia.Text = archivos.Count == 1 || !archivos.Any(a => a.Dia != archivos[0].Dia) ? archivos[0].Dia + "" : "<?>";
            tbMes.Text = archivos.Count == 1 || !archivos.Any(a => a.Mes != archivos[0].Mes) ? archivos[0].Mes + "" : "<?>";
            tbAnno.Text = archivos.Count == 1 || !archivos.Any(a => a.Año != archivos[0].Año) ? archivos[0].Año + "" : "<?>";
            tbLugar.Text = archivos.Count == 1 || !archivos.Any(a => a.Lugar != archivos[0].Lugar) ? archivos[0].Lugar : "<varios>";
        }

        private void reiniciarInputs() {
            tbNombre.Text = "";
            tbDia.Text = "";
            tbMes.Text = "";
            tbAnno.Text = "";
            tbLugar.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e) {
            GuardarCambios();
        }

        private void btnDeshacer_Click(object sender, EventArgs e) {
            cargarInformacionSeleccion();

            lvFotos.Enabled = true;
            btnDeshacer.Enabled = false;
            btnGuardar.Enabled = false;
        }

        private void Configurador_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Link;
        }

        private void Configurador_DragDrop(object sender, DragEventArgs e) {

            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            
            foreach(string s in fileList) {
                mBiblioteca.AñadirArchivo(s);
            }
        }
    }
}

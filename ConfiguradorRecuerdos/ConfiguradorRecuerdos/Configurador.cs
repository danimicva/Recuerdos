using ConfiguradorRecuerdos.Nucleo;
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

namespace ConfiguradorRecuerdos
{
    public partial class Configurador : Form
    {

        private Biblioteca mBiblioteca;

        public Configurador()
        {
            InitializeComponent();
        }

        private void Configurador_Load(object sender, EventArgs e)
        {
            solicitarConfiguracion();
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
            mBiblioteca = new Biblioteca();
            mBiblioteca.Archivos.AddRange(Directorio.obtenerTodosArchivos(ruta));


            List<ListViewItem> items = new List<ListViewItem>();
            ImageList imageListLarge = new ImageList();
            ImageList imageListSmall = new ImageList();

            for (int i = 0; i < mBiblioteca.Archivos.Count && i < 10; i++)
            {
                Archivo a = mBiblioteca.Archivos[i];
                items.Add(new ListViewItem(a.Nombre, i));
                imageListLarge.Images.Add(Bitmap.FromFile(a.Ruta));
                imageListSmall.Images.Add(Bitmap.FromFile(a.Ruta));
            }

            lvFotos.Items.AddRange(items.ToArray());

            // Create columns for the items and subitems.
            // Width of -2 indicates auto-size.
            lvFotos.Columns.Add("Item Column", -2 , HorizontalAlignment.Left);

            //Assign the ImageList objects to the ListView.
            lvFotos.LargeImageList = imageListLarge;
            lvFotos.SmallImageList = imageListSmall;

        }

        private void lvFotos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

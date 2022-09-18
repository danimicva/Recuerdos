using Recuerdos.Modelo;
using Recuerdos.Properties;
using Recuerdos.Sql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recuerdos.Vista
{
    public partial class Principal : Form
    {
        private Biblioteca mBiblioteca;
        private Thread mHilo = null;

        public Principal() {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e) {

            if (!string.IsNullOrEmpty(Settings.Default.RutaInicial))
                cargarDirectorio(Settings.Default.RutaInicial);
            else
                solicitarConfiguracion();
            //cargarDirectorio("C:\\Users\\Blas de Lezo\\Desktop\\prueba_recuerdos");
        }

        private void solicitarConfiguracion() {
            using (var fbd = new FolderBrowserDialog()) {
                fbd.Description = "Elige la ruta de la biblioteca";
                
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    cargarDirectorio(fbd.SelectedPath);
                else
                    Close();
            }
        }

        private void cargarDirectorio(string ruta) {

            Settings.Default.RutaInicial = ruta;
            Settings.Default.Save();

            mBiblioteca = new Biblioteca(ruta);
            mBiblioteca.IniciarBiblioteca();

            actualizarResumen();
        }

        #region GUI

        private void actualizarResumen() {
            lblTotalRecuerdos.Text = "Total: " + mBiblioteca.Recuerdos.Count();
            lblParaRevisar.Text = "A revisar: " + mBiblioteca.Recuerdos.Count(r => !r.Revisado);
            lblNuevos.Text = "Nuevos: " + mBiblioteca.Recuerdos.Count(r => r.Nuevo);
            lblPerdidos.Text = "Perdidos: " + mBiblioteca.Recuerdos.Count(r => r.Borrado);
            lblResumenConMd5.Text = "Sin Md5: " + mBiblioteca.Recuerdos.Count(r => string.IsNullOrEmpty(r.Md5));

            tsslProceso.Text = "Mostrando biblioteca";
            tsslEstado.Text = "";
        }



        private void activarAcciones(bool activar) {

            btnAccionActualizarBiblioteca.Enabled = activar;
            btnAccionCalcularMd5.Enabled = activar;
            btnAccionBuscarDuplicados.Enabled = activar;

            btnCambiarBiblioteca.Enabled = activar;

            btnAccionParar.Enabled = !activar;
        }

        #endregion

        #region Acciones

       
        private void btnAccionesActualizarBiblioteca_Click(object sender, EventArgs e) {

            empezarProcesoAsincrono("Actualizando biblioteca...", () => {
                mBiblioteca.IncorporarFicherosNuevos(
                    (nuevos, ultimoLeido) => actualizarMensaje(nuevos + " ficheros nuevos detectados (" + ultimoLeido + ")"),
                    (total) => procesoFinalizado("Se han detectado " + total + " ficheros nuevos")
                );
            });

        }
        private void btnAccionesCalcularMd5_Click(object sender, EventArgs e) {
            int md5Restantes = mBiblioteca.Recuerdos.Count(r => string.IsNullOrEmpty(r.Md5));
            empezarProcesoAsincrono("Actualizando Md5...", () => {
                mBiblioteca.CalcularMd5(
                    (nuevos, ultimoCalculado) => actualizarMensaje("Calculados " + nuevos + "/" + md5Restantes + " MD5. (" + ultimoCalculado + ")"),
                    (total) => procesoFinalizado("Se ha calculado el MD5 de " + total + " ficheros")
                    );
            });
        }

        private void btnAccionesBuscarDuplicados_Click(object sender, EventArgs e) {
            ResolvedorDuplicados res = new ResolvedorDuplicados(mBiblioteca);
            res.ShowDialog();
            actualizarResumen();
        }


        private void btnAccionParar_Click(object sender, EventArgs e) {
            pararAccion();
        }


        #endregion

        #region Procesos asíncronos
        private void empezarProcesoAsincrono(string mensaje, ThreadStart proceso) {
            activarAcciones(false);

            tsslProceso.Text = mensaje;
            mHilo = new Thread(proceso);

            mHilo.Start();
            
        }

        private bool actualizarMensaje(string mensaje) {

            BeginInvoke((MethodInvoker)delegate {
                tsslEstado.Text = mensaje;
            });

            return true;
        }

        private bool procesoFinalizado(string mensaje) {
            BeginInvoke((MethodInvoker)delegate {
                MessageBox.Show(mensaje);
                actualizarResumen();

                activarAcciones(true);
            });

            mHilo = null;

            return true;
        }

        #endregion


        private void btnCambiarBiblioteca_Click(object sender, EventArgs e) {
            solicitarConfiguracion();
            actualizarResumen();
        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e) {
            pararAccion();
        }

        private void pararAccion() {
            if (mHilo != null)
                mHilo.Abort();

            mBiblioteca.PararBBDD();

            activarAcciones(true);
            actualizarResumen();
        }

        private void btnProcesar_Click(object sender, EventArgs e) {
            Procesador p = new Procesador(mBiblioteca);
            p.ShowDialog();
        }
    }
}

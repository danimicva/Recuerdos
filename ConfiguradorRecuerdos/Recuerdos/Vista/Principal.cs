using Recuerdos.Modelo;
using Recuerdos.Properties;
using Recuerdos.Vista.Gestores;

namespace Recuerdos.Vista
{
    public partial class Principal : Form
    {
        private Biblioteca? mBiblioteca;
        private Thread? mHilo;

        public Principal() {
            InitializeComponent();
            mHilo = null;
            mBiblioteca = null;
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
            }
        }

        private void cargarDirectorio(string ruta) {

            Settings.Default.RutaInicial = ruta;
            Settings.Default.Save();

            mBiblioteca = new Biblioteca(ruta);
            string ret = mBiblioteca.IniciarBiblioteca();
            if (!string.IsNullOrEmpty(ret)) {
                MessageBox.Show("Error iniciando la biblioteca: " + ret);
                mBiblioteca = null;
            }

            actualizarUI();
        }

        #region GUI

        private void actualizarUI() {

            

            btnAccionActualizarBiblioteca.Enabled =
                btnAccionBuscarDuplicados.Enabled =
                btnAccionCalcularMd5.Enabled =
                btnActualizarBBDD.Enabled =
                btnGestionarEventos.Enabled =
                btnPersonas.Enabled =
                btnProcesar.Enabled = mBiblioteca != null;

            if (mBiblioteca == null) {
                lblTotalRecuerdos.Text = 
                lblParaRevisar.Text = 
                lblNuevos.Text = 
                lblPerdidos.Text = 
                lblResumenConMd5.Text = 
                lblTotalEventos.Text = 
                lblTotalPersonas.Text = 
                tsslProceso.Text = 
                tsslEstado.Text = "Error leyendo la biblioteca";
            } else {
                lblTotalRecuerdos.Text = "Total: " + mBiblioteca.Recuerdos.Count;
                lblParaRevisar.Text = "A revisar: " + mBiblioteca.Recuerdos.Count(r => !r.Revisado);
                lblNuevos.Text = "Nuevos: " + mBiblioteca.Recuerdos.Count(r => r.Nuevo);
                lblPerdidos.Text = "Perdidos: " + mBiblioteca.Recuerdos.Count(r => r.Borrado);
                lblResumenConMd5.Text = "Sin Md5: " + mBiblioteca.Recuerdos.Count(r => string.IsNullOrEmpty(r.Md5));

                lblTotalEventos.Text = "Total: " + mBiblioteca.Eventos.Count;
                lblTotalPersonas.Text = "Total: " + mBiblioteca.Personas.Count;

                tsslProceso.Text = "Mostrando biblioteca";
                tsslEstado.Text = "";
            }

            
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

            if (mBiblioteca == null)
                return;

            empezarProcesoAsincrono("Actualizando biblioteca...", () => {
                mBiblioteca.IncorporarFicherosNuevos(
                    (nuevos, ultimoLeido) => actualizarMensaje(nuevos + " ficheros nuevos detectados (" + ultimoLeido + ")"),
                    (total) => procesoFinalizado("Se han detectado " + total + " ficheros nuevos")
                );
            });

        }
        private void btnAccionesCalcularMd5_Click(object sender, EventArgs e) {

            if (mBiblioteca == null)
                return;

            int md5Restantes = mBiblioteca.Recuerdos.Count(r => string.IsNullOrEmpty(r.Md5));
            empezarProcesoAsincrono("Actualizando Md5...", () => {
                mBiblioteca.CalcularMd5(
                    (nuevos, ultimoCalculado) => actualizarMensaje("Calculados " + nuevos + "/" + md5Restantes + " MD5. (" + ultimoCalculado + ")"),
                    (total) => procesoFinalizado("Se ha calculado el MD5 de " + total + " ficheros")
                    );
            });
        }

        private void btnAccionesBuscarDuplicados_Click(object sender, EventArgs e) {

            if (mBiblioteca == null)
                return;

            ResolvedorDuplicados res = new ResolvedorDuplicados(mBiblioteca);
            res.ShowDialog();
            actualizarUI();
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
                actualizarUI();

                activarAcciones(true);
            });

            mHilo = null;

            return true;
        }

        #endregion


        private void btnCambiarBiblioteca_Click(object sender, EventArgs e) {
            solicitarConfiguracion();
            actualizarUI();
        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e) {
            pararAccion();
        }

        private void pararAccion() {


            if (mHilo != null)
                mHilo.Abort();


            if (mBiblioteca == null)
                return;

            mBiblioteca.PararBBDD();

            activarAcciones(true);
            actualizarUI();
        }

        private void btnProcesar_Click(object sender, EventArgs e) {

            if (mBiblioteca == null)
                return;

            Procesador p = new Procesador(mBiblioteca);
            p.ShowDialog();
            actualizarUI();
        }

        private void btnGestionarEventos_Click(object sender, EventArgs e) {

            if (mBiblioteca == null)
                return;

            GestorEventos gestor = new(mBiblioteca);

            gestor.ShowDialog();
            actualizarUI();
        }

        private void btnActualizarBBDD_Click(object sender, EventArgs e) {

            if (mBiblioteca == null)
                return;

            cargarDirectorio(mBiblioteca.Ruta);
        }

        private void btnPersonas_Click(object sender, EventArgs e) {
            if (mBiblioteca == null)
                return;

            GestorPersonas gestor = new(mBiblioteca);

            gestor.ShowDialog();
            actualizarUI();
        }
    }
}

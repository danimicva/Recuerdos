using Recuerdos.Modelo;
using Recuerdos.Utils;

namespace Recuerdos.Vista.Gestores
{
    public partial class GestorEventos : Form
    {
        private Biblioteca? mBiblioteca;

        private Evento? mEventoActual = null;

        private bool mActualizandoUi = false;

        public GestorEventos(Biblioteca? biblioteca = null) {
            InitializeComponent();

            mBiblioteca = biblioteca;
        }

        private void GestorEventos_Load(object sender, EventArgs e) {

            if (mBiblioteca == null)
                return;

            iniciarUI();

            if (mBiblioteca.Eventos.Count > 0)
                lbEventos.SelectedItem = lbEventos.Items[0];
            evEvento.Biblioteca = mBiblioteca;
        }

        private void iniciarUI() {
            if (mBiblioteca == null)
                return;

            evEvento.Evento = null;
            lbEventos.Items.Clear();

            mBiblioteca.Eventos.ForEach(e => {
                lbEventos.Items.Add(e);
            });
        }


        private void lbEventos_SelectedIndexChanged(object sender, EventArgs e) {

            if (mBiblioteca == null || mActualizandoUi)
                return;

            Evento? ev = lbEventos.SelectedItem as Evento;

            comprobarModificado();

            mActualizandoUi = true;
            lbEventos.SelectedItem = ev;
            mActualizandoUi = false;

            elegirEvento(ev);
        }

        private void comprobarModificado() {
            if (mEventoActual != null && evEvento.Modificado) {
                if (MessageBox.Show("El evento se ha modificado. ¿Guardar los cambios?",
                        "Evento modificado", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    btnGuardar.PerformClick();
                } else { // Deshacemos
                    if (mEventoActual.IdElemento == null) {
                        lbEventos.Items.Remove(mEventoActual);
                    }
                }
            }
        }

        private void elegirEvento(Evento? e) {
            mEventoActual = e;

            evEvento.Evento = e?.Clonar();
        }

        private void btnBorrar_Click(object sender, EventArgs e) {

            if (mEventoActual == null || mBiblioteca == null)
                return;

            mBiblioteca.BorrarEvento(mEventoActual);

            lbEventos.Items.Remove(mEventoActual);

        }

        private void btnGuardar_Click(object sender, EventArgs e) {

            // Recogemos el evento actualizado
            Evento? aGuardar = evEvento.Evento;

            if (mBiblioteca == null || aGuardar == null || mEventoActual == null)
                return;

            mBiblioteca.GuardarEvento(aGuardar);
            evEvento.Modificado = false;

            int indice = lbEventos.Items.IndexOf(mEventoActual);

            mActualizandoUi = true;
            lbEventos.Items.RemoveAt(indice);
            lbEventos.Items.Insert(indice, aGuardar);
            lbEventos.SelectedItem = aGuardar;
            elegirEvento(aGuardar);
            mActualizandoUi = false;

        }

        private void btnDeshacer_Click(object sender, EventArgs e) {
            deshacerCambios();
        }

        private void deshacerCambios() {

            if (mBiblioteca == null || mEventoActual == null)
                return;

            if (mEventoActual.IdEvento == null) {
                evEvento.Modificado = false;
                lbEventos.Items.Remove(mEventoActual);
            } else {
                mBiblioteca.RecuperarEvento(mEventoActual);
                evEvento.Evento = mEventoActual;
            }

        }

        private void GestorEventos_FormClosed(object sender, FormClosedEventArgs e) {
            deshacerCambios();
        }

        private void btnNuevo_Click(object sender, EventArgs e) {

            FrmPedirTexto frm = new FrmPedirTexto("Nuevo evento", "Dime el nombre del evento");

            if (frm.ShowDialog() != DialogResult.OK)
                return;

            
            Evento evento = new Evento() {
                Nombre = frm.Input
            };
            lbEventos.Items.Add(evento);
            lbEventos.SelectedItem = evento;
            evEvento.Modificado = true;

            
        }

        private void btnCerrar_Click(object sender, EventArgs e) {
            comprobarModificado();
            Close();
        }
    }
}

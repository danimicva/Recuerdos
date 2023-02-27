using Recuerdos.Modelo;
using Recuerdos.Utils;

namespace Recuerdos.Vista.Gestores
{
    public partial class GestorEventos : Form
    {
        private Biblioteca? _Biblioteca;

        private Evento? mEventoActual = null;

        private bool mActualizandoUi = false;

        public GestorEventos(Biblioteca? biblioteca = null) {
            InitializeComponent();

            _Biblioteca = biblioteca;
        }

        private void GestorEventos_Load(object sender, EventArgs e) {

            if (_Biblioteca == null)
                return;

            iniciarUI();

            if (_Biblioteca.Eventos.Count > 0)
                lbEventos.SelectedItem = lbEventos.Items[0];
            evEvento.Biblioteca = _Biblioteca;
        }

        private void iniciarUI() {
            if (_Biblioteca == null)
                return;

            evEvento.Evento = null;
            lbEventos.Items.Clear();

            _Biblioteca.Eventos.ForEach(e => {
                lbEventos.Items.Add(e);
            });
        }


        private void lbEventos_SelectedIndexChanged(object sender, EventArgs e) {

            if (_Biblioteca == null || mActualizandoUi)
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
                    } else {
                        _Biblioteca.RecuperarEvento(mEventoActual);
                    }
                }
            }
        }

        private void elegirEvento(Evento? e) {
            mEventoActual = e;

            evEvento.Evento = e;
        }

        private void btnBorrar_Click(object sender, EventArgs e) {

            if (mEventoActual == null || _Biblioteca == null)
                return;

            _Biblioteca.BorrarEvento(mEventoActual);

            lbEventos.Items.Remove(mEventoActual);

        }

        private void btnGuardar_Click(object sender, EventArgs e) {

            if (_Biblioteca == null || mEventoActual == null)
                return;

            _Biblioteca.GuardarEvento(mEventoActual);
            evEvento.Modificado = false;

            int indice = lbEventos.Items.IndexOf(mEventoActual);

            mActualizandoUi = true;
            lbEventos.Items.RemoveAt(indice);
            lbEventos.Items.Insert(indice, mEventoActual);
            lbEventos.SelectedItem = mEventoActual;
            mActualizandoUi = false;

        }

        private void btnDeshacer_Click(object sender, EventArgs e) {

            if (_Biblioteca == null || mEventoActual == null)
                return;

            if (mEventoActual.IdEvento == null) {
                evEvento.Modificado = false;
                lbEventos.Items.Remove(mEventoActual);
            } else {
                _Biblioteca.RecuperarEvento(mEventoActual);
                evEvento.Evento = mEventoActual;
            }
        }

        private void GestorEventos_FormClosed(object sender, FormClosedEventArgs e) {

            if (_Biblioteca == null || mEventoActual == null)
                return;

            comprobarModificado();
            
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
            
            Close();
        }
    }
}

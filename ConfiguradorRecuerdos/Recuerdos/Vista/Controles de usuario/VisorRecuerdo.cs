using Recuerdos.Modelo;

namespace Recuerdos.Vista.Controles_de_usuario
{
    public partial class VisorRecuerdo : UserControl
    {
        private Biblioteca? _Biblioteca = null;
        public Biblioteca? Biblioteca {
            set {
                _Biblioteca = value;
                iniciarUI();
            }
        }
        private Image? mImagenMostrada = null;

        private List<Recuerdo> _Recuerdos = new List<Recuerdo>();
        public List<Recuerdo> Recuerdos {
            get {
                return _Recuerdos;
            }
            set {

                comprobarGuardado();
            
                _Recuerdos.Clear();
                Modificados = false;
                if(value != null)
                    value.ForEach(r => _Recuerdos.Add(r.Clonar()));
                cargarRecuerdoUI();
            }
        }

        private bool mActualizandoUI = false;
        private bool Modificados = false;

        public VisorRecuerdo() {
            InitializeComponent();
        }

        private void comprobarGuardado() {

            if (_Biblioteca == null || !Modificados)
                return;


            if (MessageBox.Show("Hay cambios sin guardar. ¿Guardar los cambios?",
                    "Cambios sin guardar", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                btnGuardar.PerformClick();
            }
        }

        #region Funciones UI

        private void iniciarUI() {

            if (_Biblioteca == null) {
                MessageBox.Show("La biblioteca es nula.");
                return;
            }

            mActualizandoUI = true;

            _Biblioteca.Eventos.ForEach(e => {
                cbDetallesEvento.Items.Add(e);
            });


            mActualizandoUI = false;

        }

        private Evento? obtenerEventoCbEventosPorId(int? idEvento) {
            
            if (idEvento == null) return null;

            foreach(Evento e in cbDetallesEvento.Items) 
                if (e.IdEvento == idEvento)
                    return e;
            return null;
        }

        private bool eventosIguales(Evento? ev1, Evento? ev2) {
            if (ev1 == null && ev2 != null)
                return false;
            else if (ev1 != null && ev2 == null)
                return false;
            else if (ev1 == null && ev2 == null)
                return true;
            else return ev1.IdEvento == ev2.IdEvento;
        }

        private void cargarRecuerdoUI() {
            bool hayRecuerdos = _Recuerdos.Count > 0;
            mActualizandoUI = true;

            tbDetallesLugar.Enabled = cbDetallesEvento.Enabled =
                tbDetallesFuente.Enabled = tbDetallesDescripcion.Enabled =
                btnDetallesQuitarEvento.Enabled = btnDetallesNuevoEvento.Enabled = hayRecuerdos;

            if (hayRecuerdos) {

                // Ponemos el evento
                tbDetallesLugar.Text = _Recuerdos.Any(r => r.Lugar != _Recuerdos[0].Lugar) ? "(varios)" : _Recuerdos[0].Lugar;

                // Si son diferentes los eventos de los recuerdos seleccionados
                if (_Recuerdos.Any(r => !eventosIguales(r.Evento, _Recuerdos[0].Evento))) { 
                    cbDetallesEvento.SelectedItem = null;
                    cbDetallesEvento.Text = "(varios)";

                // Si son iguales, pero nulos
                } else if (_Recuerdos[0].Evento == null){
                    cbDetallesEvento.SelectedItem = null;
                    cbDetallesEvento.Text = "";
                } else {
                    Evento? ev = obtenerEventoCbEventosPorId(_Recuerdos[0].IdEvento);

                    if (ev != null)
                        cbDetallesEvento.SelectedItem = ev;
                    else
                        cbDetallesEvento.Text = "(No se encontró el evento " + _Recuerdos[0].IdEvento;
                }

                // Ponemos la fecha

                if(MiFecha.FechasIguales(_Recuerdos.Select(r => r.Fecha))) {

                }


            } else {
                tbDetallesLugar.Text = "";
                cbDetallesEvento.Text = "";
                cbDetallesEvento.SelectedItem = null;
                selectorFecha.Fecha = null;
            }

            if (mImagenMostrada != null) {
                mImagenMostrada.Dispose();
                pbFotoElegida.Image = null;
            }

            if (_Recuerdos.Count == 1 && _Recuerdos[0].Tipo ==Recuerdo.TipoRecuerdo.Foto) {
                mImagenMostrada = Image.FromFile(_Recuerdos[0].Ruta);
                pbFotoElegida.Image = mImagenMostrada;
            }

            actualizarBotonesUI();

            mActualizandoUI = false;
        }

        private void actualizarBotonesUI() {
            btnGuardar.Enabled = Modificados;
            btnDeshacer.Enabled = Modificados;
        }

        #endregion

        #region Eventos de controles
        private void btnDetallesNuevoEvento_Click(object sender, EventArgs e) {
            EventoForm form = new(_Biblioteca);
            if (form.ShowDialog() == DialogResult.OK) {
                Evento? nuevo = form.Evento;

                if (nuevo == null)
                    return;

                if(_Biblioteca == null) {
                    MessageBox.Show("La biblioteca es nula.");
                    return;
                }

                _Biblioteca.GuardarEvento(nuevo);

                mActualizandoUI = true;
                cbDetallesEvento.Items.Add(nuevo);
                cbDetallesEvento.SelectedItem = null;
                mActualizandoUI = false;

                cbDetallesEvento.SelectedItem = nuevo;
            }
        }

        private void cbDetallesEvento_SelectedIndexChanged(object sender, EventArgs e) {

            if (mActualizandoUI)
                return;

            Evento? evento = cbDetallesEvento.SelectedItem as Evento;
            Modificados = true;

            _Recuerdos.ForEach(r =>     
                r.Evento = evento
            );

            actualizarBotonesUI();
        }

        private void btnGuardar_Click(object sender, EventArgs e) {

            if (_Biblioteca == null) {
                MessageBox.Show("La biblioteca es nula.");
                return;
            }

            _Recuerdos.ForEach(r => {
                _Biblioteca.GuardarRecuerdo(r);
            });

            Modificados = false;

            cargarRecuerdoUI();
            actualizarBotonesUI();
        }

        private void btnDeshacer_Click(object sender, EventArgs e) {
            if (_Biblioteca == null) {
                MessageBox.Show("La biblioteca es nula.");
                return;
            }

            _Recuerdos.ForEach(r => {
                _Biblioteca.RecuperarRecuerdo(r);
            });

            Modificados = false;

            actualizarBotonesUI();
        }

        private void btnQuitarEvento_Click(object sender, EventArgs e) {
            cbDetallesEvento.SelectedItem = null;
        }

        private void tbCualquiera_TextChanged(object sender, EventArgs e) {


            if (mActualizandoUI)
                return;

            Modificados = true;

            _Recuerdos.ForEach(r => {

                if (sender == tbDetallesLugar)
                    r.Lugar = tbDetallesLugar.Text;
                else if (sender == tbDetallesFuente)
                    r.Fuente = tbDetallesFuente.Text;
                else if (sender == tbDetallesDescripcion)
                    r.Descripcion = tbDetallesDescripcion.Text;
            });

            actualizarBotonesUI();

        }


        #endregion

    }
}

using Recuerdos.Modelo;
using Recuerdos.Vista.Gestores;


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
                if (value != null)
                    _Recuerdos = value;
                    //value.ForEach(r => _Recuerdos.Add(r.Clonar()));
                cargarRecuerdoUI();
            }
        }

        private bool _ActualizandoUI = false;
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
            } else {
                _Biblioteca.RecuperarRecuerdos(_Recuerdos);
            }
        }

        private bool todosTienenMismasPersonas() {
            if (_Recuerdos == null || _Recuerdos.Count == 0)
                return false;
            List<RecuerdoPersona> rps = _Recuerdos[0].Personas;

            for (int i = 1; i < _Recuerdos.Count; i++) {
                if (rps.Count != _Recuerdos[i].Personas.Count)
                    return false;

                foreach (RecuerdoPersona rp in rps)
                    if (!_Recuerdos[i].Personas.Any(ep2 => ep2.IdPersona == rp.IdPersona))
                        return false;
            }

            return true;
        }

        #region Funciones UI

        private void iniciarUI() {

            if (_Biblioteca == null) {
                MessageBox.Show("La biblioteca es nula.");
                return;
            }
            pnlVideo.Visible = false;

            _ActualizandoUI = true;

            _Biblioteca.Eventos.ForEach(e => {
                cbDetallesEvento.Items.Add(e);
            });


            _ActualizandoUI = false;

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

        public void liberarVisor() {
            vlcVideo.Stop();
        }

        private void cargarRecuerdoUI() {
            bool hayRecuerdos = _Recuerdos.Count > 0;
            _ActualizandoUI = true;

            vlcVideo.Stop();
            btnVideoPlayPausa.Text = "Play";

            tbDetallesLugar.Enabled = cbDetallesEvento.Enabled =
                tbDetallesFuente.Enabled = tbDetallesDescripcion.Enabled =
                btnDetallesQuitarEvento.Enabled = btnDetallesNuevoEvento.Enabled = 
                gbDetalles.Enabled = selectorFecha.Enabled = hayRecuerdos;

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
                selectorFecha.Fechas = _Recuerdos.Select(r => r.Fecha).ToList();
                
                // Cargamos las personas
                if (todosTienenMismasPersonas()) {
                    lblPersonas.Text = _Recuerdos[0].GetPersonasString();
                }else
                    lblPersonas.Text = "(Varios)"; //TODO ESTO NO FUNCIONA CUANDO SE AÑADE UNA PERSONA A VARIOS RECUERDOS. rEVISAR TAMBIÉN EN EVENTOS.


            } else {
                tbDetallesLugar.Text = "";
                cbDetallesEvento.Text = "";
                cbDetallesEvento.SelectedItem = null;
                selectorFecha.Fechas = null;
            }

            if (mImagenMostrada != null) {
                mImagenMostrada.Dispose();
                pbFotoElegida.Image = null;
            }

            if (_Recuerdos.Count == 0 || _Recuerdos.Count > 1) {
                pbFotoElegida.Visible = false;
                pnlVideo.Visible = false;
            } else {
                pbFotoElegida.Visible = _Recuerdos[0].Tipo == Recuerdo.TipoRecuerdo.Foto;
                pnlVideo.Visible = _Recuerdos[0].Tipo == Recuerdo.TipoRecuerdo.Video;
                
                if (_Recuerdos[0].Tipo == Recuerdo.TipoRecuerdo.Foto) {
                    mImagenMostrada = Image.FromFile(_Recuerdos[0].Ruta);
                    pbFotoElegida.Image = mImagenMostrada;
                }else if(_Recuerdos[0].Tipo == Recuerdo.TipoRecuerdo.Video) {
                    vlcVideo.Play(new FileInfo(_Recuerdos[0].Ruta));
                    btnVideoPlayPausa.Text = "Pause";
                }
            }

            actualizarBotonesUI();

            _ActualizandoUI = false;
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

                _ActualizandoUI = true;
                cbDetallesEvento.Items.Add(nuevo);
                cbDetallesEvento.SelectedItem = null;
                _ActualizandoUI = false;

                cbDetallesEvento.SelectedItem = nuevo;

                Modificados = true;
                actualizarBotonesUI();
            }
        }

        private void cbDetallesEvento_SelectedIndexChanged(object sender, EventArgs e) {

            if (_ActualizandoUI)
                return;

            Evento? evento = cbDetallesEvento.SelectedItem as Evento;

            _Recuerdos.ForEach(r =>     
                r.Evento = evento
            );

            Modificados = true;
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

            
            _Biblioteca.RecuperarRecuerdos(_Recuerdos);
            

            Modificados = false;
            actualizarBotonesUI();
        }

        private void btnQuitarEvento_Click(object sender, EventArgs e) {
            cbDetallesEvento.SelectedItem = null;

            Modificados = true;
            actualizarBotonesUI();
        }

        private void tbCualquiera_TextChanged(object sender, EventArgs e) {


            if (_ActualizandoUI)
                return;

            _Recuerdos.ForEach(r => {

                if (sender == tbDetallesLugar)
                    r.Lugar = tbDetallesLugar.Text;
                else if (sender == tbDetallesFuente)
                    r.Fuente = tbDetallesFuente.Text;
                else if (sender == tbDetallesDescripcion)
                    r.Descripcion = tbDetallesDescripcion.Text;
            });

            Modificados = true;
            actualizarBotonesUI();
        }

        private void btnEditarPersonas_Click(object sender, EventArgs e) {
            if (_Biblioteca == null || _Recuerdos == null || _Recuerdos.Count == 0)
                return;

            List<Persona> elegidas = todosTienenMismasPersonas() ? _Recuerdos[0].GetListaPersonas() : new List<Persona>();

            AñadidorPersonas gestor = new (_Biblioteca.Personas, elegidas);

            if (gestor.ShowDialog() == DialogResult.OK) {
                _Recuerdos.ForEach(r => r.RevisarPersonas(gestor.Elegidas));

                cargarRecuerdoUI();
                Modificados = true;
                actualizarBotonesUI();
            }
        }

        #endregion

        private void selectorFecha_FechaModificada(object sender, EventArgs e) {
            if (_ActualizandoUI)
                return;
            
            Modificados = true;
            actualizarBotonesUI();
            
        }

        private void btnVideoPlayPausa_Click(object sender, EventArgs e) {

            if (vlcVideo.IsPlaying) {
                vlcVideo.Pause();
                btnVideoPlayPausa.Text = "Play";
            } else {
                vlcVideo.Play();
                btnVideoPlayPausa.Text = "Pause";
            }

        }

        private void btnVideoStop_Click(object sender, EventArgs e) {
            vlcVideo.Stop();
            btnVideoPlayPausa.Text = "Play";
        }

        private void vlcVideo_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e) {
            e.VlcLibDirectory = Directory.CreateDirectory("C:\\Program Files\\VideoLAN\\VLC\\");
        }
    }
}

using Recuerdos.Modelo;
using Recuerdos.Vista.Gestores;

namespace Recuerdos.Vista.Controles_de_usuario
{
    public partial class EditorEvento : UserControl
    {
        private bool _ModificadoInterno = false;
        public bool Modificado { 
            get {
                return _ModificadoInterno || selectorFecha1.Modificado;
            } 
            set {
                _ModificadoInterno = value;
                selectorFecha1.Modificado = value;
            }
        }

        private Evento? _Evento = null;
        public Evento? Evento {
            get {
                return _Evento;
            }
            set {
                _Evento = value;
                actualizarUI();
                _ModificadoInterno = false;
            }
        }

        public Biblioteca? Biblioteca = null;

        public EditorEvento() {
            InitializeComponent();
        }

        private void actualizarUI() {

            if (_Evento == null) {
                Enabled = false;
                tbNombre.Text = tbLugar.Text = tbDescripcion.Text = lblPersonas.Text = "";
                selectorFecha1.Fechas = null;
                return;
            }

            Enabled = true;
            tbNombre.Text = _Evento.Nombre;
            tbLugar.Text = _Evento.Lugar;
            tbDescripcion.Text = _Evento.Descripcion;
            selectorFecha1.Fechas = new List<MiFecha>() { _Evento.Fecha };
            lblPersonas.Text = _Evento.GetPersonasString();
        }

        private void tbTodos_TextChanged(object sender, EventArgs e) {

            if (_Evento == null)
                return;

            _ModificadoInterno = true;

            if(sender == tbNombre)
                _Evento.Nombre = tbNombre.Text;
            else if(sender == tbLugar)
                _Evento.Lugar = tbLugar.Text;
            else if(sender == tbDescripcion)
                _Evento.Descripcion = tbDescripcion.Text;

        }

        private void selectorFecha1_FechaModificada(object sender, EventArgs e) {
            if (_Evento == null)
                return;

            _ModificadoInterno = true;
            // Es la propia fecha la que está referenciada
            //_Evento.Fecha = selectorFecha1.Fecha;
        }

        private void btnEditar_Click(object sender, EventArgs e) {

            if (Biblioteca == null || Evento == null || Evento.Personas == null)
                return;

            AñadidorPersonas gestor = new (Biblioteca.Personas, 
                Evento.GetListaPersonas());

            if(gestor.ShowDialog() == DialogResult.OK) 
                Evento.RevisarPersonas(gestor.Elegidas);

            actualizarUI();
        }
    }
}

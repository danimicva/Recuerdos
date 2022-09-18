using Recuerdos.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recuerdos.Vista.Controles_de_usuario
{
    public partial class EditorPersona: UserControl
    {
        private bool _ModificadoInterno = false;
        public bool Modificado { 
            get {
                return _ModificadoInterno;
            } 
            set {
                _ModificadoInterno = value;
            }
        }

        private Persona? _Persona = null;
        public Persona? Persona{
            get {
                return _Persona;
            }
            set {
                _Persona = value;
                actualizarUI();
                _ModificadoInterno = false;
            }
         }

        public EditorPersona() {
            InitializeComponent();
        }

        private void actualizarUI() {

            if (_Persona == null) {
                Enabled = false;
                tbNombre.Text = tbDescripcion.Text = "";
                return;
            }

            Enabled = true;
            tbNombre.Text = _Persona.Nombre;
            tbDescripcion.Text = _Persona.Descripcion;

        }

        private void tbTodos_TextChanged(object sender, EventArgs e) {

            if (_Persona == null)
                return;

            _ModificadoInterno = true;

            if (sender == tbNombre)
                _Persona.Nombre = tbNombre.Text;
            else if (sender == tbDescripcion)
                _Persona.Descripcion = tbDescripcion.Text;
        }
    }
}

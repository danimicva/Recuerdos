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

namespace Recuerdos.Vista
{
    public partial class EventoForm : Form
    {
        public Evento? Evento { 
            get {
                return evEvento.Evento;
            } set {
                evEvento.Evento = value;
            }
        }

        private Biblioteca? mBiblioteca = null;

        public EventoForm() {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }

        public EventoForm(Biblioteca? biblioteca) : this() {
            mBiblioteca = biblioteca;
        }

        private void EventoForm_Load(object sender, EventArgs e) {
            evEvento.Biblioteca = mBiblioteca;
        }

        private void btnGuardar_Click(object sender, EventArgs e) {
            
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            Close();
        }
    }
}

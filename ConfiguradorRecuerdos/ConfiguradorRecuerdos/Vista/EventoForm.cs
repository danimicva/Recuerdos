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
        private Biblioteca mBiblioteca;
        public Evento Evento = null;
        public EventoForm(Biblioteca biblioteca, Evento evento = null) {
            InitializeComponent();

            mBiblioteca = biblioteca;
            Evento = evento == null ? new Evento() : evento;

            DialogResult = DialogResult.Cancel;
        }

        private void Evento_Load(object sender, EventArgs e) {
            actualizarUI();
        }

        private void actualizarUI() {
            tbNombre.Text = Evento.Nombre;
            tbLugar.Text = Evento.Lugar;
            tbDescripcion.Text = Evento.Descripcion;
            lblFechaCreacion.Text = "Fecha de creación: " + Evento.FechaCreacion.ToLongDateString();
        }

        private void btnGuardar_Click(object sender, EventArgs e) {

            if (!recogerInformacion())
                return;

            
            mBiblioteca.GuardarEvento(Evento);
            
            DialogResult = DialogResult.OK;
            Close();
        }

        private bool recogerInformacion() {

            if (string.IsNullOrEmpty(tbNombre.Text)) {
                MessageBox.Show("El nombre no puede estar vacío.");
                return false;
            }

            Evento.Nombre = tbNombre.Text;
            Evento.Lugar = tbLugar.Text;
            Evento.Descripcion = tbDescripcion.Text;

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            Close();
        }
    }
}

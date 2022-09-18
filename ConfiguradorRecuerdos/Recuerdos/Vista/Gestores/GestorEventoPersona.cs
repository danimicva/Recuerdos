using Recuerdos.Modelo;
using Recuerdos.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recuerdos.Vista.Gestores
{
    public partial class GestorEventoPersona : Form
    {
        private readonly List<Persona> mPersonasTotales = new();
        public List<Persona> Elegidas = new();

        public GestorEventoPersona() {
            InitializeComponent();
        }

        public GestorEventoPersona(List<Persona> totales, List<Persona> elegidas) : this() {
            mPersonasTotales = totales;
            elegidas.ForEach(e => Elegidas.Add(e));
            DialogResult = DialogResult.Cancel;
        }

        private void GestorEventoPersona_Load(object sender, EventArgs e) {
            cargarPersonas();

        }

        private void cargarPersonas() {
            lbIncluidos.Items.Clear();
            lbTodos.Items.Clear();

            Elegidas.ForEach(e => {
                if (e != null)
                    lbIncluidos.Items.Add(e);
            });

            mPersonasTotales.ForEach(e => {
                if (!Elegidas.Any(p => p.IdPersona == e.IdPersona))
                    lbTodos.Items.Add(e);
            });

            actualizarUI();
        }

        private void lbTodos_SelectedValueChanged(object sender, EventArgs e) {
            actualizarUI();
        }

        private void actualizarUI() {
            btnAnadir.Enabled = lbTodos.SelectedItems.Count > 0;
            btnQuitar.Enabled = lbIncluidos.SelectedItems.Count > 0;
        }

        private void btnAnadir_Click(object sender, EventArgs e) {
            foreach(Persona p in lbTodos.SelectedItems.OfType<Persona>()) {
                Elegidas.Add(p);
            };

            cargarPersonas();
        }

        private void btnQuitar_Click(object sender, EventArgs e) {
            foreach (Persona p in lbIncluidos.SelectedItems.OfType<Persona>()) {
                Elegidas.Remove(p);
            };

            cargarPersonas();
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e) {
            FrmPedirTexto frm = new("Nombre", "Dime el nombre de la persona.");

            if (frm.ShowDialog() == DialogResult.Cancel)
                return;


            Persona p = new() {
                Nombre = frm.Input
            };

            Elegidas.Add(p);
            lbIncluidos.Items.Add(p);

            //cargarPersonas();
        }
    }
}

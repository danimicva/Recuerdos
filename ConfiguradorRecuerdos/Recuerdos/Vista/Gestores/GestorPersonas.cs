using Recuerdos.Modelo;
using Recuerdos.Utils;

namespace Recuerdos.Vista.Gestores
{
    public partial class GestorPersonas: Form
    {
        private Biblioteca? mBiblioteca;

        private Persona? mPersonaActual = null;
        private int mUsos = 0;

        private bool mActualizandoUI = false;

        public GestorPersonas(Biblioteca? biblioteca = null) {
            InitializeComponent();

            mBiblioteca = biblioteca;
        }

        private void GestorEventos_Load(object sender, EventArgs e) {

            if (mBiblioteca == null)
                return;

            iniciarUI();

            if (mBiblioteca.Personas.Count > 0)
                lbPersonas.SelectedItem = lbPersonas.Items[0];

        }

        private void iniciarUI() {
            if (mBiblioteca == null)
                return;

            editorPersona.Persona = null;
            lbPersonas.Items.Clear();

            mBiblioteca.Personas.ForEach(p => {
                lbPersonas.Items.Add(p);
            });
        }

        private void lbPersonas_SelectedIndexChanged(object sender, EventArgs e) {
            
            if (mBiblioteca == null || mActualizandoUI) 
                return;

            Persona? p = lbPersonas.SelectedItem as Persona;

            comprobarModificaciones();

            mActualizandoUI = true;
            lbPersonas.SelectedItem = p;
            mActualizandoUI = false;

            elegirPersona(p);
        }

        private void comprobarModificaciones() {
            if (mPersonaActual != null && editorPersona.Modificado) {
                if (MessageBox.Show("La persona " + mPersonaActual.Nombre + " se ha modificado. ¿Guardar los cambios?",
                        "Persona modificada", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    btnGuardar.PerformClick();

                } else { // Deshacemos
                    if (mPersonaActual.IdElemento == null) {
                        lbPersonas.Items.Remove(mPersonaActual);
                    }
                }
            }
        }

        private void elegirPersona(Persona? p) {

            mPersonaActual = p;
            editorPersona.Persona = p?.Clonar();

            if (mBiblioteca != null) 
                mUsos = p == null ? -1 : mBiblioteca.ObtenerUsosPersona(p);

            lblUsos.Text = mUsos == -1 ? "" : ("Usos: " + mUsos);

        }

        private void btnBorrar_Click(object sender, EventArgs e) {

            if (mPersonaActual == null || mBiblioteca == null) {
                MessageBox.Show("Persona actual o biblioteca a null.");
                return;
            }

            if (MessageBox.Show("¿Seguro que quieres borrar esta persona? Está asignada a " + mUsos + " eventos. Se borrará de todos.",
                "Borrar persona", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            mBiblioteca.BorrarPersona(mPersonaActual);
            editorPersona.Modificado = false;

            lbPersonas.Items.Remove(mPersonaActual);
            
        }

        private void btnGuardar_Click(object sender, EventArgs e) {

            // Recogemos el evento actualizado
            Persona? aGuardar = editorPersona.Persona;

            if (mBiblioteca == null || aGuardar == null || mPersonaActual == null)
                return;
           

            mBiblioteca.GuardarPersona(aGuardar);
            editorPersona.Modificado = false;

            int indice = lbPersonas.Items.IndexOf(mPersonaActual);


            mActualizandoUI = true;
            lbPersonas.Items.RemoveAt(indice);
            lbPersonas.Items.Insert(indice, aGuardar);
            lbPersonas.SelectedItem = aGuardar;
            elegirPersona(aGuardar);
            mActualizandoUI = false;


        }

        private void btnDeshacer_Click(object sender, EventArgs e) {
            deshacerCambios();
        }

        private void deshacerCambios() {
            
            if (mBiblioteca == null || mPersonaActual == null)
                return;

            if (mPersonaActual.IdPersona == null) {
                editorPersona.Modificado = false;
                lbPersonas.Items.Remove(mPersonaActual);
            } else {
                mBiblioteca.RecuperarPersona(mPersonaActual);
                editorPersona.Persona = mPersonaActual;
            }
            
        }

        private void GestorPersonas_FormClosed(object sender, FormClosedEventArgs e) {
            deshacerCambios();
        }

        private void btnNuevo_Click(object sender, EventArgs e) {

            comprobarModificaciones();

            FrmPedirTexto frm = new FrmPedirTexto("Nombre", "Dime el nombre de la persona.");

            if (frm.ShowDialog() == DialogResult.Cancel)
                return;


            Persona p = new() {
                Nombre = frm.Input
            };

            lbPersonas.Items.Add(p);
            lbPersonas.SelectedItem = p;
            editorPersona.Modificado = true;

            
        }

        private void btnCerrar_Click(object sender, EventArgs e) {
            comprobarModificaciones();
            Close();
        }
    }
}

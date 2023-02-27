using Recuerdos.Modelo;
using System.ComponentModel;

namespace Recuerdos.Vista.Controles_de_usuario
{
    public partial class SelectorFecha : UserControl
    {

        [Browsable(true)]
        [Category("Action")]
        [Description("Invocado cuando el usuario cambia la fecha")]
        public event EventHandler? FechaModificada;

        public bool Modificado = false;

        public bool Varias = false;

        private List<MiFecha>? _Fechas = null;
        public List<MiFecha>? Fechas { 
            get {
                return _Fechas;
            }
            set {
                _Fechas = value;
                pintarFecha();

                Modificado = false;
            }
        }

        public SelectorFecha() {
            InitializeComponent();
        }

        private void pintarFecha() {

            rbVacia.Enabled = rbExacta.Enabled = rbAproximada.Enabled = 
                rbRango.Enabled = Fechas != null;

            if (Fechas == null) {
                tbDia1.Text = tbDia2.Text = tbMes1.Text = tbMes2.Text = tbAno1.Text = tbAno2.Text = "";
                rbVacia.Checked = rbAproximada.Checked = rbExacta.Checked = rbRango.Checked = false;
                lblVarios.Visible = false;
                Enabled = false;
                return;
            }else if (MiFecha.FechasIguales(Fechas)) {
                lblVarios.Visible = false;
                Enabled = true;
                rbVacia.Checked = Fechas[0].Tipo == MiFecha.TipoFecha.Vacia;
                rbAproximada.Checked = Fechas[0].Tipo == MiFecha.TipoFecha.Aproximada;
                rbExacta.Checked = Fechas[0].Tipo == MiFecha.TipoFecha.Exacta;
                rbRango.Checked = Fechas[0].Tipo == MiFecha.TipoFecha.Rango;
                tbDia1.Text = Fechas[0].Dia.HasValue ? Fechas[0].Dia.Value + "" : "";
                tbMes1.Text = Fechas[0].Mes.HasValue ? Fechas[0].Mes.Value + "" : "";
                tbAno1.Text = Fechas[0].Año.HasValue ? Fechas[0].Año.Value + "" : "";
                tbDia2.Text = Fechas[0].Dia2.HasValue ? Fechas[0].Dia2.Value + "" : "";
                tbMes2.Text = Fechas[0].Mes2.HasValue ? Fechas[0].Mes2.Value + "" : "";
                tbAno2.Text = Fechas[0].Año2.HasValue ? Fechas[0].Año2.Value + "" : "";
            } else { // Varias
                tbDia1.Text = tbDia2.Text = tbMes1.Text = tbMes2.Text = tbAno1.Text = tbAno2.Text = "";
                rbVacia.Checked = rbAproximada.Checked = rbExacta.Checked = rbRango.Checked = false;
                lblVarios.Visible = true;
                Enabled = true;
            }

            actualizaUI();


        }

        private void rbExacta_CheckedChanged(object sender, EventArgs e) {
            
            if (_Fechas == null)
                return;

            Modificado = true;
            Varias = false;

            _Fechas.ForEach(f => f.Tipo = rbVacia.Checked ? MiFecha.TipoFecha.Vacia :
                           rbExacta.Checked ? MiFecha.TipoFecha.Exacta :
                           rbAproximada.Checked ? MiFecha.TipoFecha.Aproximada :
                           MiFecha.TipoFecha.Rango);

            actualizaUI();

            if (rbVacia.Checked)
                _Fechas.ForEach(f => f.Dia = f.Mes = f.Año = f.Dia2 = f.Mes2 = f.Año2 = null);
            else if(!rbRango.Checked)
                _Fechas.ForEach(f => f.Dia2 = f.Mes2 = f.Año2 = null);
            else {
                _Fechas.ForEach(f => f.Dia2 = f.Dia);
                _Fechas.ForEach(f => f.Mes2 = f.Mes);
                _Fechas.ForEach(f => f.Año2 = f.Año);
            }

            lblVarios.Visible = Varias = false;

            pintarFecha();

            FechaModificada?.Invoke(this, e);
        }

        private void actualizaUI() {
            tbDia1.Enabled = tbMes1.Enabled = tbAno1.Enabled =
                tbDia1.Visible = tbMes1.Visible = tbAno1.Visible =
                label1.Visible = label2.Visible = label3.Visible =
                label4.Visible = label5.Visible = !rbVacia.Checked;

            tbDia2.Enabled = tbMes2.Enabled = tbAno2.Enabled =
                tbDia2.Visible = tbMes2.Visible = tbAno2.Visible =
                label3.Visible = label4.Visible = label5.Visible = rbRango.Checked;
        }

        private void tbTodos_TextChanged(object sender, EventArgs e) {

            if (Fechas == null || Fechas.Count == 0)
                return;

            Modificado = true;

            if (sender == tbDia1) {
                Fechas.ForEach(f => f.Dia = string.IsNullOrEmpty(tbDia1.Text) ? null : int.Parse(tbDia1.Text));
            }else if(sender == tbMes1) {
                Fechas.ForEach(f => f.Mes = string.IsNullOrEmpty(tbMes1.Text) ? null : int.Parse(tbMes1.Text));
            }else if(sender == tbAno1) {
                Fechas.ForEach(f => f.Año = string.IsNullOrEmpty(tbAno1.Text) ? null : int.Parse(tbAno1.Text));
            }else if(sender == tbDia2) {
                Fechas.ForEach(f => f.Dia2 = string.IsNullOrEmpty(tbDia2.Text) ? null : int.Parse(tbDia2.Text));
            }else if(sender == tbMes2) {
                Fechas.ForEach(f => f.Mes2 = string.IsNullOrEmpty(tbMes2.Text) ? null : int.Parse(tbMes2.Text));
            }else if(sender == tbAno2) {
                Fechas.ForEach(f => f.Año2 = string.IsNullOrEmpty(tbAno2.Text) ? null : int.Parse(tbAno2.Text));
            }

            lblVarios.Visible = Varias = false;

            FechaModificada?.Invoke(this, e);
        }
    }
}

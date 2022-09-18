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

        private MiFecha? _Fecha = null;
        public MiFecha? Fecha { 
            get {
                return _Fecha;
            }
            set {
                _Fecha = value;
                pintarFecha();

                Modificado = false;
            }
        }

        public SelectorFecha() {
            InitializeComponent();
        }

         

        
        private void pintarFecha() {

            if(_Fecha == null) {
                tbDia1.Text = tbDia2.Text = tbMes1.Text = tbMes2.Text = tbAno1.Text = tbAno2.Text = "";
                rbVacia.Checked = rbAproximada.Checked = rbExacta.Checked = rbRango.Checked = false;
                lblVarios.Visible = false;
                Enabled = false;
                return;
            }else if (Varias) {
                tbDia1.Text = tbDia2.Text = tbMes1.Text = tbMes2.Text = tbAno1.Text = tbAno2.Text = "";
                rbVacia.Checked = rbAproximada.Checked = rbExacta.Checked = rbRango.Checked = false;
                lblVarios.Visible = true;
                Enabled = true;
                return;
            }

            lblVarios.Visible = false;
            Enabled = true;
            rbVacia.Checked = _Fecha.Tipo == MiFecha.TipoFecha.Vacia;
            rbAproximada.Checked = _Fecha.Tipo == MiFecha.TipoFecha.Aproximada;
            rbExacta.Checked = _Fecha.Tipo == MiFecha.TipoFecha.Exacta;
            rbRango.Checked = _Fecha.Tipo == MiFecha.TipoFecha.Rango;

            rellenarCampos();
        }

        private void rbExacta_CheckedChanged(object sender, EventArgs e) {
            
            if (_Fecha == null)
                return;

            Modificado = true;

            _Fecha.Tipo = rbVacia.Checked ? MiFecha.TipoFecha.Vacia :
                           rbExacta.Checked ? MiFecha.TipoFecha.Exacta :
                           rbAproximada.Checked ? MiFecha.TipoFecha.Aproximada :
                           MiFecha.TipoFecha.Rango;

            tbDia1.Enabled = tbMes1.Enabled = tbAno1.Enabled =
                tbDia2.Enabled = tbMes2.Enabled = tbAno2.Enabled = !rbVacia.Checked;

            tbDia2.Enabled = tbMes2.Enabled = tbAno2.Enabled = rbRango.Checked;

            if (rbVacia.Checked)
                _Fecha.Dia = _Fecha.Mes = _Fecha.Año = _Fecha.Dia2 = _Fecha.Mes2 = _Fecha.Año2 = null;
            else if(!rbRango.Checked)
                _Fecha.Dia2 = _Fecha.Mes2 = _Fecha.Año2 = null;
            else {
                _Fecha.Dia2 = _Fecha.Dia;
                _Fecha.Mes2 = _Fecha.Mes;
                _Fecha.Año2 = _Fecha.Año;
            }

            lblVarios.Visible = Varias = false;

            rellenarCampos();

            FechaModificada?.Invoke(this, e);
        }

        private void rellenarCampos() {
            
            if (_Fecha == null)
                return;

            tbDia1.Text = _Fecha.Dia.HasValue ? _Fecha.Dia.Value + "" : "";
            tbMes1.Text = _Fecha.Mes.HasValue ? _Fecha.Mes.Value + "" : "";
            tbAno1.Text = _Fecha.Año.HasValue ? _Fecha.Año.Value + "" : "";


            tbDia2.Text = _Fecha.Dia2.HasValue ? _Fecha.Dia2.Value + "" : "";
            tbMes2.Text = _Fecha.Mes2.HasValue ? _Fecha.Mes2.Value + "" : "";
            tbAno2.Text = _Fecha.Año2.HasValue ? _Fecha.Año2.Value + "" : "";
        }

        private void tbTodos_TextChanged(object sender, EventArgs e) {

            if (_Fecha == null)
                return;

            Modificado = true;

            if (sender == tbDia1) {
                _Fecha.Dia = string.IsNullOrEmpty(tbDia1.Text) ? null : int.Parse(tbDia1.Text);
            }else if(sender == tbMes1) {
                _Fecha.Mes = string.IsNullOrEmpty(tbMes1.Text) ? null : int.Parse(tbMes1.Text);
            }else if(sender == tbAno1) {
                _Fecha.Año = string.IsNullOrEmpty(tbAno1.Text) ? null : int.Parse(tbAno1.Text);
            }else if(sender == tbDia2) {
                _Fecha.Dia2 = string.IsNullOrEmpty(tbDia2.Text) ? null : int.Parse(tbDia2.Text);
            }else if(sender == tbMes2) {
                _Fecha.Mes2 = string.IsNullOrEmpty(tbMes2.Text) ? null : int.Parse(tbMes2.Text);
            }else if(sender == tbAno2) {
                _Fecha.Año2 = string.IsNullOrEmpty(tbAno2.Text) ? null : int.Parse(tbAno2.Text);
            }

            lblVarios.Visible = Varias = false;

            FechaModificada?.Invoke(this, e);
        }
    }
}

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
    public partial class SelectorFecha : UserControl
    {
        private MiFecha _Fecha;
        public MiFecha Fecha { 
            get {
                leerFechaUI();
                return _Fecha;
            }
            set {
                _Fecha = value;
                pintarFecha();
            }
        }

        private void leerFechaUI() {

            _Fecha.Dia = string.IsNullOrEmpty(tbDia1.Text) ? null : int.Parse(tbDia1.Text);

            _Fecha.Tipo = rbExacta.Checked ? MiFecha.TipoFecha.Exacta : rbAproximada.Checked ? MiFecha.TipoFecha.Aproximada : MiFecha.TipoFecha.Aproximada;
        }
        
        private void pintarFecha() {
            if(_Fecha == null) {
                tbDia1.Text = tbDia2.Text = tbMes1.Text = tbMes2.Text = tbAno1.Text = tbAno2.Text = "";
                rbAproximada.Checked = rbExacta.Checked = rbRango.Checked = false;
                Enabled = false;
                return;
            }

            Enabled = true;
            rbAproximada.Checked = _Fecha.Tipo == MiFecha.TipoFecha.Aproximada;
            rbExacta.Checked = _Fecha.Tipo == MiFecha.TipoFecha.Exacta;
            rbRango.Checked = _Fecha.Tipo == MiFecha.TipoFecha.Rango;

            tbDia1.Text = _Fecha.Dia.HasValue ? _Fecha.Dia.Value + "" : "";
            tbMes1.Text = _Fecha.Mes.HasValue ? _Fecha.Mes.Value + "" : "";
            tbAno1.Text = _Fecha.Año.HasValue ? _Fecha.Año.Value + "" : "";

            tbDia2.Enabled = tbMes2.Enabled = tbAno2.Enabled = rbRango.Checked;

            tbDia2.Text = _Fecha.Dia2.HasValue ? _Fecha.Dia2.Value + "" : "";
            tbMes2.Text = _Fecha.Mes2.HasValue ? _Fecha.Mes2.Value + "" : "";
            tbAno2.Text = _Fecha.Año2.HasValue ? _Fecha.Año2.Value + "" : "";

        }

        private void rbExacta_CheckedChanged(object sender, EventArgs e) {

            tbDia2.Enabled = tbMes2.Enabled = tbAno2.Enabled = rbRango.Checked;

            tbDia2.Text = rbRango.Checked ? tbDia1.Text : "";
            tbMes2.Text = rbRango.Checked ? tbMes1.Text : "";
            tbAno2.Text = rbRango.Checked ? tbAno1.Text : "";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Recuerdos.Modelo
{
    class zz_Recuerdo
    {
        private string _Ruta;
        public string Ruta {
            get {
                return _Ruta;
            } 
            
            private set {
                if(_Ruta != value) {
                    _Ruta = value;
                    mModificado = true;
                }
            }
        }

        private string _Nombre;
        public string Nombre { 
            get {
                return _Nombre;
            }
            set {
                if (_Nombre != value) {
                    _Nombre = value;
                    mModificado = true;
                }
            } 
        }

        private int? _Dia;
        public int? Dia {
            get {
                return _Dia;
            }
            set {
                if (_Dia != value) {
                    _Dia = value;
                    mModificado = true;
                }
            }
        }

        private int? _Mes;
        public int? Mes {
            get {
                return _Mes;
            }
            set {
                if (_Mes != value) {
                    _Mes = value;
                    mModificado = true;
                }
            }
        }

        private int? _Año;
        public int? Año {
            get {
                return _Año;
            }
            set {
                if (_Año != value) {
                    _Año = value;
                    mModificado = true;
                }
            }
        }

        private string _Lugar;
        public string Lugar {
            get {
                return _Lugar;
            }
            set {
                if (_Lugar != value) {
                    _Lugar = value;
                    mModificado = true;
                }
            }
        }

        public byte[] MD5Fichero { get; private set; }

        protected bool mModificado { get; set; } = false;

        public static zz_Recuerdo cargarArchivo(string ruta)
        {
            zz_Recuerdo a = new zz_Recuerdo();
            a.Ruta = ruta;
            a.Nombre = ruta.Substring(ruta.LastIndexOf("\\") + 1);
            using (var md5 = MD5.Create()) {
                using (var stream = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 1024 * 1024)) {
                    a.MD5Fichero = md5.ComputeHash(stream);
                }
            }

            a.mModificado = false;

            return a;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}

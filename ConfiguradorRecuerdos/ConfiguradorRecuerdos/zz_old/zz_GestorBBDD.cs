using Recuerdos.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recuerdos.Sql
{
    class zz_GestorBBDD
    {

        private string mRuta;
        private SQLiteConnection mConexion;

        public zz_GestorBBDD(string ruta) {
            mRuta = ruta;
        }

        public void AbrirConexion() {

            bool recienCreado = false;
            // Si ya existe, la devolvemos sin más.
            if (!File.Exists(Path.GetFullPath(mRuta))) {
                SQLiteConnection.CreateFile(mRuta);
                recienCreado = true;
            }

            mConexion = new SQLiteConnection("Data Source=" + mRuta + ";Version=3;");

            mConexion.Open();

            if (recienCreado)
                crearBBDD();
            
        }

        public void CerrarConexion() {
            mConexion.Close();
        }

        private void crearBBDD() {
            SQLiteCommand command = new SQLiteCommand(@"
                CREATE TABLE ARCHIVOS(
                    IDARCHIVO SERIAL PRIMARY KEY,
                    RUTA TEXT,
                    NOMBRE TEXT,
                    DIA INTEGER NULL,
                    MES INTEGER NULL,
                    ANNO INTEGER NULL,
                    MD5 BLOB,
                    LUGAR TEXT);",
                mConexion);

            command.ExecuteNonQuery();
            
        }

    }
}

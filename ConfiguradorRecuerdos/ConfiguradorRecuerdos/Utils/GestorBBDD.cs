using Recuerdos.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Recuerdos.Modelo.Recuerdo;

namespace Recuerdos.Sql
{
    class GestorBBDD
    {

        public static string NombreBBDD = "bbdd_recuerdos.sqlite";

        private Biblioteca mBiblioteca;
        public SQLiteConnection Conexion { get; private set; } = null;
        public bool Transaccion { get; private set; } = false;

        public GestorBBDD(Biblioteca biblioteca) {
            mBiblioteca = biblioteca;
        }



        #region Recuerdos

        public List<Recuerdo> LeerTodosLosRecuerdos() {
            List<Recuerdo> ret = new List<Recuerdo>();

            AbrirConexion();

            SQLiteCommand command = new SQLiteCommand(
                @"SELECT " +
                    "E.ID_ELEMENTO, " +
                    "E.DESCRIPCION, " +
                    "E.FECHA_CREACION, " +
                    "R.ID_RECUERDO, " +
                    "R.RUTA, " +
                    "R.TIPO_RECUERDO, " +
                    "R.LUGAR, " +
                    "R.FUENTE, " +
                    "R.MD5, " +
                    "R.REVISADO, " +
                    "R.ID_EVENTO " +
                "FROM ELEMENTOS E " +
                    "INNER JOIN RECUERDOS R ON R.ID_ELEMENTO = E.ID_ELEMENTO "
                ,
                Conexion);

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read()) {

                int idElemento = reader.GetInt32(0);
                string descripcion = reader.GetString(1);

                string fechaCreacionString = reader.GetString(2);
                DateTime fechaCreacion = DateTime.Parse(fechaCreacionString);

                string tipoString = reader.GetString(5);
                TipoRecuerdo tipo = (TipoRecuerdo)Enum.Parse(typeof(TipoRecuerdo), tipoString);


                Recuerdo r = new Recuerdo(
                    idElemento, // E.ID_ELEMENTO
                    descripcion, // E.DESCRIPCION
                    fechaCreacion, // E.FECHA_CREACION
                    reader.GetInt32(3), // R.ID_RECUERDO
                    reader.GetString(4), // R.RUTA
                    tipo, // R.TIPO_RECUERDO
                    reader.GetString(6), // R.LUGAR
                    reader.GetString(7), // R.FUENTE
                    reader.GetString(8), // R.MD5
                    reader.GetInt32(9) == 1, // R.REVISADO
                    reader.IsDBNull(10) ? -1 : reader.GetInt32(10), // R.ID_EVENTO
                    false, // Borrado
                    false // Nuevo
                );

                ret.Add(r);
            }

            reader.Close();
            CerrarConexion();

            return ret;
        }

        public void RecuperarRecuerdo(Recuerdo recuerdo) {
            List<Recuerdo> ret = new List<Recuerdo>();

            AbrirConexion();

            SQLiteCommand command = new SQLiteCommand(
                @"SELECT " +
                    "E.ID_ELEMENTO, " +
                    "E.DESCRIPCION, " +
                    "E.FECHA_CREACION, " +
                    "R.ID_RECUERDO, " +
                    "R.RUTA, " +
                    "R.TIPO_RECUERDO, " +
                    "R.LUGAR, " +
                    "R.FUENTE, " +
                    "R.MD5, " +
                    "R.REVISADO, " +
                    "R.ID_EVENTO " +
                "FROM ELEMENTOS E " +
                    "INNER JOIN RECUERDOS R ON R.ID_ELEMENTO = E.ID_ELEMENTO " +
                "WHERE E.ID_ELEMENTO = " + recuerdo.IdElemento,
                Conexion);

            SQLiteDataReader reader = command.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                CerrarConexion();
                throw new Exception("El recuerdo a recuperar (id_elemento = " + recuerdo.IdElemento + ") no existe en la BBDD");
            }

            string descripcion = reader.GetString(1);

            //string fechaCreacionString = reader.GetString(2);
            //DateTime fechaCreacion = DateTime.Parse(fechaCreacionString);

            //string tipoString = reader.GetString(5);
            //TipoRecuerdo tipo = (TipoRecuerdo)Enum.Parse(typeof(TipoRecuerdo), tipoString);

            recuerdo.Descripcion = descripcion;
            recuerdo.Ruta = reader.GetString(4);
            recuerdo.Lugar = reader.GetString(6);
            recuerdo.Fuente = reader.GetString(7);
            recuerdo.Revisado = reader.GetInt32(9) == 1;
            recuerdo.IdEvento = reader.IsDBNull(10) ? -1 : reader.GetInt32(10);
            recuerdo.Borrado = false;
            recuerdo.Nuevo = false;

            reader.Close();
            CerrarConexion();

        }


        public void InsertarRecuerdo(Recuerdo rec, bool gestionarConexiones = true) {

            if(gestionarConexiones)
                AbrirConexion();

            SQLiteCommand command = new SQLiteCommand(@"
                INSERT INTO ELEMENTOS(DESCRIPCION, FECHA_CREACION) VALUES ('', DATETIME());",
                Conexion);

            command.ExecuteNonQuery();
            rec.IdElemento = (int)Conexion.LastInsertRowId;

            string rutaConComillasEscapadas = rec.Ruta.Replace("\'", "\'\'");

            command = new SQLiteCommand(@"
                INSERT INTO RECUERDOS(ID_ELEMENTO, RUTA, TIPO_RECUERDO, LUGAR, FUENTE, MD5, REVISADO, ID_EVENTO) VALUES (" +
                rec.IdElemento + ", " +
                "'" + rutaConComillasEscapadas + "', " +
                "'" + rec.Tipo + "', " +
                "'', " +
                "'', " +
                "'" + rec.Md5 + "', " +
                "0, " +
                (rec.IdEvento == -1 ? "NULL" : rec.IdEvento + "") +
                ");", Conexion);

            command.ExecuteNonQuery();
            rec.IdRecuerdo = (int) Conexion.LastInsertRowId;

            if (gestionarConexiones)
                CerrarConexion();
        }

        public void ActualizarRecuerdo(Recuerdo rec, bool gestionarConexiones = true) {

            if (gestionarConexiones)
                AbrirConexion();

            SQLiteCommand command = new SQLiteCommand(@"
                UPDATE ELEMENTOS SET " +
                    "DESCRIPCION = '" + rec.Descripcion + "' " +
                "WHERE ID_ELEMENTO = " + rec.IdElemento + ";",
                Conexion);

            command.ExecuteNonQuery();

            string rutaConComillasEscapadas = rec.Ruta.Replace("\'", "\'\'");

            command = new SQLiteCommand(@"
                UPDATE RECUERDOS SET " +
                    "RUTA = '" + rutaConComillasEscapadas + "', " +
                    "TIPO_RECUERDO = '" + rec.Tipo + "', " +
                    "LUGAR = '" + rec.Lugar + "', " + 
                    "FUENTE = '" + rec.Fuente + "', " + 
                    "MD5 = '" + rec.Md5 + "', " +
                    "REVISADO = " + (rec.Revisado ? 1 : 0) + ", " +
                    "ID_EVENTO = " + (rec.IdEvento == -1 ? "NULL" : rec.IdEvento + "") + " " +
                "WHERE ID_RECUERDO = " + rec.IdRecuerdo + ";", Conexion);

            command.ExecuteNonQuery();

            if (gestionarConexiones)
                CerrarConexion();
        }

        public void BorrarRecuerdo(Recuerdo r) {
            AbrirConexion();

            SQLiteCommand command = new SQLiteCommand(@"
                DELETE FROM ELEMENTOS WHERE ID_ELEMENTO = " + r.IdElemento + ";",
                Conexion);

            command.ExecuteNonQuery();

            CerrarConexion();
        }

        #endregion


        #region Eventos

        public List<Evento> LeerTodosLosEventos() {
            List<Evento> ret = new List<Evento>();

            AbrirConexion();

            SQLiteCommand command = new SQLiteCommand(
                @"SELECT " +
                    "EL.ID_ELEMENTO, " +
                    "EL.DESCRIPCION, " +
                    "EL.FECHA_CREACION, " +
                    "EV.ID_EVENTO, " +
                    "EV.NOMBRE, " +
                    "EV.LUGAR " +
                "FROM ELEMENTOS EL " +
                    "INNER JOIN EVENTOS EV ON EV.ID_ELEMENTO = EL.ID_ELEMENTO "
                ,
                Conexion);

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read()) {

                int idElemento = reader.GetInt32(0);
                string descripcion = reader.GetString(1);

                string fechaCreacionString = reader.GetString(2);
                DateTime fechaCreacion = DateTime.Parse(fechaCreacionString);

               Evento e = new Evento(
                    idElemento, // EL.ID_ELEMENTO
                    descripcion, // EL.DESCRIPCION
                    fechaCreacion, // EL.FECHA_CREACION
                    reader.GetInt32(3), // EV.ID_EVENTO
                    reader.GetString(4), // EV.NOMBRE
                    reader.GetString(5) // EV.LUGAR
                );
                ret.Add(e);
            }

            reader.Close();
            CerrarConexion();

            return ret;
        }

        public void InsertarEvento(Evento evento, bool gestionarConexiones = true) {

            if (gestionarConexiones)
                AbrirConexion();

            SQLiteCommand command = new SQLiteCommand(@"
                INSERT INTO ELEMENTOS(DESCRIPCION, FECHA_CREACION) VALUES ('', DATETIME());",
                Conexion);

            command.ExecuteNonQuery();
            evento.IdElemento = (int)Conexion.LastInsertRowId;

            command = new SQLiteCommand(@"
                INSERT INTO EVENTOS(ID_ELEMENTO, NOMBRE, LUGAR) VALUES (" +
                evento.IdElemento + ", " +
                "'" + evento.Nombre + "', " +
                "'" + evento.Lugar + "' " +
                ");", Conexion);

            command.ExecuteNonQuery();
            evento.IdEvento = (int)Conexion.LastInsertRowId;

            if (gestionarConexiones)
                CerrarConexion();
        }

        public void ActualizarEvento(Evento evento, bool gestionarConexiones = true) {

            if (gestionarConexiones)
                AbrirConexion();

            SQLiteCommand command = new SQLiteCommand(@"
                UPDATE ELEMENTOS SET " +
                    "DESCRIPCION = '" + evento.Descripcion + "' " +
                "WHERE ID_ELEMENTO = " + evento.IdElemento + ";",
                Conexion);

            command.ExecuteNonQuery();

            command = new SQLiteCommand(@"
                UPDATE EVENTOS SET " +
                    "NOMBRE = '" + evento.Nombre + "', " +
                    "LUGAR= '" + evento.Lugar + "' " +
                "WHERE ID_EVENTO = " + evento.IdEvento+ ";", Conexion);

            command.ExecuteNonQuery();

            if (gestionarConexiones)
                CerrarConexion();
        }

        public void BorrarEvento(Evento evento) {
            AbrirConexion();

            SQLiteCommand command = new SQLiteCommand(@"
                DELETE FROM ELEMENTOS WHERE ID_ELEMENTO = " + evento.IdElemento + ";",
                Conexion);

            command.ExecuteNonQuery();

            CerrarConexion();
        }

        #endregion


        #region Gestión BBDD

        public void AbrirConexion(bool transaccion = false) {

            Conexion = new SQLiteConnection("Data Source=" + getRutaBBDD() + ";Version=3;");
            Conexion.Open();

            if (transaccion) 
                AbrirTransaccion();
            
        }

        public void CerrarConexion(bool transaccion = false) {

            if (transaccion)
                CerrarTransaccion();


            Conexion.Close();
            Conexion.Dispose();
            Conexion = null;
        }

        public void AbrirTransaccion() {

            SQLiteCommand command = new SQLiteCommand("BEGIN",Conexion);

            command.ExecuteNonQuery();
            Transaccion = true;
        }

        public void CerrarTransaccion() {
            if (!Transaccion)
                return;

            SQLiteCommand command = new SQLiteCommand("END", Conexion);

            command.ExecuteNonQuery();
            Transaccion = false;
        }

        public void IniciarBBDD() {

        }

        public bool ExisteBBDD() {
            return File.Exists(getRutaBBDD());
        }


        public void CrearBBDD() {

            SQLiteConnection.CreateFile(getRutaBBDD());

            AbrirConexion();

            SQLiteCommand command = new SQLiteCommand(@"
                CREATE TABLE ELEMENTOS(
                    ID_ELEMENTO INTEGER PRIMARY KEY AUTOINCREMENT,
                    DESCRIPCION TEXT,
                    FECHA_CREACION TEXT
                );",
                Conexion);

            command.ExecuteNonQuery();

            command = new SQLiteCommand(@"
                CREATE TABLE RECUERDOS(
                    ID_RECUERDO INTEGER PRIMARY KEY AUTOINCREMENT,
                    ID_ELEMENTO INTEGER REFERENCES ELEMENTOS(ID_ELEMENTO),
                    RUTA TEXT, 
                    TIPO_RECUERDO TEXT,
                    LUGAR TEXT,
                    ID_EVENTO INTEGER REFERENCES ELEMENTOS(ID_ELEMENTO),
                    --ID_FECHA INTEGER REFERENCES FECHAS.ID_FECHA,
                    FUENTE TEXT,
                    MD5 TEXT,
                    REVISADO INTEGER
                );",
                Conexion);

            command.ExecuteNonQuery();

            command = new SQLiteCommand(@"
                CREATE TABLE EVENTOS(
                    ID_EVENTO INTEGER PRIMARY KEY AUTOINCREMENT,
                    ID_ELEMENTO INTEGER REFERENCES ELEMENTOS(ID_ELEMENTO),
                    NOMBRE TEXT,
                    LUGAR TEXT
                    --ID_FECHA INTEGER REFERENCES FECHAS.ID_FECHA
                );",
                Conexion);

            command.ExecuteNonQuery();


            CerrarConexion();
        }

        #endregion

        public string getRutaBBDD() {
            return mBiblioteca.Ruta + "\\" + NombreBBDD;
        }

    }
}

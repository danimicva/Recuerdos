using System.Data.SQLite;

namespace Recuerdos.Modelo.BBDD
{
    class GestorBBDD
    {

        public static string NombreBBDD = "bbdd_recuerdos.sqlite";

        private readonly Biblioteca mBiblioteca;
        public SQLiteConnection? Conexion { get; private set; } = null;
        public bool Transaccion { get; private set; } = false;

        public GestorBBDD(Biblioteca biblioteca) {
            mBiblioteca = biblioteca;
            Conexion = null;
        }

        #region Personas

        public int ObtenerUsosPersona(int idPersona) {

            int usos;

            if (Conexion == null)
                throw new SqlException("Conexión es null");
            

            string sql = ConsultasBBDD.SelectUsosPersona(idPersona);

            SQLiteCommand command = new(sql, Conexion);

            SQLiteDataReader reader = command.ExecuteReader();

            if (!reader.Read())
                usos = 0;
            else
                usos = reader.GetInt32(0);

            reader.Close();

            return usos;
        }

        public List<Persona> LeerTodasLasPersonas() {

            if (Conexion == null)
                throw new SqlException("Conexión es null");

            List<Persona> ret = new();

            string sql = ConsultasBBDD.SelectPersonas();

            SQLiteCommand command = new(sql, Conexion);

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read()) {

                Persona p = new();

                ConsultasBBDD.RecuperarPersona(reader, p);

                ret.Add(p);
            }

            reader.Close();

            return ret;
        }

        public void RecuperarPersona(Persona persona) {

            if (Conexion == null)
                throw new SqlException("Conexión es null");

            if (persona.IdElemento == null)
                return;

            string sql = ConsultasBBDD.SelectPersonas(persona.IdElemento);

            SQLiteCommand command = new(sql, Conexion);

            SQLiteDataReader reader = command.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                throw new Exception("La persona a recuperar (id_elemento = " + persona.IdElemento + ") no existe en la BBDD");
            }
            ConsultasBBDD.RecuperarPersona(reader, persona);

            reader.Close();


        }

        public void InsertarPersona(Persona persona) {

            if (Conexion == null)
                throw new SqlException("Conexión es null");

            string sql = ConsultasBBDD.InsertElemento(persona);

            SQLiteCommand command = new(sql, Conexion);

            command.ExecuteNonQuery();
            persona.IdElemento = (int)Conexion.LastInsertRowId;

            sql = ConsultasBBDD.InsertPersona(persona);

            command = new(sql, Conexion);

            command.ExecuteNonQuery();
            persona.IdPersona = (int)Conexion.LastInsertRowId;

        }

        public void ActualizarPersona(Persona persona) {

            if (Conexion == null)
                throw new SqlException("Conexión es null");

            string sql = ConsultasBBDD.UpdateElemento(persona);

            SQLiteCommand command = new(sql, Conexion);

            command.ExecuteNonQuery();

            sql = ConsultasBBDD.UpdatePersona(persona);

            command = new(sql, Conexion);

            command.ExecuteNonQuery();

        }

        public void BorrarPersona(Persona persona) {

            if (Conexion == null)
                throw new SqlException("Conexión es null");

            if (persona == null || persona.IdPersona == null)
                return;

            BorrarEventoPersona(persona);
            BorrarRecuerdoPersona(persona);

            string sql = ConsultasBBDD.DeletePersona(persona.IdPersona.Value);

            SQLiteCommand command = new(sql, Conexion);

            command.ExecuteNonQuery();

        }

        #endregion

        #region Recuerdos

        public List<Recuerdo> LeerTodosLosRecuerdos() {

            if (Conexion == null)
                throw new SqlException("Conexión es null");

            List<Recuerdo> ret = new();

            string sql = ConsultasBBDD.SelectRecuerdos();

            SQLiteCommand command = new(sql, Conexion);

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read()) {

                Recuerdo r = new();

                ConsultasBBDD.LeerRecuerdoDeReader(reader, r);

                if (r.IdEvento != null) {
                    Evento? e = mBiblioteca.Eventos.FirstOrDefault(ee => ee.IdEvento == r.IdEvento);
                    if(e != null)
                        r.Evento = e;
                }

                ret.Add(r);
                leerRecuerdoPersona(r);
            }

            reader.Close();
            
            return ret;
        }

        public void RecuperarRecuerdo(Recuerdo recuerdo) {

            if (Conexion == null)
                throw new SqlException("Conexión es null");

            if (recuerdo.IdElemento == null)
                return;

            string sql = ConsultasBBDD.SelectRecuerdos(recuerdo.IdElemento);

            SQLiteCommand command = new(sql, Conexion);

            SQLiteDataReader reader = command.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                throw new Exception("El recuerdo a recuperar (id_elemento = " + recuerdo.IdElemento + ") no existe en la BBDD");
            }
            ConsultasBBDD.LeerRecuerdoDeReader(reader, recuerdo);

            if (recuerdo.IdEvento != null) {
                Evento? e = mBiblioteca.Eventos.FirstOrDefault(ee => ee.IdEvento == recuerdo.IdEvento);
                if (e != null)
                    recuerdo.Evento = e;
            }

            reader.Close();

            leerRecuerdoPersona(recuerdo);

        }

        private void leerRecuerdoPersona(Recuerdo recuerdo) {

            if (Conexion == null)
                throw new SqlException("Conexión es null");

            SQLiteCommand command;
            SQLiteDataReader reader;

            if (recuerdo.IdRecuerdo == null)
                return;


            string sql = ConsultasBBDD.SelectRecuerdoPersonas(recuerdo.IdRecuerdo.Value);
            command = new(sql, Conexion);
            reader = command.ExecuteReader();

            recuerdo.Personas.Clear();

            while (reader.Read()) {
                int idPersona = reader.GetInt32(0);

                Persona? p = mBiblioteca.Personas.FirstOrDefault(p => p.IdPersona == idPersona);

                if (p == null) {
                    continue;
                }

                recuerdo.Personas.Add(new(recuerdo.IdRecuerdo, p));
            }

            reader.Close();
            command.Dispose();

        }

        public void InsertarRecuerdo(Recuerdo recuerdo) {

            if (Conexion == null)
                throw new SqlException("Conexión es null");

            string sql = ConsultasBBDD.InsertElemento(recuerdo);

            SQLiteCommand command = new(sql, Conexion);

            command.ExecuteNonQuery();
            recuerdo.IdElemento = (int)Conexion.LastInsertRowId;

            sql = ConsultasBBDD.InsertRecuerdo(recuerdo);

            command = new(sql, Conexion);

            command.ExecuteNonQuery();
            recuerdo.IdRecuerdo = (int)Conexion.LastInsertRowId;

        }

        public void InsertarRecuerdoPersona(Recuerdo recuerdo) {

            if (Conexion == null)
                throw new SqlException("Conexión es null");

            recuerdo.Personas.Where(rp => rp.Persona != null).ToList().ForEach(rp => {

                if (rp.IdRecuerdo == null || rp.Persona == null || rp.Persona.IdPersona == null)
                    throw new Exception("Se intenta guardar un RecuerdoPersona sin idRecuerdo o sin persona o sin persona registrada");

                rp.IdPersona = rp.Persona.IdPersona;

                /*
                if (rp.Persona.IdPersona == null) {
                    InsertarPersona(rp.Persona);
                    mBiblioteca.Personas.Add(rp.Persona);
                    rp.IdPersona = rp.Persona.IdPersona;
                }
                */

#pragma warning disable CS8629 // Un tipo que acepta valores NULL puede ser nulo.
                string sql = ConsultasBBDD.InsertRecuerdoPersona(rp.IdRecuerdo.Value, rp.Persona.IdPersona.Value);
#pragma warning restore CS8629 // Un tipo que acepta valores NULL puede ser nulo.
                SQLiteCommand command = new(sql, Conexion);
                command.ExecuteNonQuery();

            });
        }

        public void ActualizarRecuerdo(Recuerdo recuerdo) {

            if (Conexion == null)
                throw new SqlException("Conexión es null");

            string sql = ConsultasBBDD.UpdateElemento(recuerdo);

            SQLiteCommand command = new(sql, Conexion);

            command.ExecuteNonQuery();

            sql = ConsultasBBDD.UpdateRecuerdo(recuerdo);

            command = new(sql, Conexion);

            command.ExecuteNonQuery();


        }

        public void BorrarRecuerdo(Recuerdo recuerdo) {

            if (Conexion == null)
                throw new SqlException("Conexión es null");


            BorrarRecuerdoPersona(recuerdo);

            string sql = ConsultasBBDD.DeleteElemento(recuerdo);

            SQLiteCommand command = new(sql, Conexion);

            command.ExecuteNonQuery();

            sql = ConsultasBBDD.DeleteRecuerdo(recuerdo);

            command = new(sql, Conexion);

            command.ExecuteNonQuery();

        }

        public void BorrarRecuerdoPersona(Recuerdo recuerdo) {

            if (Conexion == null)
                throw new SqlException("Conexión es null");

            string sql;
            SQLiteCommand command;

            if (recuerdo.IdRecuerdo == null)
                return;


            sql = ConsultasBBDD.DeleteRecuerdoPersonaPorRecuerdo(recuerdo.IdRecuerdo.Value);
            command = new(sql, Conexion);
            command.ExecuteNonQuery();

        }

        private void BorrarRecuerdoPersona(Persona persona) {

            if (Conexion == null)
                throw new SqlException("Conexión es null");

            string sql;
            SQLiteCommand command;

            if (persona.IdPersona == null)
                return;


            sql = ConsultasBBDD.DeleteRecuerdoPersonaPorPersona(persona.IdPersona.Value);
            command = new(sql, Conexion);
            command.ExecuteNonQuery();

        }

        #endregion

        #region Eventos

        public List<Evento> LeerTodosLosEventos() {

            if (Conexion == null)
                throw new SqlException("Conexión es null");

            List<Evento> ret = new();
            SQLiteCommand command;
            SQLiteDataReader reader;

            string sql = ConsultasBBDD.SelectEventos();

            command = new(sql, Conexion);

            reader = command.ExecuteReader();

            while (reader.Read()) {

                Evento e = new();

                ConsultasBBDD.LeerEventoDeReader(reader, e);

                ret.Add(e);
                //Los eventoPersona
                leerEventoPersona(e);
            }

            reader.Close();

            return ret;
        }

        public void RecuperarEvento(Evento evento) {

            if (Conexion == null)
                throw new SqlException("Conexión es null");

            string sql = ConsultasBBDD.SelectEventos(evento.IdElemento);

            SQLiteCommand command = new(sql, Conexion);

            SQLiteDataReader reader = command.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                throw new Exception("El evento a recuperar (id_elemento = " + evento.IdElemento + ") no existe en la BBDD");
            }

            ConsultasBBDD.LeerEventoDeReader(reader, evento);

            leerEventoPersona(evento);

            reader.Close();

        }

        private void leerEventoPersona(Evento evento) {

            if (Conexion == null)
                throw new SqlException("Conexión es null");

            SQLiteCommand command;
            SQLiteDataReader reader;

            if (evento.IdEvento == null) 
                return;


            string sql = ConsultasBBDD.SelectEventoPersonas(evento.IdEvento.Value);
            command = new(sql, Conexion);
            reader = command.ExecuteReader();

            evento.Personas.Clear();

            while (reader.Read()) {
                int idPersona = reader.GetInt32(0);

                Persona? p = mBiblioteca.Personas.FirstOrDefault(p => p.IdPersona == idPersona);

                if(p == null) {
                    continue;
                }

                evento.Personas.Add(new(evento.IdEvento, p));
            }

            reader.Close();
            command.Dispose();

        }

        public void InsertarEvento(Evento evento) {

            if (Conexion == null)
                throw new SqlException("Conexión es null");

            // Insertamos el elemento
            string sql = ConsultasBBDD.InsertElemento(evento);
            SQLiteCommand command = new(sql, Conexion);
            command.ExecuteNonQuery();
            evento.IdElemento = (int)Conexion.LastInsertRowId;

            // Insertamos el evento
            sql = ConsultasBBDD.InsertEvento(evento);
            command = new(sql, Conexion);
            command.ExecuteNonQuery();
            evento.IdEvento = (int)Conexion.LastInsertRowId;

            evento.Personas.ForEach(p => p.IdEvento = evento.IdEvento);

        }

        public void InsertarEventoPersona(Evento evento) {

            if (Conexion == null)
                throw new SqlException("Conexión es null");

            evento.Personas.Where(ep=> ep.Persona != null).ToList().ForEach(ep => {

                if (ep.IdEvento == null || ep.Persona == null || ep.Persona.IdPersona == null)
                    throw new Exception("Se intenta guardar un EventoPersona sin idEvento o sin persona o sin persona registrada");

                ep.IdPersona = ep.Persona.IdPersona;
                /*
                if(ep.Persona.IdPersona == null) {
                    InsertarPersona(ep.Persona);
                    mBiblioteca.Personas.Add(ep.Persona);
                    ep.IdPersona = ep.Persona.IdPersona;
                }
                */

#pragma warning disable CS8629 // Un tipo que acepta valores NULL puede ser nulo.
                string sql = ConsultasBBDD.InsertEventoPersona(ep.IdEvento.Value, ep.IdPersona.Value);
#pragma warning restore CS8629 // Un tipo que acepta valores NULL puede ser nulo.
                SQLiteCommand command = new(sql, Conexion);
                command.ExecuteNonQuery();

            });
        }

        public void ActualizarEvento(Evento evento) {

            if (Conexion == null)
                throw new SqlException("Conexión es null");

            string sql = ConsultasBBDD.UpdateElemento(evento);

            SQLiteCommand command = new(sql, Conexion);

            command.ExecuteNonQuery();

            sql = ConsultasBBDD.UpdateEvento(evento);

            command = new(sql, Conexion);

            command.ExecuteNonQuery();


        }

        public void BorrarEvento(Evento evento) {

            if (Conexion == null)
                throw new SqlException("Conexión es null");

            string sql;
            SQLiteCommand command;

            if (evento.IdEvento == null)
                return;

            BorrarEventoPersona(evento);

            sql = ConsultasBBDD.DeleteEvento(evento.IdEvento.Value);
            command = new(sql, Conexion);
            command.ExecuteNonQuery();

            sql = ConsultasBBDD.DeleteElemento(evento);
            command = new(sql, Conexion);
            command.ExecuteNonQuery();


        }

        public void BorrarEventoPersona(Evento evento) {

            if (Conexion == null)
                throw new SqlException("Conexión es null");

            string sql;
            SQLiteCommand command;

            if (evento.IdEvento == null)
                return;


            sql = ConsultasBBDD.DeleteEventoPersonaPorEvento(evento.IdEvento.Value);
            command = new(sql, Conexion);
            command.ExecuteNonQuery();

        }

        private void BorrarEventoPersona(Persona persona) {

            if (Conexion == null)
                throw new SqlException("Conexión es null");

            string sql;
            SQLiteCommand command;

            if (persona.IdPersona == null)
                return;


            sql = ConsultasBBDD.DeleteEventoPersonaPorPersona(persona.IdPersona.Value);
            command = new(sql, Conexion);
            command.ExecuteNonQuery();

        }

        #endregion


        #region Gestión BBDD

        public void AbrirConexion(bool transaccion = false) {

            Conexion = new("Data Source=" + getRutaBBDD() + ";Version=3;");
            Conexion.Open();
            /*
            string sql = "PRAGMA foreign_keys = ON;";

            SQLiteCommand command = new(sql, Conexion);
            command.ExecuteNonQuery();
            */
            if (transaccion)
                AbrirTransaccion();

        }

        public void CerrarConexion(bool transaccion = false) {

            if (Conexion == null)
                throw new SqlException("Conexión es null");

            if (transaccion)
                CerrarTransaccion();

            Conexion.Close();
            Conexion.Dispose();
            Conexion = null;
        }

        public void AbrirTransaccion() {

            SQLiteCommand command = new("BEGIN", Conexion);

            command.ExecuteNonQuery();
            Transaccion = true;
        }

        public void CerrarTransaccion() {
            if (!Transaccion)
                return;

            SQLiteCommand command = new("END", Conexion);

            command.ExecuteNonQuery();
            Transaccion = false;
        }

        public bool ExisteBBDD() {
            return File.Exists(getRutaBBDD());
        }

        public void CrearBBDD() {

            SQLiteConnection.CreateFile(getRutaBBDD());

            AbrirConexion();

            string sql = ConsultasBBDD.CreateAllTables();

            SQLiteCommand command = new(sql,Conexion);

            command.ExecuteNonQuery();

            CerrarConexion();
        }

        #endregion

        public string getRutaBBDD() {
            return mBiblioteca.Ruta + "\\" + NombreBBDD;
        }

    }
}

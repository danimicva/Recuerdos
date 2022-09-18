using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Recuerdos.Modelo.MiFecha;
using static Recuerdos.Modelo.Recuerdo;

namespace Recuerdos.Modelo.BBDD
{
    internal class ConsultasBBDD
    {

        #region Elementos
        public static string InsertElemento(Elemento elemento) {
            return "INSERT INTO ELEMENTOS(" +
                        "DESCRIPCION, " +
                        "FECHA_CREACION" +
                    ") VALUES (" +
                        "'" + elemento.Descripcion + "', " +
                        "'" + elemento.FechaCreacion.ToShortDateString() + "'" +
                    ")";
        }

        public static string UpdateElemento(Elemento elemento) {
            return "UPDATE ELEMENTOS SET " +
                        "DESCRIPCION = '" + elemento.Descripcion + "' " +
                    "WHERE ID_ELEMENTO = " + elemento.IdElemento + ";";
        }

        public static string DeleteElemento(Elemento elemento) {
            return "DELETE FROM " +
                        "ELEMENTOS " +
                    "WHERE " +
                        "ID_ELEMENTO = " + elemento.IdElemento + ";";
        }

        #endregion

        #region Recuerdos

        public static string SelectRecuerdos(int? idElemento = null) =>
@"SELECT 
    E.ID_ELEMENTO, 
    E.DESCRIPCION, 
    E.FECHA_CREACION, 
    R.ID_RECUERDO, 
    R.RUTA, 
    R.TIPO_RECUERDO, 
    R.LUGAR, 
    R.FUENTE, 
    R.MD5, 
    R.REVISADO, 
    R.ID_EVENTO, 
    R.TIPO_FECHA,
    R.DIA1,
    R.MES1,
    R.ANO1,
    R.DIA2,
    R.MES2,
    R.ANO2
FROM ELEMENTOS E 
    INNER JOIN RECUERDOS R ON R.ID_ELEMENTO = E.ID_ELEMENTO 
" + (idElemento != null ? "WHERE e.ID_ELEMENTO = " + idElemento : "");
        
        public static string InsertRecuerdo(Recuerdo recuerdo) {

            string rutaConComillasEscapadas = recuerdo.Ruta.Replace("\'", "\'\'");

            return
@"INSERT INTO RECUERDOS(
    ID_ELEMENTO,
    RUTA, 
    TIPO_RECUERDO, 
    LUGAR, 
    FUENTE, 
    MD5,
    REVISADO, 
    ID_EVENTO, 
    TIPO_FECHA,
    DIA1,
    MES1,
    ANO1,
    DIA2,
    MES2,
    ANO2
) VALUES (
    " + recuerdo.IdElemento + @", 
    '" + rutaConComillasEscapadas + @"', 
    '" + recuerdo.Tipo + @"', 
    '" + recuerdo.Lugar + @"', 
    '" + recuerdo.Fuente + @"', 
    '" + recuerdo.Md5 + @"', 
    0, 
    " + (recuerdo.IdEvento == null ? "NULL" : recuerdo.IdEvento + "") + @",

    '" + recuerdo.Fecha.Tipo + @"',
    " + (recuerdo.Fecha.Dia == null ? "NULL" : recuerdo.Fecha.Dia) + @", 
    " + (recuerdo.Fecha.Mes == null ? "NULL" : recuerdo.Fecha.Mes) + @", 
    " + (recuerdo.Fecha.Año == null ? "NULL" : recuerdo.Fecha.Año) + @", 
    " + (recuerdo.Fecha.Dia2 == null ? "NULL" : recuerdo.Fecha.Dia2) + @", 
    " + (recuerdo.Fecha.Mes2 == null ? "NULL" : recuerdo.Fecha.Mes2) + @", 
    " + (recuerdo.Fecha.Año2 == null ? "NULL" : recuerdo.Fecha.Año2) + @"
);";
        }

        public static string UpdateRecuerdo(Recuerdo recuerdo) {

            string rutaConComillasEscapadas = recuerdo.Ruta.Replace("\'", "\'\'");

            return 
@"UPDATE RECUERDOS SET 
    RUTA = '" + rutaConComillasEscapadas + @"', 
    TIPO_RECUERDO = '" + recuerdo.Tipo + @"', 
    LUGAR = '" + recuerdo.Lugar + @"', 
    FUENTE = '" + recuerdo.Fuente + @"', 
    MD5 = '" + recuerdo.Md5 + @"', 
    REVISADO = " + (recuerdo.Revisado ? 1 : 0) + @", 
    ID_EVENTO = " + (recuerdo.IdEvento == null ? "NULL" : recuerdo.IdEvento + "") + @",

    TIPO_FECHA = '" + recuerdo.Fecha.Tipo + @"',
    DIA1 = " + (recuerdo.Fecha.Dia == null ? "NULL" : recuerdo.Fecha.Dia) + @",
    MES1 = " + (recuerdo.Fecha.Mes == null ? "NULL" : recuerdo.Fecha.Mes) + @",
    ANO1 = " + (recuerdo.Fecha.Año == null ? "NULL" : recuerdo.Fecha.Año) + @",
    DIA2 = " + (recuerdo.Fecha.Dia2 == null ? "NULL" : recuerdo.Fecha.Dia2) + @",
    MES2 = " + (recuerdo.Fecha.Mes2 == null ? "NULL" : recuerdo.Fecha.Mes2) + @",
    ANO2 = " + (recuerdo.Fecha.Año2 == null ? "NULL" : recuerdo.Fecha.Año2) + @"
WHERE ID_RECUERDO = " + recuerdo.IdRecuerdo + ";";
        }

        public static void LeerRecuerdoDeReader(SQLiteDataReader reader, Recuerdo recuerdo) {

            int idElemento = reader.GetInt32(0);
            string descripcion = reader.GetString(1);

            string fechaCreacionString = reader.GetString(2);
            DateTime fechaCreacion = DateTime.Parse(fechaCreacionString);

            string tipoString = reader.GetString(5);
            TipoRecuerdo tipo = (TipoRecuerdo)Enum.Parse(typeof(TipoRecuerdo), tipoString);

            recuerdo.IdElemento = idElemento;
            recuerdo.Descripcion = descripcion;
            recuerdo.FechaCreacion = fechaCreacion;
            recuerdo.IdRecuerdo = reader.GetInt32(3);
            recuerdo.Ruta = reader.GetString(4);
            recuerdo.Tipo = tipo;
            recuerdo.Lugar = reader.GetString(6);
            recuerdo.Fuente = reader.GetString(7);
            recuerdo.Md5 = reader.GetString(8);
            recuerdo.Revisado = reader.GetInt32(9) == 1;
            recuerdo.IdEvento = reader.IsDBNull(10) ? null : reader.GetInt32(10);

            string? tipoFechaString = reader.IsDBNull(11) ? null : reader.GetString(11);
            TipoFecha tipoFecha = string.IsNullOrEmpty(tipoFechaString) ? TipoFecha.Vacia : Enum.Parse<TipoFecha>(tipoFechaString);

            MiFecha fecha = new() {
                Tipo = tipoFecha,
                Dia = reader.IsDBNull(12) ? null : reader.GetInt32(12),
                Mes = reader.IsDBNull(13) ? null : reader.GetInt32(13),
                Año = reader.IsDBNull(14) ? null : reader.GetInt32(14),
                Dia2 = reader.IsDBNull(15) ? null : reader.GetInt32(15),
                Mes2 = reader.IsDBNull(16) ? null : reader.GetInt32(16),
                Año2 = reader.IsDBNull(17) ? null : reader.GetInt32(17)
            };

            recuerdo.Fecha = fecha;
        }

        public static string DeleteRecuerdo(Recuerdo recuerdo) {
            return @"DELETE FROM RECUERDOS WHERE ID_RECUERDO = " + recuerdo.IdRecuerdo + ";";
        }


        #endregion

        #region Personas

        public static string SelectUsosPersona(int idPersona) =>
@"SELECT COUNT(*) FROM EVENTO_PERSONA WHERE ID_PERSONA = " + idPersona;

        public static string SelectPersonas(int? idElemento = null) =>
@"SELECT 
    E.ID_ELEMENTO, 
    E.DESCRIPCION, 
    E.FECHA_CREACION, 
    P.ID_PERSONA, 
    P.NOMBRE 
FROM ELEMENTOS E 
    INNER JOIN PERSONAS P ON P.ID_ELEMENTO = E.ID_ELEMENTO 
" + (idElemento != null ? "WHERE e.ID_ELEMENTO = " + idElemento : "");
        

        public static string InsertPersona(Persona persona) =>
@"INSERT INTO PERSONAS(
    ID_ELEMENTO, 
    NOMBRE 
) VALUES (
    " + persona.IdElemento + @", 
    '" + persona.Nombre + @"'
);";
        

        public static string UpdatePersona(Persona persona) =>
@"UPDATE PERSONAS SET 
    NOMBRE= '" + persona.Nombre + @"'
WHERE ID_PERSONA = " + persona.IdPersona+ ";";
        

        public static void RecuperarPersona(SQLiteDataReader reader, Persona persona) {

            int idElemento = reader.GetInt32(0);
            string descripcion = reader.GetString(1);

            string fechaCreacionString = reader.GetString(2);
            DateTime fechaCreacion = DateTime.Parse(fechaCreacionString);

            persona.IdElemento = idElemento;
            persona.Descripcion = descripcion;
            persona.FechaCreacion = fechaCreacion;
            persona.IdPersona= reader.GetInt32(3);
            persona.Nombre = reader.GetString(4);
        }

        public static string DeletePersona(int idPersona) =>
            @"DELETE FROM PERSONAS WHERE ID_PERSONA = " + idPersona + ";";

        #endregion

        #region Eventos

        public static string SelectEventos(int? idElemento = null) {
            return @"
SELECT 
    EL.ID_ELEMENTO, 
    EL.DESCRIPCION, 
    EL.FECHA_CREACION,
    EV.ID_EVENTO,
    EV.NOMBRE, 
    EV.LUGAR, 
    EV.TIPO_FECHA,
    EV.DIA1,
    EV.MES1,
    EV.ANO1,
    EV.DIA2,
    EV.MES2,
    EV.ANO2
FROM ELEMENTOS EL 
    INNER JOIN EVENTOS EV ON EV.ID_ELEMENTO = EL.ID_ELEMENTO 
" + (idElemento != null ? "WHERE EL.ID_ELEMENTO = " + idElemento : "");
        }

        public static string SelectEventoPersonas(int idEvento) =>
@"SELECT ID_PERSONA FROM EVENTO_PERSONA WHERE ID_EVENTO = " + idEvento;

        public static string InsertEvento(Evento evento) =>
@"INSERT INTO EVENTOS(
    ID_ELEMENTO, 
    NOMBRE, 
    LUGAR, 
    TIPO_FECHA,
    DIA1,
    MES1,
    ANO1,
    DIA2,
    MES2,
    ANO2
) VALUES (
    " + evento.IdElemento + @", 
    '" + evento.Nombre + @"', 
    '" + evento.Lugar + @"',
    '" + evento.Fecha.Tipo + @"',
    " + (evento.Fecha.Dia == null ? "NULL" : evento.Fecha.Dia) + @", 
    " + (evento.Fecha.Mes == null ? "NULL" : evento.Fecha.Mes) + @", 
    " + (evento.Fecha.Año == null ? "NULL" : evento.Fecha.Año) + @", 
    " + (evento.Fecha.Dia2 == null ? "NULL" : evento.Fecha.Dia2) + @", 
    " + (evento.Fecha.Mes2 == null ? "NULL" : evento.Fecha.Mes2) + @", 
    " + (evento.Fecha.Año2 == null ? "NULL" : evento.Fecha.Año2) + @"
);";

        public static string InsertEventoPersona(int idEvento, int idPersona) =>
@"INSERT INTO EVENTO_PERSONA(ID_EVENTO, ID_PERSONA) VALUES (" + idEvento + ", " + idPersona + ");";


        public static string UpdateEvento(Evento evento) =>
@"UPDATE EVENTOS SET 
    NOMBRE = '" + evento.Nombre + @"', 
    LUGAR= '" + evento.Lugar + @"', 
    TIPO_FECHA = '" + evento.Fecha.Tipo + @"',
    DIA1 = " + (evento.Fecha.Dia == null ? "NULL" : evento.Fecha.Dia) + @",
    MES1 = " + (evento.Fecha.Mes == null ? "NULL" : evento.Fecha.Mes) + @",
    ANO1 = " + (evento.Fecha.Año == null ? "NULL" : evento.Fecha.Año) + @",
    DIA2 = " + (evento.Fecha.Dia2 == null ? "NULL" : evento.Fecha.Dia2) + @",
    MES2 = " + (evento.Fecha.Mes2 == null ? "NULL" : evento.Fecha.Mes2) + @",
    ANO2 = " + (evento.Fecha.Año2 == null ? "NULL" : evento.Fecha.Año2) + @"
WHERE ID_EVENTO = " + evento.IdEvento + ";";
        

        public static string DeleteEvento(int idEvento) =>
@"DELETE FROM EVENTOS WHERE ID_EVENTO = " + idEvento + ";";

        public static string DeleteEventoPersonaPorEvento(int idEvento) =>
@"DELETE FROM EVENTO_PERSONA WHERE ID_EVENTO = " + idEvento + ";";

        public static string DeleteEventoPersonaPorPersona(int idPersona) =>
@"DELETE FROM EVENTO_PERSONA WHERE ID_PERSONA = " + idPersona + ";";


        public static void LeerEventoDeReader(SQLiteDataReader reader, Evento evento) {

            int idElemento = reader.GetInt32(0);
            string descripcion = reader.GetString(1);

            string fechaCreacionString = reader.GetString(2);
            DateTime fechaCreacion = DateTime.Parse(fechaCreacionString);

            evento.IdElemento = idElemento;
            evento.Descripcion = descripcion;
            evento.FechaCreacion = fechaCreacion;
            evento.IdEvento = reader.GetInt32(3);
            evento.Nombre = reader.GetString(4);
            evento.Lugar = reader.GetString(5);

            string? tipoFechaString = reader.IsDBNull(6) ? null : reader.GetString(6);
            TipoFecha tipo = string.IsNullOrEmpty(tipoFechaString) ? TipoFecha.Vacia : Enum.Parse<TipoFecha>(tipoFechaString);

            MiFecha fecha = new() {
                Tipo = tipo,
                Dia = reader.IsDBNull(7) ? null : reader.GetInt32(7),
                Mes = reader.IsDBNull(8) ? null : reader.GetInt32(8),
                Año = reader.IsDBNull(9) ? null : reader.GetInt32(9),
                Dia2 = reader.IsDBNull(10) ? null : reader.GetInt32(10),
                Mes2 = reader.IsDBNull(11) ? null : reader.GetInt32(11),
                Año2 = reader.IsDBNull(12) ? null : reader.GetInt32(12)
            };

            evento.Fecha = fecha;
            

        }

        #endregion


        #region General

        public static string CreateAllTables() =>

@"CREATE TABLE ELEMENTOS(
    ID_ELEMENTO INTEGER PRIMARY KEY AUTOINCREMENT,
    DESCRIPCION TEXT,
    FECHA_CREACION TEXT
); 

CREATE TABLE RECUERDOS(
    ID_RECUERDO INTEGER PRIMARY KEY AUTOINCREMENT,
    ID_ELEMENTO INTEGER REFERENCES ELEMENTOS(ID_ELEMENTO),
    RUTA TEXT, 
    TIPO_RECUERDO TEXT,
    LUGAR TEXT,
    ID_EVENTO INTEGER REFERENCES ELEMENTOS(ID_ELEMENTO),
    FUENTE TEXT,
    MD5 TEXT,
    REVISADO INTEGER,
    TIPO_FECHA TEXT,
    DIA1 INTEGER,
    MES1 INTEGER,
    ANO1 INTEGER,
    DIA2 INTEGER,
    MES2 INTEGER,
    ANO2 INTEGER
);

-- Pendiente poner que un evento pertenezca a otro evento
CREATE TABLE EVENTOS(
    ID_EVENTO INTEGER PRIMARY KEY AUTOINCREMENT,
    ID_ELEMENTO INTEGER,
    NOMBRE TEXT,
    LUGAR TEXT,
    TIPO_FECHA TEXT,
    DIA1 INTEGER,
    MES1 INTEGER,
    ANO1 INTEGER,
    DIA2 INTEGER,
    MES2 INTEGER,
    ANO2 INTEGER,
    FOREIGN KEY (ID_ELEMENTO) REFERENCES ELEMENTOS(ID_ELEMENTO)
);

CREATE TABLE PERSONAS(
    ID_PERSONA INTEGER PRIMARY KEY AUTOINCREMENT,
    ID_ELEMENTO INTEGER,
    NOMBRE TEXT,
    FOREIGN KEY (ID_ELEMENTO) REFERENCES ELEMENTOS(ID_ELEMENTO)
);

CREATE TABLE EVENTO_PERSONA(
    ID_EVENTO INTEGER,
    ID_PERSONA INTEGER,
    PRIMARY KEY(ID_EVENTO, ID_PERSONA),
    FOREIGN KEY (ID_EVENTO) REFERENCES EVENTOS(ID_EVENTO),
    FOREIGN KEY (ID_PERSONA) REFERENCES PERSONAS(ID_PERSONA)
);
";
        
        #endregion

    }
}

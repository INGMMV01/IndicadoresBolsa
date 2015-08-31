using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;

namespace Kitos.Bolsa.ObjetosBolsa.DatoPersist
{
    public class DatoPersistente
    {

        #region Atributos

        DateTime _dtFecha;
        string _strTicket;
        string _strDato;
        string _strValor;

        SqlConnection conn;
        SqlTransaction tr;

        #endregion

        #region Propiedades

        public DateTime Fecha
        {
            get { return _dtFecha; }
            set { _dtFecha = value; }
        }

        public string Ticket
        {
            get { return _strTicket; }
            set { _strTicket = value; }
        }

        public string Dato
        {
            get { return _strDato; }
            set { _strDato = value; }
        }

        public string Valor
        {
            get { return _strValor; }
            set { _strValor = value; }
        }

        #endregion

        #region Métodos

        public DatoPersistente(string ticket, string dato, string valor): this(DateTime.Now, ticket, dato, valor)
        {
            //DatoPersistente(DateTime.Now, ticket, dato, valor);
        }

        public DatoPersistente(DateTime fecha, string ticket, string dato, string valor)
        {
            this.Fecha = fecha;
            this.Ticket = ticket;
            this.Dato = dato;
            this.Valor = valor;
        }

        public void Persist(SqlTransaction tr)
        {
            string query = "insert into tbIndicadoresBolsa (fecha, ticket, dato, valor) values ('{0}','{1}','{2}','{3}')";

            SqlCommand comm = new SqlCommand(String.Format(query, this.Fecha.ToString(), this.Ticket, this.Dato, this.Valor));
            int result = comm.ExecuteNonQuery();
        }

        public SqlTransaction getTransaction()
        {
            if (tr == null)
            {
                string connString = "abc";
                conn = new SqlConnection(connString);
                conn.Open();
                tr = conn.BeginTransaction();
            }
            
            return tr;
        }

        public void disposeTransaction()
        {
            tr.Commit();
            tr.Connection.Close();
                        
            tr = null;
        }
        
        #endregion

    }
}

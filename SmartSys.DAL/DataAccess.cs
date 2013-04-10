using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SmartSys.DAL
{
    public class DataAccess
    {
        #region Fields

        internal string database = "SmartSys";

        internal const string tblConsumidor = "Consumidor";
        internal const string tblConsumidorProduto = "ConsumidorProduto";
        internal const string tblProdutos = "Produtos";
        internal const string tblTipoAgua = "TipoAgua";
        internal const string tblTipoConsumidor = "TipoConsumidor";
        internal const string tblTipoFiltro = "TipoFiltro";
        internal const string tblTipoMaterial = "TipoMaterial";
        internal const string tblTipoTratador = "TipoTratador";

        internal SqlTransaction transaction; 

        #endregion

        #region Methods

        internal SqlConnection OpenConnection()
        {
            string connString = @"server=.\SQLEXPRESS;uid=sa;pwd=200459;database=" + database + ";Pooling=false";

            SqlConnection conn = new SqlConnection();

            try
            {
                conn.ConnectionString = connString;
                conn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return conn;
        }

        internal void CloseConnection(SqlConnection conn)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        internal DataTable exQuery(string sql)
        {
            SqlConnection conn = OpenConnection();
            SqlCommand command = new SqlCommand();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            try
            {
                command.CommandText = sql;
                command.Connection = conn;
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataTable);

                return dataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(conn);
            }
        }

        internal SqlDataReader exQuery(SqlCommand myCommand)
        {
            SqlDataReader myDataReader = null;

            try
            {
                myCommand.Connection.Open();
                myDataReader = myCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return myDataReader;
        }

        internal void exCommand(string sql)
        {
            SqlConnection conn = OpenConnection();
            SqlCommand command = new SqlCommand();
            transaction = conn.BeginTransaction();

            try
            {
                command.CommandText = sql;
                command.Connection = conn;
                command.Transaction = transaction;
                command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                CloseConnection(conn);
            }
        }

        internal void exCommand(SqlCommand myCommand)
        {
            try
            {
                if (myCommand.Connection.State != ConnectionState.Open)
                {
                    myCommand.Connection.Open();
                    myCommand.Transaction = myCommand.Connection.BeginTransaction();
                }
                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

        #endregion
    }
}

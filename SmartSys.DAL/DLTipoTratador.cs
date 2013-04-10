using SmartSys.MDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SmartSys.DAL
{
    public class DLTipoTratador : DataAccess
    {
        public void InsertUpdate(MLTipoTratador ML)
        {
            try
            {
                dbSmartSysDataContext dbContext = new dbSmartSysDataContext();

                var Tra = (from t in dbContext.TipoTratadors where t.CodTipoTratador == ML.CodTipoTratador select t).SingleOrDefault();

                if (Tra == null)
                {
                    TipoTratador dbTra = new TipoTratador();

                    dbTra.CodTipoTratador = ML.CodTipoTratador;
                    dbTra.TipoTratador1 = ML.TipoTratador;

                    dbContext.TipoTratadors.InsertOnSubmit(dbTra);
                    dbContext.TipoTratadors.Context.SubmitChanges();
                }
                else
                {
                    Tra.TipoTratador1 = ML.TipoTratador;

                    dbContext.TipoTratadors.Context.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MLTipoTratador> List()
        {
            List<MLTipoTratador> list = new List<MLTipoTratador>();

            SqlDataReader objSqlDataReader;

            SqlCommand objSqlCommand = new SqlCommand("USP_TIPOTRATADORES", OpenConnection());
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            if (objSqlCommand.Connection.State != ConnectionState.Open)
                objSqlCommand.Connection.Open();

            objSqlDataReader = objSqlCommand.ExecuteReader();

            while (objSqlDataReader.Read())
            {
                MLTipoTratador ML = new MLTipoTratador();
                ML.FromDataReader(objSqlDataReader);
                list.Add(ML);
            }

            objSqlCommand.Connection.Close();

            return list;
        }

        public void Delete(MLTipoTratador ML)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM ").Append(tblTipoTratador).Append(" WHERE CodTipoTratador = ").Append(ML.CodTipoTratador);
            try
            {
                exCommand(sb.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

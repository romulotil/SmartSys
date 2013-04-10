using SmartSys.MDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SmartSys.DAL
{
    public class DLTipoAgua : DataAccess
    {
        public void InsertUpdate(MLTipoAgua ML)
        {
            try
            {
                dbSmartSysDataContext dbContext = new dbSmartSysDataContext();

                var Ag = (from t in dbContext.TipoAguas where t.CodTipoAgua == ML.CodTipoAgua select t).SingleOrDefault();

                if (Ag == null)
                {
                    TipoAgua dbAg = new TipoAgua();

                    dbAg.CodTipoAgua = ML.CodTipoAgua;
                    dbAg.TipoAgua1 = ML.TipoAgua;

                    dbContext.TipoAguas.InsertOnSubmit(dbAg);
                    dbContext.TipoAguas.Context.SubmitChanges();
                }
                else
                {
                    Ag.TipoAgua1 = ML.TipoAgua;

                    dbContext.TipoAguas.Context.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MLTipoAgua> List()
        {
            List<MLTipoAgua> list = new List<MLTipoAgua>();

            SqlDataReader objSqlDataReader;

            SqlCommand objSqlCommand = new SqlCommand("USP_TIPOAGUA", OpenConnection());
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            if (objSqlCommand.Connection.State != ConnectionState.Open)
                objSqlCommand.Connection.Open();

            objSqlDataReader = objSqlCommand.ExecuteReader();

            while (objSqlDataReader.Read())
            {
                MLTipoAgua ML = new MLTipoAgua();
                ML.FromDataReader(objSqlDataReader);
                list.Add(ML);
            }

            objSqlCommand.Connection.Close();

            return list;
        }

        public void Delete(MLTipoAgua ML)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM ").Append(tblTipoAgua).Append(" WHERE CodTipoAgua = ").Append(ML.CodTipoAgua);
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

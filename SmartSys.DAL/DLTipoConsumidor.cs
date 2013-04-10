using SmartSys.MDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SmartSys.DAL
{
    public class DLTipoConsumidor : DataAccess
    {
        public void InsertUpdate(MLTipoConsumidor ML)
        {
            try
            {
                dbSmartSysDataContext dbContext = new dbSmartSysDataContext();

                var Con = (from t in dbContext.TipoConsumidors where t.CodTipoConsumidor == ML.CodTipoConsumidor select t).SingleOrDefault();

                if (Con == null)
                {
                    TipoConsumidor dbCon = new TipoConsumidor();

                    dbCon.CodTipoConsumidor = ML.CodTipoConsumidor;
                    dbCon.TipoConsumidor1 = ML.TipoConsumidor;

                    dbContext.TipoConsumidors.InsertOnSubmit(dbCon);
                    dbContext.TipoConsumidors.Context.SubmitChanges();
                }
                else
                {
                    Con.TipoConsumidor1 = ML.TipoConsumidor;

                    dbContext.TipoConsumidors.Context.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MLTipoConsumidor> List()
        {
            List<MLTipoConsumidor> list = new List<MLTipoConsumidor>();

            SqlDataReader objSqlDataReader;

            SqlCommand objSqlCommand = new SqlCommand("USP_TIPOCONSUMIDOR", OpenConnection());
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            if (objSqlCommand.Connection.State != ConnectionState.Open)
                objSqlCommand.Connection.Open();

            objSqlDataReader = objSqlCommand.ExecuteReader();

            while (objSqlDataReader.Read())
            {
                MLTipoConsumidor ML = new MLTipoConsumidor();
                ML.FromDataReader(objSqlDataReader);
                list.Add(ML);
            }

            objSqlCommand.Connection.Close();

            return list;
        }

        public void Delete(MLTipoConsumidor ML)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM ").Append(tblTipoConsumidor).Append(" WHERE CodTipoConsumidor = ").Append(ML.CodTipoConsumidor);
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

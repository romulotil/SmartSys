using SmartSys.MDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SmartSys.DAL
{
    public class DLTipoFiltro : DataAccess
    {
        public void InsertUpdate(MLTipoFiltro ML)
        {
            try
            {
                dbSmartSysDataContext dbContext = new dbSmartSysDataContext();

                var Fil = (from t in dbContext.TipoFiltros where t.CodTipoFiltro == ML.CodTipoFiltro select t).SingleOrDefault();

                if (Fil == null)
                {
                    TipoFiltro dbFil = new TipoFiltro();

                    dbFil.CodTipoFiltro = ML.CodTipoFiltro;
                    dbFil.TipoFiltro1 = ML.TipoFiltro;

                    dbContext.TipoFiltros.InsertOnSubmit(dbFil);
                    dbContext.TipoFiltros.Context.SubmitChanges();
                }
                else
                {
                    Fil.TipoFiltro1 = ML.TipoFiltro;

                    dbContext.TipoFiltros.Context.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MLTipoFiltro> List()
        {
            List<MLTipoFiltro> list = new List<MLTipoFiltro>();

            SqlDataReader objSqlDataReader;

            SqlCommand objSqlCommand = new SqlCommand("USP_TIPOFILTRO", OpenConnection());
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            if (objSqlCommand.Connection.State != ConnectionState.Open)
                objSqlCommand.Connection.Open();

            objSqlDataReader = objSqlCommand.ExecuteReader();

            while (objSqlDataReader.Read())
            {
                MLTipoFiltro ML = new MLTipoFiltro();
                ML.FromDataReader(objSqlDataReader);
                list.Add(ML);
            }

            objSqlCommand.Connection.Close();

            return list;
        }

        public void Delete(MLTipoFiltro ML)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM ").Append(tblTipoFiltro).Append(" WHERE CodTipoFiltro = ").Append(ML.CodTipoFiltro);
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

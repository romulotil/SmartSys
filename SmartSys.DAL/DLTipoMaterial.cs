using SmartSys.MDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SmartSys.DAL
{
    public class DLTipoMaterial : DataAccess
    {
        public void InsertUpdate(MLTipoMaterial ML)
        {
            try
            {
                dbSmartSysDataContext dbContext = new dbSmartSysDataContext();

                var Mat = (from t in dbContext.TipoMaterials where t.CodTipoMaterial == ML.CodTipoMaterial select t).SingleOrDefault();

                if (Mat == null)
                {
                    TipoMaterial dbMat = new TipoMaterial();

                    dbMat.CodTipoMaterial = ML.CodTipoMaterial;
                    dbMat.TipoMaterial1 = ML.TipoMaterial;

                    dbContext.TipoMaterials.InsertOnSubmit(dbMat);
                    dbContext.TipoMaterials.Context.SubmitChanges();
                }
                else
                {
                    Mat.TipoMaterial1 = ML.TipoMaterial;

                    dbContext.TipoMaterials.Context.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MLTipoMaterial> List()
        {
            List<MLTipoMaterial> list = new List<MLTipoMaterial>();

            SqlDataReader objSqlDataReader;

            SqlCommand objSqlCommand = new SqlCommand("USP_TIPOMATERIAL", OpenConnection());
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            if (objSqlCommand.Connection.State != ConnectionState.Open)
                objSqlCommand.Connection.Open();

            objSqlDataReader = objSqlCommand.ExecuteReader();

            while (objSqlDataReader.Read())
            {
                MLTipoMaterial ML = new MLTipoMaterial();
                ML.FromDataReader(objSqlDataReader);
                list.Add(ML);
            }

            objSqlCommand.Connection.Close();

            return list;
        }

        public void Delete(MLTipoMaterial ML)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM ").Append(tblTipoMaterial).Append(" WHERE CodTipoMaterial = ").Append(ML.CodTipoMaterial);
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

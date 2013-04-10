using SmartSys.MDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SmartSys.DAL
{
    public class DLConsumidorProduto : DataAccess
    {
        public void InsertUpdate(MLConsumidorProduto ML)
        {
            try
            {
                dbSmartSysDataContext dbContext = new dbSmartSysDataContext();

                var Ag = (from t in dbContext.ConsumidorProdutos where t.CodConsumidorProduto == ML.CodConsumidorProduto select t).SingleOrDefault();

                if (Ag == null)
                {
                    ConsumidorProduto dbAg = new ConsumidorProduto();

                    dbAg.CodConsumidorProduto = ML.CodConsumidorProduto;
                    dbAg.CodConsumidor = ML.CodConsumidor;
                    dbAg.CodProduto = ML.CodProduto;

                    dbContext.ConsumidorProdutos.InsertOnSubmit(dbAg);
                    dbContext.ConsumidorProdutos.Context.SubmitChanges();
                }
                else
                {
                    Ag.CodConsumidor = ML.CodConsumidor;
                    Ag.CodProduto = ML.CodProduto;

                    dbContext.ConsumidorProdutos.Context.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MLConsumidorProduto> List()
        {
            List<MLConsumidorProduto> list = new List<MLConsumidorProduto>();

            SqlDataReader objSqlDataReader;

            SqlCommand objSqlCommand = new SqlCommand("USP_CONSUMIDORPRODUTO", OpenConnection());
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            if (objSqlCommand.Connection.State != ConnectionState.Open)
                objSqlCommand.Connection.Open();

            objSqlDataReader = objSqlCommand.ExecuteReader();

            while (objSqlDataReader.Read())
            {
                MLConsumidorProduto ML = new MLConsumidorProduto();
                ML.FromDataReader(objSqlDataReader);
                list.Add(ML);
            }

            objSqlCommand.Connection.Close();

            return list;
        }

        public void Delete(MLConsumidorProduto ML)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM ").Append(tblConsumidorProduto).Append(" WHERE CodConsumidorProduto = ").Append(ML.CodConsumidorProduto);
            try
            {
                exCommand(sb.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ClearExisting(int codConsumidor)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM ").Append(tblConsumidorProduto).Append(" WHERE CodConsumidor = ").Append(codConsumidor);
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

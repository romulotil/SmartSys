using SmartSys.MDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SmartSys.DAL
{
    public class DLProduto : DataAccess
    {
        public void InsertUpdate(MLProduto ML)
        {
            try
            {
                dbSmartSysDataContext dbContext = new dbSmartSysDataContext();

                var Pro = (from t in dbContext.Produtos where t.CodProduto == ML.CodProduto select t).SingleOrDefault();

                if (Pro == null)
                {
                    Produto dbPro = new Produto();

                    dbPro.CodProduto = ML.CodProduto;
                    dbPro.Produto1 = ML.Produto;

                    dbContext.Produtos.InsertOnSubmit(dbPro);
                    dbContext.Produtos.Context.SubmitChanges();
                }
                else
                {
                    Pro.Produto1 = ML.Produto;

                    dbContext.Produtos.Context.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MLProduto> List()
        {
            List<MLProduto> list = new List<MLProduto>();

            SqlDataReader objSqlDataReader;

            SqlCommand objSqlCommand = new SqlCommand("USP_PRODUTOS", OpenConnection());
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            if (objSqlCommand.Connection.State != ConnectionState.Open)
                objSqlCommand.Connection.Open();

            objSqlDataReader = objSqlCommand.ExecuteReader();

            while (objSqlDataReader.Read())
            {
                MLProduto ML = new MLProduto();
                ML.FromDataReader(objSqlDataReader);
                list.Add(ML);
            }

            objSqlCommand.Connection.Close();

            return list;
        }

        public void Delete(MLProduto ML)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM ").Append(tblProdutos).Append(" WHERE CodProduto = ").Append(ML.CodProduto);
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

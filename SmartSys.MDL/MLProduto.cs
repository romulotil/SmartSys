using System;
using System.Collections.Generic;

namespace SmartSys.MDL
{
    public partial class MLProduto
    {
        public int CodProduto { get; set; }
        public string Produto { get; set; }

        public void FromDataReader(System.Data.SqlClient.SqlDataReader objSqlDataReader)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["CodProduto"])))
            {
                CodProduto = Convert.ToInt32(objSqlDataReader["CodProduto"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["Produto"])))
            {
                Produto = Convert.ToString(objSqlDataReader["Produto"]);
            }
        }
    }
}

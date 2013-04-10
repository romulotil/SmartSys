using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SmartSys.MDL
{
    public partial class MLConsumidorProduto
    {
        public int CodConsumidorProduto { get; set; }
        public int CodConsumidor { get; set; }
        public int CodProduto { get; set; }

        public void FromDataReader(SqlDataReader objSqlDataReader)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["CodConsumidorProduto"])))
            {
                CodConsumidorProduto = Convert.ToInt32(objSqlDataReader["CodConsumidorProduto"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["CodConsumidor"])))
            {
                CodConsumidor = Convert.ToInt32(objSqlDataReader["CodConsumidor"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["CodProduto"])))
            {
                CodProduto = Convert.ToInt32(objSqlDataReader["CodProduto"]);
            }
        }
    }
}

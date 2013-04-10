using System;
using System.Collections.Generic;

namespace SmartSys.MDL
{
    public partial class MLTipoConsumidor
    {
        public int CodTipoConsumidor { get; set; }
        public string TipoConsumidor { get; set; }

        public void FromDataReader(System.Data.SqlClient.SqlDataReader objSqlDataReader)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["CodTipoConsumidor"])))
            {
                CodTipoConsumidor = Convert.ToInt32(objSqlDataReader["CodTipoConsumidor"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["TipoConsumidor"])))
            {
                TipoConsumidor = Convert.ToString(objSqlDataReader["TipoConsumidor"]);
            }
        }
    }
}

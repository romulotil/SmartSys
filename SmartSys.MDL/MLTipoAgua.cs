using System;
using System.Collections.Generic;

namespace SmartSys.MDL
{
    public partial class MLTipoAgua
    {
        public int CodTipoAgua { get; set; }
        public string TipoAgua { get; set; }

        public void FromDataReader(System.Data.SqlClient.SqlDataReader objSqlDataReader)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["CodTipoAgua"])))
            {
                CodTipoAgua = Convert.ToInt32(objSqlDataReader["CodTipoAgua"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["TipoAgua"])))
            {
                TipoAgua = Convert.ToString(objSqlDataReader["TipoAgua"]);
            }
        }
    }
}

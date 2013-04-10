using System;
using System.Collections.Generic;

namespace SmartSys.MDL
{
    public partial class MLTipoMaterial
    {
        public int CodTipoMaterial { get; set; }
        public string TipoMaterial { get; set; }

        public void FromDataReader(System.Data.SqlClient.SqlDataReader objSqlDataReader)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["CodTipoMaterial"])))
            {
                CodTipoMaterial = Convert.ToInt32(objSqlDataReader["CodTipoMaterial"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["TipoMaterial"])))
            {
                TipoMaterial = Convert.ToString(objSqlDataReader["TipoMaterial"]);
            }
        }
    }
}

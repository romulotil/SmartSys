using System;
using System.Collections.Generic;

namespace SmartSys.MDL
{
    public partial class MLTipoTratador
    {
        public int CodTipoTratador { get; set; }
        public string TipoTratador { get; set; }

        public void FromDataReader(System.Data.SqlClient.SqlDataReader objSqlDataReader)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["CodTipoTratador"])))
            {
                CodTipoTratador = Convert.ToInt32(objSqlDataReader["CodTipoTratador"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["TipoTratador"])))
            {
                TipoTratador = Convert.ToString(objSqlDataReader["TipoTratador"]);
            }
        }
    }
}

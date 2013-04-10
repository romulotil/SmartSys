using System;
using System.Collections.Generic;

namespace SmartSys.MDL
{
    public partial class MLTipoFiltro
    {
        public int CodTipoFiltro { get; set; }
        public string TipoFiltro { get; set; }

        public void FromDataReader(System.Data.SqlClient.SqlDataReader objSqlDataReader)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["CodTipoFiltro"])))
            {
                CodTipoFiltro = Convert.ToInt32(objSqlDataReader["CodTipoFiltro"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["TipoFiltro"])))
            {
                TipoFiltro = Convert.ToString(objSqlDataReader["TipoFiltro"]);
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace SmartSys.MDL
{
    public partial class MLConsumidor
    {
        public int CodConsumidor { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public bool News { get; set; }
        public string Observacao { get; set; }
        public int CodTipoConsumidor { get; set; }
        public int CodTipoTratador { get; set; }
        public int CodTipoAgua { get; set; }
        public int CodTipoPiscina { get; set; }
        public int CodTipoSpa { get; set; }
        public int CodFiltroPiscina { get; set; }
        public int CodFiltroSpa { get; set; }
        public string VolPiscina { get; set; }
        public string VolSpa { get; set; }
        public List<MLConsumidorProduto> ListaConsumidorProduto { get; set; }

        public void FromDataReader(System.Data.SqlClient.SqlDataReader objSqlDataReader)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["CodConsumidor"])))
            {
                CodConsumidor = Convert.ToInt32(objSqlDataReader["CodConsumidor"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["Nome"])))
            {
                Nome = Convert.ToString(objSqlDataReader["Nome"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["Endereco"])))
            {
                Endereco = Convert.ToString(objSqlDataReader["Endereco"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["Numero"])))
            {
                Numero = Convert.ToInt32(objSqlDataReader["Numero"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["Complemento"])))
            {
                Complemento = Convert.ToString(objSqlDataReader["Complemento"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["Bairro"])))
            {
                Bairro = Convert.ToString(objSqlDataReader["Bairro"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["Cidade"])))
            {
                Cidade = Convert.ToString(objSqlDataReader["Cidade"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["UF"])))
            {
                UF = Convert.ToString(objSqlDataReader["UF"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["CEP"])))
            {
                CEP = Convert.ToString(objSqlDataReader["CEP"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["Telefone"])))
            {
                Telefone = Convert.ToString(objSqlDataReader["Telefone"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["Celular"])))
            {
                Celular = Convert.ToString(objSqlDataReader["Celular"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["Email"])))
            {
                Email = Convert.ToString(objSqlDataReader["Email"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["News"])))
            {
                News = Convert.ToBoolean(objSqlDataReader["News"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["Observacao"])))
            {
                Observacao = Convert.ToString(objSqlDataReader["Observacao"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["VolPiscina"])))
            {
                VolPiscina = Convert.ToString(objSqlDataReader["VolPiscina"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["VolSpa"])))
            {
                VolSpa = Convert.ToString(objSqlDataReader["VolSpa"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["CodTipoConsumidor"])))
            {
                CodTipoConsumidor = Convert.ToInt32(objSqlDataReader["CodTipoConsumidor"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["CodTipoTratador"])))
            {
                CodTipoTratador = Convert.ToInt32(objSqlDataReader["CodTipoTratador"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["CodTipoAgua"])))
            {
                CodTipoAgua = Convert.ToInt32(objSqlDataReader["CodTipoAgua"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["CodTipoPiscina"])))
            {
                CodTipoPiscina = Convert.ToInt32(objSqlDataReader["CodTipoPiscina"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["CodTipoSpa"])))
            {
                CodTipoSpa = Convert.ToInt32(objSqlDataReader["CodTipoSpa"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["CodFiltroPiscina"])))
            {
                CodFiltroPiscina = Convert.ToInt32(objSqlDataReader["CodFiltroPiscina"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(objSqlDataReader["CodFiltroSpa"])))
            {
                CodFiltroSpa = Convert.ToInt32(objSqlDataReader["CodFiltroSpa"]);
            }
        }

        public MLConsumidor()
        {
            ListaConsumidorProduto = new List<MLConsumidorProduto>();
        }
    }
}

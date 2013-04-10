using SmartSys.MDL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SmartSys.DAL
{
    public class DLConsumidor : DataAccess
    {
        #region Methods

        public void InsertUpdateConsumidor(MLConsumidor obj)
        {
            dbSmartSysDataContext dbContext = new dbSmartSysDataContext();

            var Con = (from c in dbContext.Consumidors where c.CodConsumidor == obj.CodConsumidor select c).SingleOrDefault();

            if (Con == null)
            {
                try
                {
                    Consumidor dbCon = new Consumidor();

                    dbCon.Bairro = obj.Bairro;
                    dbCon.Celular = obj.Celular;
                    dbCon.CEP = obj.CEP;
                    dbCon.Cidade = obj.Cidade;
                    dbCon.CodConsumidor = obj.CodConsumidor;
                    dbCon.CodFiltroPiscina = obj.CodFiltroPiscina;
                    dbCon.CodFiltroSpa = obj.CodFiltroSpa;
                    dbCon.CodTipoAgua = obj.CodTipoAgua;
                    dbCon.CodTipoConsumidor = obj.CodTipoConsumidor;
                    dbCon.CodTipoPiscina = obj.CodTipoPiscina;
                    dbCon.CodTipoSpa = obj.CodTipoSpa;
                    dbCon.CodTipoTratador = obj.CodTipoTratador;
                    dbCon.Complemento = obj.Complemento;
                    dbCon.Email = obj.Email;
                    dbCon.Endereco = obj.Endereco;
                    dbCon.News = obj.News;
                    dbCon.Nome = obj.Nome;
                    dbCon.Numero = obj.Numero;
                    dbCon.Observacao = obj.Observacao;
                    dbCon.Telefone = obj.Telefone;
                    dbCon.UF = obj.UF;
                    dbCon.VolPiscina = obj.VolPiscina;
                    dbCon.VolSpa = obj.VolSpa;

                    dbContext.Consumidors.InsertOnSubmit(dbCon);
                    dbContext.Consumidors.Context.SubmitChanges();

                    foreach (MLConsumidorProduto cp in obj.ListaConsumidorProduto)
                    {
                        cp.CodConsumidor = dbContext.Consumidors.Last().CodConsumidor;
                        new DLConsumidorProduto().InsertUpdate(cp);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                try
                {
                    Con.Bairro = obj.Bairro;
                    Con.Celular = obj.Celular;
                    Con.CEP = obj.CEP;
                    Con.Cidade = obj.Cidade;
                    Con.CodFiltroPiscina = obj.CodFiltroPiscina;
                    Con.CodFiltroSpa = obj.CodFiltroSpa;
                    Con.CodTipoAgua = obj.CodTipoAgua;
                    Con.CodTipoConsumidor = obj.CodTipoConsumidor;
                    Con.CodTipoPiscina = obj.CodTipoPiscina;
                    Con.CodTipoSpa = obj.CodTipoSpa;
                    Con.CodTipoTratador = obj.CodTipoTratador;
                    Con.Complemento = obj.Complemento;
                    Con.Email = obj.Email;
                    Con.Endereco = obj.Endereco;
                    Con.News = obj.News;
                    Con.Nome = obj.Nome;
                    Con.Numero = obj.Numero;
                    Con.Observacao = obj.Observacao;
                    Con.Telefone = obj.Telefone;
                    Con.UF = obj.UF;
                    Con.VolPiscina = obj.VolPiscina;
                    Con.VolSpa = obj.VolSpa;

                    dbContext.Consumidors.Context.SubmitChanges();

                    foreach (MLConsumidorProduto cp in obj.ListaConsumidorProduto)
                    {
                        cp.CodConsumidor = obj.CodConsumidor;

                        DLConsumidorProduto DL = new DLConsumidorProduto();
                        DL.ClearExisting(obj.CodConsumidor);
                        DL.InsertUpdate(cp);                        
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void InsertUpdateConsumidorProdutos(MLConsumidorProduto obj)
        {
            dbSmartSysDataContext dbContext = new dbSmartSysDataContext();

            var Con = (from c in dbContext.ConsumidorProdutos where c.CodConsumidorProduto == obj.CodConsumidorProduto select c).SingleOrDefault();

            if (Con == null)
            {
                try
                {
                    ConsumidorProduto dbCon = new ConsumidorProduto();

                    dbCon.CodConsumidorProduto = obj.CodConsumidorProduto;
                    dbCon.CodConsumidor = obj.CodConsumidor;
                    dbCon.CodProduto = obj.CodProduto;

                    dbContext.ConsumidorProdutos.InsertOnSubmit(dbCon);
                    dbContext.ConsumidorProdutos.Context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                try
                {
                    Con.CodConsumidor = obj.CodConsumidor;
                    Con.CodProduto = obj.CodProduto;

                    dbContext.ConsumidorProdutos.Context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        #endregion

        public List<MLConsumidor> ListarConsumidores()
        {
            List<MLConsumidor> list = new List<MLConsumidor>();

            SqlDataReader objSqlDataReader;

            SqlCommand objSqlCommand = new SqlCommand("USP_CONSUMIDOR", OpenConnection());
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            if (objSqlCommand.Connection.State != ConnectionState.Open)
                objSqlCommand.Connection.Open();

            objSqlDataReader = objSqlCommand.ExecuteReader();

            while (objSqlDataReader.Read())
            {
                MLConsumidor ML = new MLConsumidor();
                ML.FromDataReader(objSqlDataReader);
                ML.ListaConsumidorProduto = new DLConsumidorProduto().List().FindAll(c => c.CodConsumidor == ML.CodConsumidor);
                list.Add(ML);
            }

            objSqlCommand.Connection.Close();

            return list;
        }
    }
}

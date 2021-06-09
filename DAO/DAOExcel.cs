using System;
using System.Collections.Generic;
using System.IO;
using ContextDB;
using LeitorJSON;
using Microsoft.Data.SqlClient;
using Models;

namespace DAO {
    public class DAOExcel {
        private ContextoDB _context;
        private string _connectionString;

        private string _nomeScript = "ScriptsTabelas.sql";
        public DAOExcel(ContextoDB context)
        {
            this._context = context;
            this._connectionString = LeitorJson.GetParametersJson().ConnectionString;
        }

        public void ExecuteScriptDatabase(){
            
            string sqlQuery = File.ReadAllText(_nomeScript).Replace("GO","");
            try
            {
                using(SqlConnection con = new SqlConnection(this._connectionString)){
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sqlQuery,con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch(Exception e){
                Console.WriteLine($"Ocorreu um erro ao tentar gerar o script { _nomeScript } Exception : \n \n { e } ");
            }

        }


        public bool SaveDataSexo(List<tblSexo> listaSexo){
            bool retorno = false;
            try
            {
                using(var transaction = _context.Database.BeginTransaction()){
                    _context.tabelaSexo.AddRange(listaSexo);
                    _context.SaveChanges();
                    retorno = true;   
                }

            }
            catch(Exception e){
                Console.WriteLine($"Houve um erro ao tentar cadastrar os itens da planilha Sexo. Segue detalhes abaixo : \n \n ${ e }");
            }
            return retorno;
        }

        public bool SaveDataPais(List<tblPais> listaPais){
            bool retorno = false;
            try
            {
                _context.tabelaPais.AddRange(listaPais);
                _context.SaveChanges();
                retorno = true;
            }
            catch(Exception e){
                Console.WriteLine($"Houve um erro ao tentar cadastrar os itens da planilha Pais. Segue detalhes abaixo : \n \n ${ e }");
            }
            return retorno;
        }

       public bool SaveDataQuestao(List<tblQuestao> listaQuestao){
            bool retorno = false;
            try
            {
                _context.tabelaQuestao.AddRange(listaQuestao);
                _context.SaveChanges();
                retorno = true;
            }
            catch(Exception e){
                Console.WriteLine($"Houve um erro ao tentar cadastrar os itens da planilha Questao. Segue detalhes abaixo : \n \n ${ e }");
            }
            return retorno;
        }

       public bool SaveDataQuestaoOpcao(List<tblQuestaoOpcao> listaQuestaoOpcao){
            bool retorno = false;
            try
            {
                _context.tabelaQuestaoOpcao.AddRange(listaQuestaoOpcao);
                _context.SaveChanges();
                retorno = true;
            }
            catch(Exception e){
                Console.WriteLine($"Houve um erro ao tentar cadastrar os itens da planilha QuestaoOpcao. Segue detalhes abaixo : \n \n ${ e }");
            }
            return retorno;
        }

       public bool SaveDataCliente(List<tblCliente> listaClientes){
            bool retorno = false;
            try
            {
                _context.tabelaCliente.AddRange(listaClientes);
                _context.SaveChanges();
                retorno = true;
            }
            catch(Exception e){
                Console.WriteLine($"Houve um erro ao tentar cadastrar os itens da planilha Cliente. Segue detalhes abaixo : \n \n ${ e }");
            }
            return retorno;
        }

      public bool SaveDataPedidos(List<tblPedido> listaPedido){
            bool retorno = false;
            try
            {
                _context.tabelaPedido.AddRange(listaPedido);
                _context.SaveChanges();
                retorno = true;
            }
            catch(Exception e){
                Console.WriteLine($"Houve um erro ao tentar cadastrar os itens da planilha Cliente. Segue detalhes abaixo : \n \n ${ e }");
            }
            return retorno;
        }

      public bool SaveDataResposta(List<tblResposta> listaResposta){
            bool retorno = false;
            try
            {
                _context.tabelaResposta.AddRange(listaResposta);
                _context.SaveChanges();
                retorno = true;
            }
            catch(Exception e){
                Console.WriteLine($"Houve um erro ao tentar cadastrar os itens da planilha Resposta. Segue detalhes abaixo : \n \n ${ e }");
            }
            return retorno;
        }

      public void IdentityInsertON(string nomeTabela){
          using (SqlConnection con = new SqlConnection(_connectionString)){
              con.Open();
              SqlCommand command = new SqlCommand($"SET IDENTITY_INSERT { nomeTabela } ON",con);
              command.ExecuteNonQuery();
              con.Close();
          }
      }


       public void IdentityInsertOFF(string nomeTabela){
          using (SqlConnection con = new SqlConnection(_connectionString)){
              con.Open();
              SqlCommand command = new SqlCommand($"SET IDENTITY_INSERT { nomeTabela } OFF",con);
              command.ExecuteNonQuery();
              con.Close();
          }
      }


    }
}
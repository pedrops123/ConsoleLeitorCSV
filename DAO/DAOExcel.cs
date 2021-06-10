using System;
using System.Collections.Generic;
using System.IO;
using ContextDB;
using LeitorJSON;
using Microsoft.Data.SqlClient;
using Models;
using Microsoft.EntityFrameworkCore;

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
                    Console.WriteLine("Criação das tabelas finalizado com sucesso !");
                    
                }
            }
            catch(Exception e){
                Console.WriteLine($"Ocorreu um erro ao tentar gerar o script { _nomeScript } Exception : \n \n { e } ");
                Console.WriteLine("Tabelas do sistema ja existente , continuando programação normal.");
            }

        }

        public void DeleteGeralTables(){
            try
            {
                    string querys = " DELETE  FROM tblResposta " + 
                                "DELETE FROM tblPedido " +
                                "DELETE FROM tblCliente "+
                                "DELETE FROM tblQuestaoOpcao "+
                                "DELETE FROM tblQuestao " +
                                "DELETE FROM tblPais "+
                                "DELETE FROM tblSexo ";
                using (SqlConnection con = new SqlConnection(_connectionString)){
                    con.Open();
                    SqlCommand cmd = new SqlCommand(querys,con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Console.WriteLine("Remoçao de dados ja existentes finalizado com sucesso !");
                }
            }
            catch(Exception e){
                Console.WriteLine($"Ocorreu um erro ao tentar zerar os registros das tabelas \n \n Exception:  {e}");
            }
           
        }

        public bool SaveDataSexo(List<tblSexo> listaSexo){
            bool retorno = false;
            try
            {
                using(var transaction = _context.Database.BeginTransaction()){
                    _context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT tblSexo ON");
                    _context.tabelaSexo.AddRange(listaSexo);
                    _context.SaveChanges();
                    _context.Database.CommitTransaction();
                    retorno = true;   
                    _context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT tblSexo OFF");
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
                 using(var transaction = _context.Database.BeginTransaction()){
                        _context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT tblPais ON");
                        _context.tabelaPais.AddRange(listaPais);
                        _context.SaveChanges();
                        _context.Database.CommitTransaction();
                        retorno = true;
                        _context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT tblPais OFF");
                 }
               
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
                 using(var transaction = _context.Database.BeginTransaction()){
                        _context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT tblQuestao ON");
                        _context.tabelaQuestao.AddRange(listaQuestao);
                        _context.SaveChanges();
                        _context.Database.CommitTransaction();
                        retorno = true;
                        _context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT tblQuestao OFF");
                 }
                
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
                using(var transaction = _context.Database.BeginTransaction()){
                    _context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT tblQuestaoOpcao ON");
                    _context.tabelaQuestaoOpcao.AddRange(listaQuestaoOpcao);
                    _context.SaveChanges();
                    _context.Database.CommitTransaction();
                    retorno = true;
                    _context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT tblQuestaoOpcao OFF");
                }
              
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
                 using(var transaction = _context.Database.BeginTransaction()){
                    _context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT tblCliente ON");
                    _context.tabelaCliente.AddRange(listaClientes);
                    _context.SaveChanges();
                    _context.Database.CommitTransaction();
                    retorno = true;
                    _context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT tblCliente OFF");

                 }

 
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
                using(var transaction = _context.Database.BeginTransaction()){
                    _context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT tblPedido ON");
                    _context.tabelaPedido.AddRange(listaPedido);
                    _context.SaveChanges();
                    _context.Database.CommitTransaction();
                    retorno = true;
                    _context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT tblPedido OFF");
                }
     
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
                using(var transaction = _context.Database.BeginTransaction()){
                    _context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT tblResposta ON");
                    _context.tabelaResposta.AddRange(listaResposta);
                    _context.SaveChanges();
                    _context.Database.CommitTransaction();
                    retorno = true;
                    _context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT tblResposta OFF");
                }
            }
            catch(Exception e){
                Console.WriteLine($"Houve um erro ao tentar cadastrar os itens da planilha Resposta. Segue detalhes abaixo : \n \n ${ e }");
            }
            return retorno;
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Models;

namespace LeitorExcel{

    public class GetDataExcel {
        private  static string  diretorioRaiz = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace("\\bin\\Debug\\net5.0","");
        private string diretorioDataExcel = Path.Combine(diretorioRaiz,"DataCSV");
        private static System.Text.Encoding  EncodingText =  System.Text.Encoding.UTF7; 
        public List<tblSexo> GetDataSexo(){
         List<tblSexo> listaSexo = new List<tblSexo>();
        
         int posicaoRow = 0;
            try
            {
                using(StreamReader reader = new StreamReader(Path.Combine(diretorioDataExcel,"tblSexo.csv"),EncodingText)){
                    while(!reader.EndOfStream){
                        var linha = reader.ReadLine();
                        var dadosSeparados = linha.Split(";");
                        if(posicaoRow != 0){
                            listaSexo.Add(new tblSexo(){
                                CodSexo = int.Parse(dadosSeparados[0]),
                                DescSexo = dadosSeparados[1]
                            });
                        }
                       posicaoRow++;
                    }
                }
            }
            catch(Exception e){
                throw e;
            }
          return listaSexo;
        }

        public List<tblPais> GetDataPais(){
        List<tblPais> listaPais = new List<tblPais>();
         int posicaoRow = 0;
            try
            {
                using(StreamReader reader = new StreamReader(Path.Combine(diretorioDataExcel,"tblPais.csv"),EncodingText)){
                    while(!reader.EndOfStream){
                        var linha = reader.ReadLine();
                        var dadosSeparados = linha.Split(";");
                        if(posicaoRow != 0){
                            listaPais.Add(new tblPais(){
                                CodPais = int.Parse(dadosSeparados[0]),
                                DescPais = dadosSeparados[1]
                            });
                        }
                       posicaoRow++;
                    }
                }
            }
            catch(Exception e){
                throw e;
            }
          return listaPais;
        }

        public List<tblQuestao> GetDataQuestao(){
        List<tblQuestao> listaQuestao = new List<tblQuestao>();
         int posicaoRow = 0;
            try
            {
                using(StreamReader reader = new StreamReader(Path.Combine(diretorioDataExcel,"tblQuestao.csv"),EncodingText)){
                    while(!reader.EndOfStream){
                        var linha = reader.ReadLine();
                        var dadosSeparados = linha.Split(";");
                        if(posicaoRow != 0){
                            listaQuestao.Add(new tblQuestao(){
                                CodQuestao = int.Parse(dadosSeparados[0]),
                                DescQuestao = dadosSeparados[1]
                            });
                        }
                       posicaoRow++;
                    }
                }
            }
            catch(Exception e){
                throw e;
            }
          return listaQuestao;
        }

        public List<tblQuestaoOpcao> GetDataQuestaoOpcao(){
        List<tblQuestaoOpcao> listaQuestaoOpcao = new List<tblQuestaoOpcao>();
         int posicaoRow = 0;
            try
            {
                using(StreamReader reader = new StreamReader(Path.Combine(diretorioDataExcel,"tblQuestaoOpcao.csv"),EncodingText)){
                    while(!reader.EndOfStream){
                        var linha = reader.ReadLine();
                        var dadosSeparados = linha.Split(";");
                        if(posicaoRow != 0){
                            listaQuestaoOpcao.Add(new tblQuestaoOpcao(){
                                CodQuestaoOpcao = int.Parse(dadosSeparados[0]),
                                CodQuestao = int.Parse(dadosSeparados[1]),
                                CodOpcao = int.Parse(dadosSeparados[2]),
                                DescOpcao = dadosSeparados[3]
                            });
                        }
                       posicaoRow++;
                    }
                }
            }
            catch(Exception e){
                throw e;
            }
          return listaQuestaoOpcao;
        }

        public List<tblResposta> GetDataResposta(){
         List<tblResposta> listaReposta = new List<tblResposta>();
         int posicaoRow = 0;
            try
            {
                using(StreamReader reader = new StreamReader(Path.Combine(diretorioDataExcel,"tblResposta.csv"),EncodingText)){
                    while(!reader.EndOfStream){
                        var linha = reader.ReadLine();
                        var dadosSeparados = linha.Split(";");
                        if(posicaoRow != 0){
                            listaReposta.Add(new tblResposta(){
                                CodResposta = int.Parse(dadosSeparados[0]),
                                CodCliente = int.Parse(dadosSeparados[1]),
                                CodQuestaoOpcao = int.Parse(dadosSeparados[2])
                            });
                        }
                       posicaoRow++;
                    }
                }
            }
            catch(Exception e){
                throw e;
            }
          return listaReposta;
        }

        public List<tblCliente> GetDataCliente(){
        List<tblCliente> listaCliente = new List<tblCliente>();
         int posicaoRow = 0;
            try
            {
                using(StreamReader reader = new StreamReader(Path.Combine(diretorioDataExcel,"tblCliente.csv"),EncodingText)){
                    while(!reader.EndOfStream){
                        var linha = reader.ReadLine();
                        var dadosSeparados = linha.Split(";");
                        if(posicaoRow != 0){
                            listaCliente.Add(new tblCliente(){
                               CodCliente = int.Parse(dadosSeparados[0]),
                               DescCliente = dadosSeparados[1],
                               CodPais = int.Parse(dadosSeparados[2]),
                               DDD = dadosSeparados[3],
                               Fone = dadosSeparados[4],
                               CodSexo = int.Parse(dadosSeparados[5]),
                               Email = dadosSeparados[6]
                            });
                        }
                       posicaoRow++;
                    }
                }
            }
            catch(Exception e){
                throw e;
            }
          return listaCliente;
        }

        public List<tblPedido> GetDataPedido(){
         List<tblPedido> listaPedido = new List<tblPedido>();
         int posicaoRow = 0;
            try
            {
                using(StreamReader reader = new StreamReader(Path.Combine(diretorioDataExcel,"tblPedido.csv"),EncodingText)){
                    while(!reader.EndOfStream){
                        var linha = reader.ReadLine();
                        var dadosSeparados = linha.Split(";");
                        if(posicaoRow != 0){
                            listaPedido.Add(new tblPedido(){
                               CodPedido = int.Parse(dadosSeparados[0]),
                               CodCliente = int.Parse(dadosSeparados[1]),
                               QtdPedidos = int.Parse(dadosSeparados[2]),
                            });
                        }
                       posicaoRow++;
                    }
                }
            }
            catch(Exception e){
                throw e;
            }
          return listaPedido;
        }


    }

}
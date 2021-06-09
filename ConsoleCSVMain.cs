using System;
using ContextDB;
using DAO;
using LeitorExcel;
using LeitorJSON;
using Models;

namespace ConsoleLeituraCSV
{
    class ConsoleCSVMain
    {
        static void Main(string[] args)
        {
            
                // Inicia contexto Global 
                ContextoDB ctx = new ContextoDB();
                // Inicia DAO 
                DAOExcel dao = new DAOExcel(ctx);
                // Inicia Script para gerar as tabelas
                dao.ExecuteScriptDatabase();

                GetDataExcel getData = new GetDataExcel();

                // Salvar items
                
                // Coleta dados excel Sexo e salva em tabela 
                dao.SaveDataSexo(getData.GetDataSexo());
                // Coleta dados excel Pais e salva em tabela
                dao.SaveDataPais(getData.GetDataPais());
                // Coleta dados excel Questao e salva em tabela
                dao.SaveDataQuestao(getData.GetDataQuestao());
                // Coleta dados excel QuestaoOpcao e salva em tabela
                dao.SaveDataQuestaoOpcao(getData.GetDataQuestaoOpcao());
                // Coleta dados excel Cliente e salva em tabela
                dao.SaveDataCliente(getData.GetDataCliente());
                // Coleta dados excel Pedidos e salva em tabela
                dao.SaveDataPedidos(getData.GetDataPedido());
                // Coleta dados excel Resposta e salva em tabela
                dao.SaveDataResposta(getData.GetDataResposta());

        }
    }
}

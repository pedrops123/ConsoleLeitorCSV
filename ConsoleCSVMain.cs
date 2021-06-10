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
                Console.WriteLine("Gerando script para criar todas as tabelas");
                dao.ExecuteScriptDatabase();

                // Gera delete geral das tabelas caso tenha algum registro ja cadastrado 
                Console.WriteLine("Removendo registros ja existentes !");
                dao.DeleteGeralTables();

                GetDataExcel getData = new GetDataExcel();

                // Salvar items
                
                // Coleta dados excel Sexo e salva em tabela 
                Console.WriteLine("Gravando Dados tabela sexo");
                Console.WriteLine($"Status gravacao sexo :{ dao.SaveDataSexo(getData.GetDataSexo()) }");

                // Coleta dados excel Pais e salva em tabela
                Console.WriteLine("Gravando Dados tabela Pais");
                Console.WriteLine($"Status gravacao Pais :{  dao.SaveDataPais(getData.GetDataPais()) }");

                // Coleta dados excel Questao e salva em tabela
                Console.WriteLine("Gravando Dados tabela Questao");
                Console.WriteLine($"Status gravacao Questao :{  dao.SaveDataQuestao(getData.GetDataQuestao()) }");

                Console.WriteLine("Gravando Dados tabela QuestaoOpcao");
                // Coleta dados excel QuestaoOpcao e salva em tabela
                Console.WriteLine($"Status gravacao QuestaoOpcao :{  dao.SaveDataQuestaoOpcao(getData.GetDataQuestaoOpcao()) }");
                
                Console.WriteLine("Gravando Dados tabela Cliente");
                // Coleta dados excel Cliente e salva em tabela
                Console.WriteLine($"Status gravacao Cliente :{   dao.SaveDataCliente(getData.GetDataCliente()) }");
               
                Console.WriteLine("Gravando Dados tabela Pedido");
                // Coleta dados excel Pedidos e salva em tabela
                Console.WriteLine($"Status gravacao Pedido :{   dao.SaveDataPedidos(getData.GetDataPedido()) }");

                Console.WriteLine("Gravando Dados tabela Resposta");
                // Coleta dados excel Resposta e salva em tabela
                Console.WriteLine($"Status gravacao Resposta :{   dao.SaveDataResposta(getData.GetDataResposta()) }");

                Console.WriteLine("Coleta e gravação dos dados finalizados com sucesso !");
                Console.WriteLine("Segue lista de selects para consultar no Banco: \n \n  SELECT * FROM TesteDB.dbo.tblCliente \n \n SELECT * FROM TesteDB.dbo.tblPais \n \n SELECT * FROM TesteDB.dbo.tblPedido \n \n SELECT * FROM TesteDB.dbo.tblQuestao \n \n SELECT * FROM TesteDB.dbo.tblQuestaoOpcao \n \n SELECT * FROM TesteDB.dbo.tblResposta \n \n SELECT * FROM TesteDB.dbo.tblSexo");
        }
    }
}

############### Console Leitor CSV ####################

Projeto criado em .NET CORE 5.0.7

Bibliotecas utilizadas:

	* Entity Framework Core 
	* Entity Framework Relational
	* Entity Framework Core Sql Server
	* ADO .NET 

Instruções de uso :

	* Primeiro trocar sua connection strings de acordo com seu BD localhost no arquivo "appsettings.json"
	* Executar o console via cmd com "dot net run"
	* Os arquivos de leitura CSV do sistema está presente na pasta "DataCSV" , qualquer arquivo que for deletado dentro dele ira fazer com que a leitura dos
	  arquivos fique incompleta , nao conseguindo o cadastro completo dos dados.
	
	
####################### ATENÇÃO ###############################

	* Não é necessario executar o script "ScriptsTabelas.sql" manualmente , o proprio sistema fará o processo de criação das tabelas de acordo com o script
	sql enviado , porém , ficará ao seu criterio rodar ou não , o sistema funcionara normalmente dos dois modos.
	
	* Certifique que o database "TesteDB" realmente existe na base de dados local antes de rodar o sistema , Caso contrario o sistema nao irá gerar as tabelas automaticamente.
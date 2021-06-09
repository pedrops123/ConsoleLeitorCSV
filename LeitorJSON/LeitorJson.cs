using System;
using System.IO;
using Models;
using System.Text.Json;

namespace LeitorJSON {
    public static class LeitorJson {

        public static ConfigurationParameters GetParametersJson(){
            ConfigurationParameters parameters = new ConfigurationParameters();
            try
            {
              using (StreamReader reader = new StreamReader("appsettings.json")){ 
                    parameters = JsonSerializer.Deserialize<ConfigurationParameters>(reader.ReadToEnd());
               }
            }
             catch(Exception e){
                Console.WriteLine($"Ocorreu um erro ao tentar coletar parametros do arquivo de configuração. \n \n { e }");
            }
            return parameters;

        }


    }

}
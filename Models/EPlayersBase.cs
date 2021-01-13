using System.Collections.Generic;
using System.IO;

namespace EPlayers_AspNetCore.Models
{
    public abstract class EPlayersBase
    {
        public void CreatFolderAndFile(string path){
            
            // Database/Equipe.csv
            string pasta = path.Split("/")[0];

            if(!Directory.Exists(pasta)){
                Directory.CreateDirectory(pasta);
            }
            if(!File.Exists(path)){
                File.Create(path);
            }

        }

        public List<string> ReadAllLinesCSV(string path){

            List<string> linhas = new List<string>();

            // using => abrir e fechar determinado tipo de arquivo ou conexão 
            // StreamReader => Ler as informações do meu CSV

            using (StreamReader file = new StreamReader(path))
            {
                string linha;
                while((linha = file.ReadLine()) != null ){
                    linhas.Add(linha);
                }
            }


            return linhas;
        }

        public void ReWriteCSv(string path, List<string> linhas){
            
            // StreamWriter => escrita de arquivos
            using (StreamWriter ouput = new StreamWriter(path))
            {
                foreach (var item in linhas)
                {
                    ouput.Write(item + "\n");
                }
            }

        }


    }
}
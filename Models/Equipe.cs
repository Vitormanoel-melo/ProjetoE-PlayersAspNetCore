using System.Collections.Generic;
using System.IO;
using EPlayers_AspNetCore.Interfaces;

namespace EPlayers_AspNetCore.Models
{
    public class Equipe : EPlayersBase , IEquipe
    {   
        // ID - Identificador único

        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }

        public const string PATH = "Database/Equipe.csv";

        public Equipe(){
            CreatFolderAndFile(PATH);
        }

        public string Prepare(Equipe e){

            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }


        public void Creat(Equipe e)
        {
            string[] linhas = { Prepare(e) };
            File.AppendAllLines(PATH, linhas);
        }


        public void Delete(int id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            // Removemos a linha que tenha o código a ser alterado
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString() );


            // Reescreve o csv com as alterações
            ReWriteCSv(PATH, linhas);
        }

        public List<Equipe> ReadAll()
        {
            List<Equipe> equipes = new List<Equipe>();

            // ler todas as linhsa do csv
            string[] linhas = File.ReadAllLines(PATH);

            // percorrer as linhas e adicionar na lista de equipes cada objeto equipe
            foreach (var item in linhas)
            {
                string[] linha =  item.Split(";");
                
                Equipe equipe = new Equipe();
                equipe.IdEquipe = int.Parse(linha[0]);
                equipe.Nome     = linha[1];
                equipe.Imagem   = linha[2];

                equipes.Add(equipe);
            }

            return equipes;
        }

        public void Update(Equipe e)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            // Removemos a linha que tenha o código a ser alterado
            linhas.RemoveAll(x => x.Split(";")[0] == e.IdEquipe.ToString() );

            // Adiciona a linha alterada no final do arquivo com mesmo código
            linhas.Add( Prepare(e) );

            // Reescreve o csv com as alterações
            ReWriteCSv(PATH, linhas);

        }   

    }
}
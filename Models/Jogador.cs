using System.Collections.Generic;
using System.IO;
using EPlayers_AspNetCore.Models;
using EPlayersAspNetCoreTeste.Interfaces;

namespace EPlayersAspNetCoreTeste.Models
{
    public class Jogador : EPlayersBase, IJogador
    {
        public int IdJogador { get; set; }
        public string Nome { get; set; }
        public int IdEquipe { get; set; }
        public string Email {get; set;}
        public string Senha { get; set; }
        
        
        public const string PATH = "Database/Jogador.csv";

        public Jogador()
        {
            CreatFolderAndFile(PATH);
        }

        public string PrepareCSV(Jogador j)
        {
            return $"{j.IdJogador};{j.Nome};{j.IdEquipe}";
        }

        public void Create(Jogador j)
        {
            // Adicionar jogador no CSV
            string[] linhas = { PrepareCSV(j) };
            File.AppendAllLines(PATH, linhas);
        }
        

        public List<Jogador> ReadAll()
        {
            // Listar o csv
            List<Jogador> ListaJogador = new List<Jogador>();

            string[] linha = File.ReadAllLines(PATH); 

            foreach (var item in linha)
            {
                string[] atributos = item.Split(";");
                /*
                    [0] = IdJogador
                    [1] = Nome
                    [2] = IdEquipe
                */

                Jogador jogador = new Jogador();
                jogador.IdJogador = int.Parse(atributos[0]);
                jogador.Nome = atributos[1];
                jogador.IdEquipe = int.Parse(atributos[2]);

                ListaJogador.Add(jogador);
            }
        
            return ListaJogador;
        }


        public void Update(Jogador jogador)
        {
            List<string> Lista = ReadAllLinesCSV(PATH);

            Lista.RemoveAll(x => x.Split(";")[0] == jogador.IdJogador.ToString());

            Lista.Add( PrepareCSV(jogador) );

            ReWriteCSv(PATH, Lista);
        }

        public void Delete(int id)
        {
            List<string> Lista = ReadAllLinesCSV(PATH);

            Lista.RemoveAll(x => x.Split(";")[0] == id.ToString());

            ReWriteCSv(PATH, Lista);
        }

    }
}
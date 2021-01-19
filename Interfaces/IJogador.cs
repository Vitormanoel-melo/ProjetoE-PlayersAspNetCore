using System.Collections.Generic;
using EPlayersAspNetCoreTeste.Models;

namespace EPlayersAspNetCoreTeste.Interfaces
{
    public interface IJogador
    {
        void Create(Jogador j);
        List<Jogador> ReadAll();
        void Update(Jogador jogador);
        
        void Delete(int id);

    }
}
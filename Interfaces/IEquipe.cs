using System.Collections.Generic;
using EPlayers_AspNetCore.Models;

namespace EPlayers_AspNetCore.Interfaces
{
    public interface IEquipe
    {
        void Creat(Equipe e);

        List<Equipe> ReadAll();

        void Update(Equipe e);

        void Delete(int id);

    }
}
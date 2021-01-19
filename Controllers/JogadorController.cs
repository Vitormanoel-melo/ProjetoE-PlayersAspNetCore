using System;
using EPlayers_AspNetCore.Models;
using EPlayersAspNetCoreTeste.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPlayersAspNetCoreTeste.Controllers
{
    [Route("Jogador")]
    public class JogadorController : Controller
    {
        Jogador jogadorModel = new Jogador();
        Equipe equipeModel = new Equipe();

        [Route("Listar")]
        public IActionResult Index(){
            
            ViewBag.Equipes = equipeModel.ReadAll();
            ViewBag.Jogadores = jogadorModel.ReadAll();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form){

            Jogador jogador = new Jogador();
            jogador.IdJogador = Int32.Parse(form["IdJogador"]);
            jogador.Nome = form["Nome"];
            jogador.Email = form["Email"];
            jogador.Senha = form["Senha"];

            jogadorModel.Create(jogador);
            ViewBag.Jogadores = jogadorModel.ReadAll();
            
            return LocalRedirect("~/Jogador/Listar");
        }


    }
}
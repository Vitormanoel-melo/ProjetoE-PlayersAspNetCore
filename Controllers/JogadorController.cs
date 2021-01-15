using System;
using EPlayersAspNetCoreTeste.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPlayersAspNetCoreTeste.Controllers
{
    [Route("Jogador")]
    public class JogadorController : Controller
    {
        Jogador jogadorModel = new Jogador();

        [Route("Listar")]
        public IActionResult Index(){

            ViewBag.Jogadores = jogadorModel.ReadAll();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form){

            Jogador jogador = new Jogador();
            jogador.IdJogador = Int32.Parse(form["IdJogador"]);
            jogador.Nome = form["Nome"];
            jogador.IdEquipe = int.Parse(form["IdEquipe"]);

            jogadorModel.Create(jogador);
            ViewBag.Jogadores = jogadorModel.ReadAll();
            
            return LocalRedirect("~/Jogador/Listar");

        }


    }
}
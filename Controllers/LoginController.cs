using System.Collections.Generic;
using EPlayersAspNetCoreTeste.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPlayers_AspNetCore.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        [TempData]
        public string Mensagem { get; set; }
        
        Jogador jogadorModel = new Jogador();

        public IActionResult Index(){


            return View();
        }


        [Route("Logar")]
        public IActionResult Logar(IFormCollection form){

            // lemos todo o arquivo do CSV
            List<string> csv = jogadorModel.ReadAllLinesCSV("Database/Jogador.csv");

            // Verificamos se as informações passadas existe na lista de string
            var logado = 
            csv.Find(
                x => 
                x.Split(";")[2] == form["Email"] && 
                x.Split(";")[3] == form["Senha"]
            );

            // redirecionamos o usuário logado caso encontrado
            if(logado != null)
            {   
                // salvar a informação do nome na sessão

                HttpContext.Session.SetString("_UserName", logado.Split(";")[1]);

                return LocalRedirect("~/");
            }

            Mensagem = "Dados incorretos, tente novamente...";
            return LocalRedirect("~/Login");
        }

        [Route("Logout")]
        public IActionResult Logout(){
            HttpContext.Session.Remove("_UserName");
            return LocalRedirect("~/");
        }

    }
}
using System;
using System.IO;
using EPlayers_AspNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPlayers_AspNetCore.Controllers
{   
    // localhost:5001/Equipe
    [Route("Equipe")]
    public class EquipeController : Controller
    {
        // criamos uma intância equipeModel com a estrutura Equipe
        Equipe equipeModel = new Equipe();

        [Route("Listar")]
        public IActionResult Index(){
            
            /* Listando todas as equipes e enviando para a view através
            da viewbag */
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {   
            // Criamos uma nova instancia de equipe e armazenamos 
            // os dados enviados pelo usuário através do formulário
            // e salvamos no objeto novaEquipe
            Equipe novaEquipe   = new Equipe();
            novaEquipe.IdEquipe = Int32.Parse(form["IdEquipe"]);
            novaEquipe.Nome     = form["Nome"];

            // verificamos se o usuário anexou o arquivo 
            if(form.Files.Count > 0){

                // se sim, armazenamos o arquivo na var file
                var file = form.Files[0];
                var folder = Path.Combine( Directory.GetCurrentDirectory(), "wwwroot/img/Equipes" );

                if(!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                                                //localhost:5001      +                 + Equipes + equipe.jpg
                var path = Path.Combine( Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName );

                using(var stream = new FileStream(path, FileMode.Create))
                {   
                    // salvamos o arquivo no caminho especificado
                    file.CopyTo(stream);
                }

                novaEquipe.Imagem = file.FileName;
            }
            else
            {
                novaEquipe.Imagem = "padrao.jpg";
            }

            // chamamos o método Create para salvar a nova equipe no CSV
            equipeModel.Creat(novaEquipe);            
            ViewBag.Equipes = novaEquipe.ReadAll();

            return LocalRedirect("~/Equipe/Listar");
        }

        [Route("{id}")]
        public IActionResult Excluir(int id){
            equipeModel.Delete(id);

            ViewBag.Equipes = equipeModel.ReadAll();
            return LocalRedirect("~/Equipe/Listar");
        }

    }
}
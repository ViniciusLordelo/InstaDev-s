using System;
using System.IO;
using InstaDev_s.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev_s.Controllers
{
    public class PublicacaoController : Controller
     {
        Publicacao publicacaoModel = new Publicacao();
        [Route ("Feed")]
        public IActionResult NovaPublicacao(IFormCollection form){

        Publicacao NovaPublicacao = new Publicacao();
        NovaPublicacao.Imagem = form["Foto"];
        if (form.Files.Count > 0)
            {

                
                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imgCadastro");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imgCadastro/", folder, file.FileName);

                using(var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                NovaPublicacao.Imagem = file.FileName;
            }else{
               NovaPublicacao.Imagem = "padrao.png";
            }
             if (NovaPublicacao.Imagem != null && NovaPublicacao.Legenda != null )
            {
               
               publicacaoModel.CriarPublicacao(NovaPublicacao);
            }
            // else
            // {
            //     usuarioModel.Mensagem = "Preencha todos os campos!";
            // }

            return LocalRedirect("~/Usuario/Feed");



        }
    }
}
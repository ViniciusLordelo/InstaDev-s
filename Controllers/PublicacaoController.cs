using System;
using System.IO;
using InstaDev_s.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev_s.Controllers
{
    public class PublicacaoController : Controller
     {
        
       

        [Route ("Feed")]
        //  public IActionResult Feed()
        //  {
         
        //      return View();
        //  }
        public IActionResult NovaPublicacao(IFormCollection form){

        Usuario novoUsuario = new Usuario();
        novoUsuario.Foto = form["Foto"];
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

                novoUsuario.Foto = file.FileName;
            }else{
                novoUsuario.Foto = "padrao.png";
            }

            // if(novoUsuario.Nome != null && novoUsuario.Email != null && novoUsuario.Senha != null && novoUsuario.Username != null)
            // {
            //     usuarioModel.CadastrarUsuario(novoUsuario);
            //     ViewBag.Usuario = usuarioModel.MostrarUsuario();
            // }else{
            //     usuarioModel.Mensagem = "Preencha todos os campos!";
            // }

            

            return LocalRedirect("~/Usuario/Feed");



        }
    }
}
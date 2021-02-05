using System;
using System.Collections.Generic;
using InstaDev_s.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev_s.Controllers
{
    public class LoginController : Controller
    {
        Usuario usuarioModel = new Usuario();
        public const string PATH = "Database/Usuarios.csv";
        public IActionResult Logar(IFormCollection form)
        {
            List<string> csv = usuarioModel.ReadAllLinesCSV(PATH);

            var logado =
            csv.Find(
                x =>
                (x.Split(";")[4] == form["Email"] || x.Split(";")[5] == form["Email"]) &&
                x.Split(";")[6] == form["Senha"]
            );


            if (logado != null)
            {
                HttpContext.Session.SetString("IdUsuario", logado.Split(";")[0]);
                // HttpContext.Session.SetString("EmailUsuario", logado.Split(";")[4]);
                ViewBag.logado = HttpContext.Session.GetString("EmailUsuario");
                Console.WriteLine("Estou Logado");
                return LocalRedirect("~/Usuario");
            }

            usuarioModel.Mensagem = "Dados incorretos, tente novamente...";
            return LocalRedirect("~/Feed");
        }

        public List<Usuario> UsuariosLogados(){
            List<Usuario> usuarioslogados = ViewBag.logado;
            
            return usuarioslogados;
        }

        public IActionResult Index()
        {
            return View();
        }

    }

    



}
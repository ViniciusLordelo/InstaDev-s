using System;
using System.Collections.Generic;
using InstaDev_s.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;

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
                x.Split(";")[4] == form["Email"] &&
                x.Split(";")[6] == form["Senha"]
            );

            if (logado != null)
            {

                HttpContext.Session.SetString("IdUsuario", logado.Split(";")[0].ToString());
                return LocalRedirect("~/Usuario/Feed");

            }

            usuarioModel.Mensagem = "Dados incorretos, tente novamente...";

            return LocalRedirect("~/Login");
        }
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("IdUsuario");
            return LocalRedirect("~/Login");
        }


        [Route("Usuario/Perfil")]
        public IActionResult Perfil()
        {
            Usuario usuario = new Usuario();            
            ViewBag.Infos = usuario.MostrarInformacoes(HttpContext.Session.GetString("IdUsuario"));
            return View();
        }


        public IActionResult Index()
        {
            return View();
        }

    }
}
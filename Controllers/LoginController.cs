using System.Collections.Generic;
using InstaDev_s.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev_s.Controllers
{
    public class LoginController : Controller
    {
        Usuario usuarioModel = new Usuario();
        public IActionResult Logar(IFormCollection form)
        {
            List<string> csv = usuarioModel.ReadAllLinesCSV("Database/Usuarios.csv");

            var logado =
            csv.Find(
                x =>
                x.Split(";")[4] == form["Email"] || x.Split(";")[5] == form["Username"] &&
                x.Split(";")[6] == form["Senha"]
            );

            if (logado != null)
            {
                HttpContext.Session.SetString("_UserName", logado.Split(";")[1]);
                ViewBag.logado = HttpContext.Session.GetString("_UserName");
                return LocalRedirect("~/");
            }

            usuarioModel.Mensagem = "Dados incorretos, tente novamente...";
            return LocalRedirect("~/Login");
        }

        public IActionResult Index()
        {
            return View();
        }

    }

    



}
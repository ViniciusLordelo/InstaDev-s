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
                HttpContext.Session.SetString("IdUsuario", logado.Split(";")[0]);
                ViewBag.logado = HttpContext.Session.GetString("IdUsuario");
        
                return LocalRedirect("~/Usuario/Perfil");
                
            }            
            
            usuarioModel.Mensagem = "Dados incorretos, tente novamente...";
            
            return LocalRedirect("~/Login");
        }

        public IActionResult Info()
        {
            ViewBag.logado = HttpContext.Session.GetString("IdLogado");
            Usuario usuario = new Usuario();

            ViewBag.Infos = usuario.MostrarInformacoes(ViewBag.logado);

            return ViewBag.Infos;
        }

        [Route("Usuario/Perfil")]
        public IActionResult Perfil()
        {
            Usuario usuario = new Usuario();
            ViewBag.Infos = usuario.MostrarInformacoes(ViewBag.logado);

            return View();

        }


        public IActionResult Index()
        {
            return View();
        }

    }

    



}
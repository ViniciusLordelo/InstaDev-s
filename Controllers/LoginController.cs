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
            List<string> csv = usuarioModel.ReadAllLinesCSV("Database/Usuarios.csv");

            var logado =
            csv.Find(
                x =>
                x.Split(";")[4] == form["Email"] || x.Split(";")[5] == form["Username"] &&
                x.Split(";")[6] == form["Senha"]
            );

            if (logado != null)
            {
                HttpContext.Session.SetString("IdLogado", logado.Split(";")[0]);
                ViewBag.logado = HttpContext.Session.GetString("IdLogado");
                return LocalRedirect("~/");
            }

            usuarioModel.Mensagem = "Dados incorretos, tente novamente...";
            return LocalRedirect("~/Login");
        }

        public string UsuariosLogados(){

            string IdLogado = ViewBag.logado;

            Usuario u =new Usuario();


            List<string> csv = usuarioModel.ReadAllLinesCSV("Database/Usuarios.csv");

            csv.Find( 
                x =>
                x.Split(";")[0] == IdLogado
            );

            if (IdLogado != null)
            {
                foreach (string item in csv)
                {

                    string[] linha = item.Split(";");

                    u.Foto = linha[1];
                    u.Nome = linha[3];
                    u.Username = linha[5];
                    u.Seguidos = int.Parse(linha [7]);

                }

            }
                    ViewBag.Nome = u.Nome;
                    ViewBag.Username = u.Username;
                    ViewBag.Foto = u.Foto;
                    ViewBag.Seguidos = u.Seguidos;
            
            return ViewBag;

        
        }


        public IActionResult Index()
        {
            return View();
        }

    }

    



}
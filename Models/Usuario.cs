using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;


namespace InstaDev_s.Models
{
    public class Usuario : InstadevBase
    {

        public System.Guid IdUsuario { get; set; }

        public string Nome { get; set; }

        public string Foto { get; set; }

        public DateTime DataNascimento { get; set; }

        public int[] Seguidos { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Senha { get; set; }

        public string Mensagem { get; set; }

        
        

        private const string PATH = "Database/Usuarios.csv";

        public Usuario(){
            CreateFolderAndFile(PATH);
        }
        public string Prepare(Usuario u){
            return $"{u.IdUsuario};{u.Foto};{u.DataNascimento};{u.Nome};{u.Email};{u.Username};{u.Senha};{u.Seguidos}";
        }
        public void CadastrarUsuario(Usuario u){
            string[] linhas = {Prepare(u)};
            File.AppendAllLines(PATH, linhas);
        }
        public List<Usuario> MostrarUsuario(){ //Perfil
            List<Usuario> usuarios = new List<Usuario>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Usuario novoUsuario = new Usuario();
                novoUsuario.IdUsuario = Guid.Parse(linha[0]);
                novoUsuario.Foto = linha[1];
                novoUsuario.DataNascimento = DateTime.Parse(linha[2]);
                novoUsuario.Nome = linha[3];
                novoUsuario.Email = linha[4];
                novoUsuario.Username = linha[5];
                novoUsuario.Senha = linha[6];
                // novoUsuario.Seguidos = Int32[].Parse(linha[7]);

            }
            return usuarios;
        }   

        public void EditarUsuario(Usuario u){
            List<string> linhas  = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[5] == u.Username);
            linhas.RemoveAll(x => x.Split(";")[4] == u.Email);
            linhas.RemoveAll(x => x.Split(";")[3] == u.Nome);
            linhas.RemoveAll(x => x.Split(";")[1] == u.Foto);

            linhas.Add(Prepare(u));

            RewriteCSV(PATH, linhas);

        }

        public void DeletarUsuario(string userName){

            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == userName.ToString());
            
            RewriteCSV(PATH, linhas);


        } 

        public void ListarUsuario(){ //Stories

        }

        // public void Logar(IFormCollection form){
        //     List<string> csv = ReadAllLinesCSV("Database/Usuarios.csv");

        //     var logado =
        //     csv.Find(
        //         x =>
        //         x.Split(";")[4] == form ["Email"] || x.Split(";")[5] == form ["Username"] &&
        //         x.Split(";")[6] == form ["Senha"]
        //     );

        //     if(logado != null)
        //     {
        //         HttpContext.Session.SetString("_UserName", logado.Split(";")[1]);
        //         return LocalRedirect("~/");
        //     }

        //     Mensagem = "Dados incorretos, tente novamente...";
        //     return LocalRedirect("~/Login");




        // }

        public void Seguir(){


            
        }


        
        
        
        
    }
}
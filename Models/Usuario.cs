using System;
using System.Collections.Generic;
using System.IO;
using InstaDev_s.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;


namespace InstaDev_s.Models
{
    public class Usuario : InstadevBase
    {

        public System.Guid IdUsuario { get; set; }

        public Usuario(string nome, string foto, int seguidos, string email, string username, string senha, string mensagem) 
        {
            this.Nome = nome;
                this.Foto = foto;
                this.Seguidos = seguidos;
                this.Email = email;
                this.Username = username;
                this.Senha = senha;
                this.Mensagem = mensagem;
               
        }
                public string Nome { get; set; }

        public string Foto { get; set; }

        public DateTime DataNascimento = new DateTime();

        public int Seguidos { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Senha { get; set; }

        public string Mensagem { get; set; }        
        

        public const string PATH = "Database/Usuarios.csv";

        public Usuario(){
            CreateFolderAndFile(PATH);
        }
        public void CadastrarUsuario(Usuario u){
            string[] linhas = {Prepare(u)};
            File.AppendAllLines(PATH, linhas);
        }
        public string Prepare(Usuario u){
            return $"{u.IdUsuario};{u.Foto};{u.DataNascimento};{u.Nome};{u.Email};{u.Username};{u.Senha};{u.Seguidos}";
        }
        // public List<Usuario> MostrarUsuario(){ //Perfil
        // }   

        public void EditarUsuario(Usuario u){
            List<string> linhas  = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[5] == u.Username);
            linhas.RemoveAll(x => x.Split(";")[4] == u.Email);
            linhas.RemoveAll(x => x.Split(";")[3] == u.Nome);
            // linhas.RemoveAll(x => x.Split(";")[1] == u.Foto);
            linhas.RemoveAll(x => x.Split(";")[0] == u.IdUsuario.ToString());

            linhas.Add(Prepare(u));
            RewriteCSV(PATH, linhas);

        }

        public void DeletarUsuario(int id){

            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == IdUsuario.ToString());
            
            RewriteCSV(PATH, linhas);

        } 

        public List<Usuario> ListarUsuario(){ //Stories

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


        public void Seguir(){


            
        }

        public List<Usuario> MostrarInformacoes(string Id){

            List<Usuario> infoUser = new List<Usuario>();

            //Procurando o user pelo Id
            List<string> csv = ReadAllLinesCSV("Database/Usuarios.csv");

                var info =
                csv.Find(
                    x =>
                    x.Split(";")[0] == Id
                );

                if (info != null)
                {
                    Usuario usuario = new Usuario();
                    usuario.Foto = csv.Find(x => x.Split(";")[1] == Foto);
                    usuario.Nome = csv.Find(x => x.Split(";")[3] == Nome);
                    usuario.Username = csv.Find(x => x.Split(";")[5] == Username);

                    infoUser.Add(usuario);
                    return infoUser;
                }

                return infoUser;

            

        }


    

        
        
        
      
    

        //public void Seguir(){

        //}
    }
}
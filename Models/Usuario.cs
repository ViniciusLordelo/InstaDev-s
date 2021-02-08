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

        public string Nome { get; set; }

        public string Foto { get; set; }

        public DateTime DataNascimento = new DateTime();

        public int Seguidos { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Senha { get; set; }

        public string Mensagem { get; set; }


        public const string PATH = "Database/Usuarios.csv";

        public Usuario()
        {
            CreateFolderAndFile(PATH);
        }
        public void CadastrarUsuario(Usuario u)
        {
            string[] linhas = { Prepare(u) };
            File.AppendAllLines(PATH, linhas);
        }
        public string Prepare(Usuario u)
        {
            return $"{u.IdUsuario};{u.Foto};{u.DataNascimento};{u.Nome};{u.Email};{u.Username};{u.Senha};{u.Seguidos}";
        }

        public void EditarUsuario(Usuario u, string Id)
        {

            List<string> csv = ReadAllLinesCSV(PATH);
            var info =
            csv.Find(
                x =>
                x.Split(";")[0] == Id);
            
            if (info != null)
            {

            csv.RemoveAll(x => x.Split(";")[5] == u.Username);
            csv.RemoveAll(x => x.Split(";")[4] == u.Email);
            csv.RemoveAll(x => x.Split(";")[3] == u.Nome);
            // linhas.RemoveAll(x => x.Split(";")[1] == u.Foto);
            csv.RemoveAll(x => x.Split(";")[0] == u.IdUsuario.ToString());
            csv.Add(Prepare(u));
            RewriteCSV(PATH, csv);
            }
        }

        public void DeletarUsuario(int id)
        {

            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == IdUsuario.ToString());

            RewriteCSV(PATH, linhas);

        }
        

        public List<Usuario> ListarUsuario()
        { //Stories

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

                usuarios.Add(novoUsuario);
            }
            return usuarios;
        }


        public void Seguir()
        {



        }

        public Usuario MostrarInformacoes(string Id)
        {

                Usuario user = new Usuario();

            //Procurando o user pelo Id
            List<string> csv = ReadAllLinesCSV(PATH);

            var info =
            csv.Find(
                x =>
                x.Split(";")[0] == Id 
            );
            
            if (info != null)
            {
                user.Foto = info.Split(";")[1];
                user.Nome = info.Split(";")[3];
                user.Username = info.Split(";")[5];
                user.Email = info.Split(";")[4];

                return user;
            }
            return user;

        }

        //public void Seguir(){

        //}
    }
}
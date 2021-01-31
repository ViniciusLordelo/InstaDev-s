using System;
using System.Collections.Generic;
using System.IO;

namespace InstaDev_s.Models
{
    public class Usuario : InstadevBase
    {
        public Usuario(int idUsuario, string nome, string foto, DateTime dataNascimento, string email, string username, string senha) 
        {
            this.IdUsuario = idUsuario;
                this.Nome = nome;
                this.Foto = foto;
                this.DataNascimento = dataNascimento;
                this.Email = email;
                this.Username = username;
                this.Senha = senha;
               
        }
                public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Foto { get; set; }
        public DateTime DataNascimento { get; set; }
        public int[] Seguidos { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }

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
        public List<Usuario> MostrarUsuario(){
            List<Usuario> usuarios = new List<Usuario>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Usuario novoUsuario = new Usuario();
                novoUsuario.IdUsuario = int.Parse(linha[0]);
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
        public void EditarUsuario(){

        }
        public void DeletarUsuario(){

        } 
        public void ListarUsuario(){

        }
        public void Logar(){

        }
        public void Seguir(){
            
        }
        
        
        
    }
}
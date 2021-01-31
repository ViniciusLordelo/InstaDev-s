using System.Collections.Generic;
using System.IO;

namespace InstaDev_s.Models
{
    public class Publicacao : InstadevBase
    {
        public int IdPublicacao { get; set; }
        public string Imagem { get; set; }
        public string Legenda { get; set; }
        public int Likes { get; set; }

        private const string PATH = "Database/Publicacoes.csv";

        public Publicacao(){
            CreateFolderAndFile(PATH);
        }
        public string Prepare(Publicacao p){
            return $"{p.IdPublicacao};{p.Imagem};{p.Legenda};{p.Likes}";
        }

        
        public void CriarPublicacao(Publicacao p){

            string[] linhas = {Prepare(p)};
            
            File.AppendAllLines(PATH, linhas);

        }

        public List<Publicacao> ListarPublicacao(){

            List<Publicacao> publicacoes = new List<Publicacao>();

            string[] linhas = File.ReadAllLines(PATH);

            foreach (string item in linhas)
            {
                //1;VivoKeyd;img.png
                string[] linha = item.Split(";");

                Publicacao novaPublicacao = new Publicacao();
                novaPublicacao.IdPublicacao = int.Parse(linha[0]);
                novaPublicacao.Imagem= linha[1];
                novaPublicacao.Legenda = linha[2];
                novaPublicacao.Likes = int.Parse(linha[3]);

                publicacoes.Add(novaPublicacao);
            }

            return publicacoes;

        }
        public void EditarPublicação(Publicacao p){

            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == p.Legenda.ToString());
 
            linhas.Add( Prepare(p) );

            RewriteCSV(PATH, linhas);


        }

        //     public void ExcluirPublicação(int id){
            
        //     publicacao.Delete(id);
        //     ViewBag.Equipes = publicacao.ReadAll();
        //     return LocalRedirect("~/Equipe/Listar");


        // }

        public void Curtir(){
            
            
        }
        
    }
}
using System.Collections.Generic;
using System.IO;

namespace InstaDev_s.Models
{
    public class Comentario : InstadevBase
    {
        public int IdComentario { get; set; }
        
        public string Mensagem { get; set; }

        public const string PATH = "Database/Comentario.csv";

        public Comentario()
        {
            CreateFolderAndFile(PATH);
        }

        public void Create(Comentario c)
        {
            string[] linhas = {Prepare(c)};
            
            File.AppendAllLines(PATH, linhas);
        }

        public string Prepare(Comentario c)
        {
            return $"{c.IdComentario};{c.Mensagem}";
        }

        public List<Comentario> ListarComentario(){
        
            List<Comentario> comentarios = new List<Comentario>();

            string[] linhas = File.ReadAllLines(PATH);

            foreach (string item in linhas)
            {
                //1;VivoKeyd;img.png
                string[] linha = item.Split(";");

                Comentario novoComentario = new Comentario();
                
                novoComentario.IdComentario = int.Parse(linha [0]);
                novoComentario.Mensagem = linha [1];

                comentarios.Add(novoComentario);
            }

            return comentarios;

        }


        public void EditarComentario(Comentario c){

            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == c.IdComentario.ToString());
            
            linhas.Add( Prepare(c) );

            RewriteCSV(PATH, linhas);

        }


        public void ExcluirComentario(int IdComentario){

            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == IdComentario.ToString());
            
            RewriteCSV(PATH, linhas);


        }
    }
}
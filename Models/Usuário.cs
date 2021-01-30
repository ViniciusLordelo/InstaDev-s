namespace InstaDev_s.Models
{
    public class Usuário
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Foto { get; set; }
        public Date DataNascimento { get; set; }
        public int[] Seguidos { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }

        public CadastrarUsuario(){

        }
        public MostrarUsuario(){

        }   
        public EditarUsuario(){

        }
        public DeletarUsuario(){

        } 
        public ListarUsuario(){

        }
        public Logar(){

        }
        public Seguir(){
            
        }
        
        
        
    }
}
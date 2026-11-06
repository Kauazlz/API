using BibliotecaAPI.Domains;

namespace BibliotecaAPI.Interfaces
{

   // Mostrar as ações que ele deve tomar com base no Livro 
   // INTERFACE: Listar as operações que qualquer repositório precisa ter
   // Ela diz o que fazer; A Classe repository diz COMO fazer 
    public interface ILivroRepository{

        List<Livro> ListarTodosLivros();
        Livro AdicionarLivro(Livro livro); //objeto do tipo livro, para cadastrar tudo, ele espera um valor do tipo livro

        bool AtualizarLivro(int id, Livro livro); // Recebe um parâmetro do tipo int id, e recebe uma variavel do tipo Livro para cadastrar outros atributos
        bool DeletarLivro(int id); // para deletar preciso apenas do ID 
        
    }
}

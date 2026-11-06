using BibliotecaAPI.Domains;
using BibliotecaAPI.Interfaces;

namespace BibliotecaAPI.Services
{
    public class LivroService
    {
        private readonly ILivroRepository _livroRepository; // variavel de leitura privada do tipo ILivroRepository

        public LivroService(ILivroRepository livroRepository){ // Construtor para que eu consiga acessar os metodos de ILivroRepository
            _livroRepository = livroRepository;
        }

        public List<Livro> Listar(){
            return _livroRepository.ListarTodosLivros();
        }

        public Livro Adicionar(Livro livro){
            return _livroRepository.AdicionarLivro(livro);
        }

        public bool Atualizar(int id, Livro livro) {// espera retorno de um id do tipo inteiro
            return _livroRepository.AtualizarLivro(id, livro);

        }

    }

}

namespace BibliotecaAPI.Domains
{
    // DOMAIN -> representa um livro (cada linha vira um objeto Livro)
    // ENTIDADE Livro
    // Representação de uma tabela no banco de dados
    public class Livro{

        public int IdLivro { get; set; }
        public string Titulo { get; set; } = string.Empty; // caso não seja passado nada o valor será vazio 
        public string Autor { get; set; } = string.Empty; // caso não seja passado nada o valor será vazio 
        public int AnoPublicacao { get; set; }
        public bool LivroAlugado { get; set; }

        
    }
}

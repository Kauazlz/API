using BibliotecaAPI.Domains;
using BibliotecaAPI.Interfaces;
using Microsoft.Data.Sqlite;
using System.Reflection.Metadata.Ecma335;


namespace BibliotecaAPI.Repositories
{
    // Criar lógica dos metodos criado na Interface
    public class LivroRepository : ILivroRepository{ 

        // Criação da conexão do endereço com o banco de dados "biblioteca.db"
        private readonly string _conexao = "Data Source = biblioteca.db";

        public LivroRepository(){ // Construtor, pois a conexão está configurada como privada 
            CriarTabela();
        }

        private void CriarTabela(){

            using var conexao = new SqliteConnection(_conexao);
            conexao.Open();

            var comando = conexao.CreateCommand();
            comando.CommandText = @"
                CREATE TABLE IF NOT EXISTS livros (
                idLivro INTEGER PRIMARY KEY AUTOINCREMENT,
                titulo TEXT NOT NULL,
                autor TEXT NOT NULL,
                ano_publicacao INTEGER NOT NULL, 
                disponivel INTEGER NOT NULL DEFAULT 1)";

            comando.ExecuteNonQuery();

        }
        public Livro AdicionarLivro(Livro livro){
            // Abrir conexão com o Banco 
            using var coon = new SqliteConnection(_conexao);
            coon.Open();

 
            var comando = coon.CreateCommand();
            comando.CommandText = @"INSERT INTO livros (titulo, autor, ano_publicacao, disponivel) VALUES ($nomelivro, $nomeautor, $ano_publicacao, $disponivel)";
            comando.Parameters.AddWithValue("$nomelivro", livro.Titulo);
            comando.Parameters.AddWithValue("$nomeautor", livro.Autor);
            comando.Parameters.AddWithValue("$ano_publicacao", livro.AnoPublicacao);
            comando.Parameters.AddWithValue("$disponivel", livro.LivroAlugado);
            comando.ExecuteNonQuery();

            return livro;
            }

        public bool AtualizarLivro(int id, Livro livro) // capturar o id e atualizar apartir dele
        {
            using var conexao = new SqliteConnection(_conexao);
            conexao.Open();

            var comando = conexao.CreateCommand();

            comando.CommandText = @"
                             UPDATE livros 
                             SET titulo = $titulo, autor = $autor, ano_publicacao = $ano_publicacao, disponivel = $disponivel
                             WHERE idLivro = $id";

            comando.Parameters.AddWithValue("$titulo", livro.Titulo);
            comando.Parameters.AddWithValue("$autor", livro.Autor);
            comando.Parameters.AddWithValue("$ano_publicacao", livro.AnoPublicacao);
            comando.Parameters.AddWithValue("$disponivel", livro.LivroAlugado);
            comando.Parameters.AddWithValue("$id", id);

            int linhasModificadas = comando.ExecuteNonQuery();

            return linhasModificadas > 0; // teste lógico que verifica e retorna se houver modificações 

        }

        public bool DeletarLivro(int id)
        {
            throw new NotImplementedException();
        }

        public List<Livro> ListarTodosLivros(){
            List<Livro> livros = new List<Livro>();

            using var coon = new SqliteConnection(_conexao);
            coon.Open();

            var comando = coon.CreateCommand();
            comando.CommandText = @"SELECT idLivro, titulo, autor, ano_publicacao, disponivel
                                       FROM livros ORDER BY idLivro";

            using var leitor = comando.ExecuteReader();

            while(leitor.Read()){
                livros.Add(Lerlivro(leitor)); // função para adicionar na lista como objeto 
            }
            return livros;
        }

        private Livro Lerlivro(SqliteDataReader leitor){ // função para retornar a lista 

            return new Livro
            {
                IdLivro = leitor.GetInt32(0),
                Titulo = leitor.GetString(0),
                Autor = leitor.GetString(2),
                AnoPublicacao = leitor.GetInt32(3),
                LivroAlugado = leitor.GetBoolean(4),

            };

        }
       

    }
}

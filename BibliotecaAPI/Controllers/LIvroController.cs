using BibliotecaAPI.Domains;
using BibliotecaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;


// Controller - > receber as requisisões HTTP e devolve as repostas (json)
// São as controlles que permitem o fluxo de acesso 

namespace BibliotecaAPI.Controllers{

   [Route("api/[controller]")] // rota 
   [ApiController]
    public class LIvroController : Controller{
        private readonly LivroService _service; // Variavel privada de leitura

        public LIvroController(LivroService service ){ // Construtor 
            _service = service;
        }

        [HttpGet] // HTTP para pegar 
        // Endpoint
        public ActionResult Listar(){

            List<Livro> livros = _service.Listar();
            return Ok(livros);
        }

        [HttpPost] // HTTP para inserir 

        public ActionResult Cadastrar(Livro livro) {

            try{ // tentar adicionar 
                Livro novoLivro = _service.Adicionar(livro);
                return Created("Livro criado com sucesso!", livro);
            } 
   
            catch  (Exception ex) {
                    return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")] // HTTP para atualizar precisamos colocar o id 
        public ActionResult Atualizar(int id, Livro livro){

            try{
                bool atualizado = _service.Atualizar(id,livro);

                if (!atualizado){ // caso o try seja falso ele retornará que o livro não foi encontrado 
                    return NotFound("Livro não foi encontrado");
                }
                
                return Created("Livro atualizado com sucesso", livro); // messagem de autualização 
            } catch (Exception ex){

                return BadRequest(ex.Message);
            }
           
        }
    }
}

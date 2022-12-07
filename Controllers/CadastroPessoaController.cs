using FiapSmartCity.Models;
using FiapSmartCity.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FiapSmartCity.Controllers
{
    public class CadastroPessoaController : Controller
    {

        private readonly CadastroPessoaRepository cadastroPessoaRepository;

        public CadastroPessoaController()
        {
            cadastroPessoaRepository = new CadastroPessoaRepository();
        }

        [Filtros.LogFilter]
        [HttpGet]
        public IActionResult Index()
        {
            var listaPessoas = cadastroPessoaRepository.Listar();
            return View(listaPessoas);
        }

        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View(new CadastroPessoa());
        }

        // Anotação de uso do Verb HTTP Post
        [HttpPost]
        public ActionResult Cadastrar(Models.CadastroPessoa cadastroPessoa)
        {
            if (ModelState.IsValid)
            {
                cadastroPessoaRepository.Inserir(cadastroPessoa);

                @TempData["mensagem"] = "Pessoa cadastrada com sucesso!";
                return RedirectToAction("Index", "CadastroPessoa");

            }
            else
            {
                return View(cadastroPessoa);
            }
        }

        [HttpGet]
        public ActionResult Editar(int Id)
        {
            var cadastroPessoa = cadastroPessoaRepository.Consultar(Id);
            return View(cadastroPessoa);
        }

        [HttpPost]
        public ActionResult Editar(Models.CadastroPessoa cadastroPessoa)
        {

            if (ModelState.IsValid)
            {
                cadastroPessoaRepository.Alterar(cadastroPessoa);

                @TempData["mensagem"] = "Cadastro alterado com sucesso!";
                return RedirectToAction("Index", "CadastroPessoa");
            }
            else
            {
                return View(cadastroPessoa);
            }

        }


        [HttpGet]
        public ActionResult Consultar(int Id)
        {
            var cadastroPessoa = cadastroPessoaRepository.Consultar(Id);
            return View(cadastroPessoa);
        }


        [HttpGet]
        public ActionResult Excluir(int Id)
        {
            cadastroPessoaRepository.Excluir(Id);

            @TempData["mensagem"] = "Cadastro removido com sucesso!";

            return RedirectToAction("Index", "CadastroPessoa");
        }



    }
}

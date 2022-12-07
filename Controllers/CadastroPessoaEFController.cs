using FiapSmartCity.Models;
using FiapSmartCity.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FiapSmartCity.Controllers
{
    public class CadastroPessoaEFController : Controller
    {

        private readonly CadastroPessoaRepositoryEF cadastroPessoaRepositoryEF;

        public CadastroPessoaEFController()
        {
            cadastroPessoaRepositoryEF = new CadastroPessoaRepositoryEF();
        }

        //[Filtros.LogFilter]
        [HttpGet]
        public IActionResult Index()
        {
            var listaPessoas = cadastroPessoaRepositoryEF.Listar();
            return View(listaPessoas);
        }

        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View(new CadastroPessoaEF());
        }

        // Anotação de uso do Verb HTTP Post
        [HttpPost]
        public ActionResult Cadastrar(Models.CadastroPessoaEF cadastroPessoaEF)
        {
            if (ModelState.IsValid)
            {
                cadastroPessoaRepositoryEF.Inserir(cadastroPessoaEF);

                @TempData["mensagem"] = "Pessoa cadastrada com sucesso!";
                return RedirectToAction("Index", "CadastroPessoaEF");

            }
            else
            {
                return View(cadastroPessoaEF);
            }
        }

        [HttpGet]
        public ActionResult Editar(int Id)
        {
            var cadastroPessoa = cadastroPessoaRepositoryEF.Consultar(Id);
            return View(cadastroPessoa);
        }

        [HttpPost]
        public ActionResult Editar(Models.CadastroPessoaEF cadastroPessoaEF)
        {

            if (ModelState.IsValid)
            {
                cadastroPessoaRepositoryEF.Alterar(cadastroPessoaEF);

                @TempData["mensagem"] = "Cadastro alterado com sucesso!";
                return RedirectToAction("Index", "CadastroPessoaEF");
            }
            else
            {
                return View(cadastroPessoaEF);
            }

        }


        [HttpGet]
        public ActionResult Consultar(int Id)
        {
            var cadastroPessoa = cadastroPessoaRepositoryEF.Consultar(Id);
            return View(cadastroPessoa);
        }


        [HttpGet]
        public ActionResult Excluir(int Id)
        {
            cadastroPessoaRepositoryEF.Excluir(Id);

            @TempData["mensagem"] = "Cadastro removido com sucesso!";

            return RedirectToAction("Index", "CadastroPessoaEF");
        }
    }
}

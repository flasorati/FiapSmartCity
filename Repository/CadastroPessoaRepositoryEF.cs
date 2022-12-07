using FiapSmartCity.Models;
using FiapSmartCity.Repository.Context;
using System.Collections.Generic;
using System.Linq;

namespace FiapSmartCity.Repository
{
    public class CadastroPessoaRepositoryEF
    {
        // Propriedade que terá a instância do DataBaseContext
        private readonly DataBaseContext context;

        public CadastroPessoaRepositoryEF()
        {
            // Criando um instância da classe de contexto do EntityFramework
            context = new DataBaseContext();
        }

        public IList<CadastroPessoaEF> Listar()
        {
            return context.CadastroPessoaEF.ToList();
        }

        public IList<CadastroPessoaEF> ListarOrdenadoPorNome()
        {
            var lista =
                context.CadastroPessoaEF.OrderBy(t => t.Nome).ToList<CadastroPessoaEF>();

            return lista;
        }

        public IList<CadastroPessoaEF> ListarOrdenadoPorNomeDescendente()
        {
            var lista =
                context.CadastroPessoaEF.OrderByDescending(t => t.Nome).ToList<CadastroPessoaEF>();

            return lista;
        }
           
        
        public IList<CadastroPessoaEF> ListarTiposParteNome(string parteDescricao)
        {
            // Filtro com Where e Contains
            var lista =
                context.CadastroPessoaEF.Where(t => t.Nome.Contains(parteDescricao))
                        .ToList<CadastroPessoaEF>();

            return lista;
        }

        public CadastroPessoaEF Consultar(int id)
        {
            return context.CadastroPessoaEF.Find(id);
        }


        public void Inserir(CadastroPessoaEF cadastroPessoaEF)
        {
            context.CadastroPessoaEF.Add(cadastroPessoaEF);
            context.SaveChanges();
        }

        public void Alterar(CadastroPessoaEF cadastroPessoaEF)
        {
            context.CadastroPessoaEF.Update(cadastroPessoaEF);
            context.SaveChanges();
        }

        public void Excluir(int id)
        {
            // Criar um tipo produto apenas com o Id
            var pessoa = new CadastroPessoaEF()
            {
                Id = id
            };

            context.CadastroPessoaEF.Remove(pessoa);
            context.SaveChanges();
        }

    }
}
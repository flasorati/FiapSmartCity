using FiapSmartCity.Models;
using FiapSmartCity.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FiapSmartCity.Repository
{
    public class ProdutoRepository
    {
        private readonly DataBaseContext context;

        public ProdutoRepository()
        {
            // Criando um instância da classe de contexto do EntityFramework
            context = new DataBaseContext();
        }

        
        public Produto Consultar(int id)
        {
           
            var prod = context.Produto
                .FirstOrDefault(p => p.IdTipo == id);

            return prod;
        }
    }
}
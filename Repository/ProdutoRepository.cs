
using Microsoft.EntityFrameworkCore;
using ProdutoExempoApiSolid.Data;
using ProdutoExempoApiSolid.Model;
using ProdutoExempoApiSolid.Repository.IRepository;

namespace ProdutoExempoApiSolid.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProdutoDbContext _produtoDbContext;

        public ProdutoRepository(ProdutoDbContext produtoDbContext)
        {
            _produtoDbContext = produtoDbContext;
        }

        public void Atualizar(ProdutoModel entidade)
        {
            var produtoExistente = _produtoDbContext.Produtos.Find(entidade.Id);

            if (produtoExistente != null)
            {
                produtoExistente.Nome = entidade.Nome;
                produtoExistente.Preco = entidade.Preco;

                _produtoDbContext.SaveChanges();
            }
        }

        public List<ProdutoModel> GetAll()
        {
            return _produtoDbContext.Produtos.AsNoTracking().ToList();
        }

        public List<ProdutoModel> BuscarPorNome(string nome)
        {
            return _produtoDbContext.Produtos
                .Where(p => p.Nome.Contains(nome))
                .ToList();
        }

        public void Excluir(int id)
        {
            var produtoExistente = _produtoDbContext.Produtos.Find(id);

            if (produtoExistente != null)
            {
                _produtoDbContext.Produtos.Remove(produtoExistente);
                _produtoDbContext.SaveChanges();
            }
        }

        public ProdutoModel GetById(int id)
        {
            return _produtoDbContext.Produtos.Find(id);
        }

        public void Inserir(ProdutoModel entidade)
        {
            _produtoDbContext.Produtos.Add(entidade);
            _produtoDbContext.SaveChanges();
        }
    }
}

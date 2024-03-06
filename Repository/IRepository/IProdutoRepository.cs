using ProdutoExempoApiSolid.Model;

namespace ProdutoExempoApiSolid.Repository.IRepository
{
    public interface IProdutoRepository : ICrudPattern<ProdutoModel>
    {
        List<ProdutoModel> BuscarPorNome(string nome);
    }
}

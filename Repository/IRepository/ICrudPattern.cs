namespace ProdutoExempoApiSolid.Repository.IRepository
{
    public interface ICrudPattern<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Inserir(T entidade);
        void Atualizar(T entidade);
        void Excluir(int id);
    }
}

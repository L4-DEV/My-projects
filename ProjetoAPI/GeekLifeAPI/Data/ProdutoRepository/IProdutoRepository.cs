using GeekLifeAPI.Models;


namespace GeekLifeAPI.Data.ProdutoRepository
{
    public interface IProdutoRepository
    {
        public void Add(Produto produto);

        Task<IEnumerable<Produto>> GetAllAsync(int skip, int take, string? status, string? ordenacao, string? nome);

       Task<IEnumerable<Produto>>GetByIdAsync (int id);

        public void Update(Produto produto);

        Task DeleteAsync(int id);

       Task<Produto> GetFirstIdAsync (int id);

        public bool NameExist(Produto produto);



    }
}

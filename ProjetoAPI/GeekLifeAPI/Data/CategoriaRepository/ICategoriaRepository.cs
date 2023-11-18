using GeekLifeAPI.Models;



namespace GeekLifeAPI.Data.CategoriaRepository
{
    public interface ICategoriaRepository
    {
       Task<IEnumerable<Categoria>> GetAllAsync(int skip, int take, string? status, string? ordenacao, string? nome); 
       void Add(Categoria categoria);
       void Update(Categoria categoria);
       Task DeleteAsync(int id);
       Task<Categoria>GetFirstIdAsync (int id);
       bool NameExist(Categoria categoria);


      

    }
}

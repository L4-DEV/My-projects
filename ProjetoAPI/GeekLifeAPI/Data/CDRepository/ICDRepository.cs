using GeekLifeAPI.Models;
namespace GeekLifeAPI.Data.CDRepository
{
    public interface ICDRepository
    {
        public void Add(CD cd);

        Task<IEnumerable<CD>> GetAllAsync(int skip, int take, string? status, string? ordenacao, string? nome);

        public void Update (CD cd);

        Task DeleteAsync(int id);
      
        Task<CD> GetFirstIdAsync (int id);

        public void NameExist(CD cd);

        public void AdressExist(CD cd);

    
    }
}

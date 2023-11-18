using GeekLifeAPI.Models;


namespace GeekLifeAPI.Data.SubRepository;

public interface ISubRepository
{
    public void Add(Sub sub);

    Task<IEnumerable<Sub>> GetAllAsync(int skip, int take, string? status, string? ordenacao, string? nome);

   Task<IEnumerable<Sub>>GetByIdAsync(int id);

    public void Update(Sub sub);

   Task DeleteAsync(int id);

   Task<Sub> GetFirstIdAsync(int id);

    public bool NameExist(Sub sub);

   

}

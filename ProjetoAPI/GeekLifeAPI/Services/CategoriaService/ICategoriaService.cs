using GeekLifeAPI.Dtos.CategoriaDtos;
using GeekLifeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeekLifeAPI.Services.CategoriaService
{
    public interface ICategoriaService
    {
      Categoria AddCategoria (CreateCategoriaDto categoriaDto);

      Task<IEnumerable<ReadAllCategoriaDto>>GetAllCategoriasAsync (int skip = 0,int take = 50,string? status = null, string? ordenacao = null,string? nome = null);

      Task<UpdateCategoriaDto>PutCategoriaAsync (int id,UpdateCategoriaDto categoriaDto);

        Task DeleteCategoriaAsync(int id);

       Task<ReadCategoriaDto>GetCategoriaByIdAsync (int id);

        Task<UpdateCategoriaDtoPatch>PatchCategoriaAsync (int id,UpdateCategoriaDtoPatch categoriaDto);
    }
}

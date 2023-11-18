    using GeekLifeAPI.Dtos.ProdutoDtos;
using GeekLifeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeekLifeAPI.Services.ProdutoService
{
    public interface IProdutoService
    {
        Task<Produto> AddProdutoAsync ( CreateProdutoDto produtoDto);

        Task<IEnumerable<ReadAllProdutoDto>> GetAllProdutosAsync (int skip, int take, string? status, string? ordenacao, string? nome);

        Task <ReadProdutoDto> GetProdutoByIdAsync (int id);

        Task <UpdateProdutoDto> PutProdutoAsync(int id,UpdateProdutoDto produtoDto);

        Task<UpdateProdutoDtoPatch> PatchProdutoAsync(int id,UpdateProdutoDtoPatch produtoDto);

        Task DeleteProdutoAsync(int id);
    }
}

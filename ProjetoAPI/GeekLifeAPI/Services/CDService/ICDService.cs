using GeekLifeAPI.Dtos.CCDDtos;
using GeekLifeAPI.Dtos.CDDtos;
using GeekLifeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeekLifeAPI.Services.CDService
{
    public interface ICDService
    {
       Task<CD>AddCDAsync ([FromBody] CreateCDDto CDDto);

        Task<IEnumerable<ReadAllCDDto>> GetAllCDsAsync(int skip, int take, string? status, string? ordenacao, string? nome);

       Task<ReadCDDto>GetCDByIdAsync (int id);

       Task<UpdateCDDto> PutCDAsync(int id, [FromBody] UpdateCDDto cdDto);

        Task<UpdateCDDtoPatch>PatchCDAsync (int id, [FromBody] UpdateCDDtoPatch cdDto);

     
        Task DeleteCDAsync(int id);
    }
}

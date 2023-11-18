using GeekLifeAPI.Dtos.SubDtos;
using GeekLifeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeekLifeAPI.Service.SubService
{
    public interface ISubService
    {
        Task<Sub> AddSubAsync([FromBody] CreateSubDto subDto);

       Task<IEnumerable<ReadAllSubDto>>GetAllSubsAsync ( int skip = 0, int take = 50, string? status = null,string? ordenacao = null, string? nome = null);

        Task<ReadSubDto>GetSubByIdAsync (int id);

        Task<UpdateSubDto> PutSubAsync (int id, [FromBody] UpdateSubDto subDto);

        Task<UpdateSubDtoPatch>PatchSubAsync (int id, [FromBody] UpdateSubDtoPatch subDto);

        public Task DeleteSubAsync(int id);


    }
}

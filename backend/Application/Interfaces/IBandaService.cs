using Application.DTOs.Banda;
using Application.Response;

namespace Application.Interfaces;

public interface IBandaService
{
    Task<Response<List<BandaDto>>> GetAll();
    Task<Response<BandaDto>> GetById(int id);
    Task<Response<BandaDto>> Create(string nome);
    Task<Response<BandaDto>> Update(int id, string nome);
    Task<Response<bool>> Delete(int id);
}
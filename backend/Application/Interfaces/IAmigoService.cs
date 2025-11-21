using Application.DTOs.Amigo;
using Application.Response;

namespace Application.Interfaces;

public interface IAmigoService
{
    Task<Response<List<AmigoDto>>> GetAll();
    Task<Response<AmigoDto>> GetById(int id);
    Task<Response<AmigoDto>> Create(string nome);
    Task<Response<AmigoDto>> Update(int id, string nome);
    Task<Response<bool>> Delete(int id);
}
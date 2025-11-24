using Application.DTOs.Banda;
using Application.Interfaces;
using Application.Response;
using Domain.Entities;
using Infrastructure.Repositories.Interfaces;

namespace Application.Services;

public class BandaService : IBandaService
{
    private readonly IBandaRepository _repository;

    public BandaService(IBandaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response<List<BandaDto>>> GetAll()
    {
        try
        {
            var bandas = await _repository.GetAll();

            if (!bandas.Any())
                return new Response<List<BandaDto>> { Status = false, Mensagem = "Bandas não encontradas." };

            var bandasMapeadas = bandas.Select(a => new BandaDto
            {
                Id = a.Id,
                Nome = a.Nome
            }).ToList();

            return new Response<List<BandaDto>> { Data = bandasMapeadas, Status = true, Mensagem = "Bandas listadas com sucesso." };
        }
        catch (Exception ex)
        {
            return new Response<List<BandaDto>> { Status = false, Mensagem = ex.Message };
        }
    }

    public async Task<Response<BandaDto>> GetById(int id)
    {
        try
        {
            var banda = await _repository.GetById(id);

            if (banda is null)
                return new Response<BandaDto> { Status = false, Mensagem = "Não existe uma banda com esse Id." };

            var bandaMapeada = new BandaDto
            {
                Id = banda.Id,
                Nome = banda.Nome
            };

            return new Response<BandaDto> { Data = bandaMapeada, Status = true, Mensagem = "Banda exibida com sucesso." };
        }
        catch (Exception ex)
        {
            return new Response<BandaDto> { Status = false, Mensagem = ex.Message };
        }
    }

    public async Task<Response<BandaDto>> Create(string nome)
    {
        try
        {
            var banda = new Banda
            {
                Nome = nome
            };

            await _repository.Create(banda);
            await _repository.SaveChangesAsync();

            var bandaDto = new BandaDto
            {
                Id = banda.Id,
                Nome = banda.Nome
            };

            return new Response<BandaDto> { Data = bandaDto, Status = true, Mensagem = "Banda criada com sucesso." };
        }
        catch (Exception ex)
        {
            return new Response<BandaDto> { Status = false, Mensagem = ex.Message };
        }
    }

    public async Task<Response<BandaDto>> Update(int id, string nome)
    {
        try
        {
            var banda = await _repository.GetById(id);

            if (banda is null)
                return new Response<BandaDto> { Status = false, Mensagem = "Não existe uma banda com esse Id." };

            banda.Nome = nome;

            _repository.Update(banda);
            await _repository.SaveChangesAsync();

            var bandaDto = new BandaDto
            {
                Id = banda.Id,
                Nome = banda.Nome
            };

            return new Response<BandaDto> { Data = bandaDto, Status = true, Mensagem = "Banda atualizada com sucesso." };
        }
        catch (Exception ex)
        {
            return new Response<BandaDto> { Status = false, Mensagem = ex.Message };
        }
    }

    public async Task<Response<bool>> Delete(int id)
    {
        try
        {
            var banda = await _repository.GetById(id);

            if (banda is null)
                return new Response<bool> { Status = false, Mensagem = "Não existe uma banda com esse Id." };

            _repository.Delete(banda);
            await _repository.SaveChangesAsync();

            return new Response<bool> { Status = true, Mensagem = "Banda deletada com sucesso" };

        }
        catch (Exception ex)
        {
            return new Response<bool> { Status = false, Mensagem = ex.Message };
        }
    }

}

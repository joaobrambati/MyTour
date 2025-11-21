using Application.DTOs.Amigo;
using Application.Interfaces;
using Application.Response;
using Domain.Entities;
using Infrastructure.Repositories.Interfaces;

namespace Application.Services;

public class AmigoService : IAmigoService
{
    private readonly IAmigoRepository _repository;

    public AmigoService(IAmigoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response<List<AmigoDto>>> GetAll()
    {
        try
        {
            var amigos = await _repository.GetAll();

            if (!amigos.Any())
                return new Response<List<AmigoDto>> { Status = false, Mensagem = "Amigos não encontrados." };

            var amigosMapeados = amigos.Select(a => new AmigoDto
            {
                Id = a.Id,
                Nome = a.Nome
            }).ToList();

            return new Response<List<AmigoDto>> { Data = amigosMapeados, Status = true, Mensagem = "Amigos listados com sucesso." };
        }
        catch (Exception ex)
        {
            return new Response<List<AmigoDto>> { Status = false, Mensagem = ex.Message };
        }
    }

    public async Task<Response<AmigoDto>> GetById(int id)
    {
        try
        {
            var amigo = await _repository.GetById(id);

            if (amigo is null)
                return new Response<AmigoDto> { Status = false, Mensagem = "Não existe um amigo com esse Id." };

            var amigoMapeado = new AmigoDto
            {
                Id = amigo.Id,
                Nome = amigo.Nome
            };

            return new Response<AmigoDto> { Data = amigoMapeado, Status = true, Mensagem = "Amigo exibido com sucesso." };
        }
        catch (Exception ex)
        {
            return new Response<AmigoDto> { Status = false, Mensagem = ex.Message };
        }
    }

    public async Task<Response<AmigoDto>> Create(string nome)
    {
        try
        {
            var amigo = new Amigo
            {
                Nome = nome
            };

            await _repository.Create(amigo);
            await _repository.SaveChangesAsync();

            var amigoDto = new AmigoDto
            {
                Id = amigo.Id,
                Nome = amigo.Nome
            };

            return new Response<AmigoDto> { Data = amigoDto, Status = true, Mensagem = "Amigo criado com sucesso." };
        }
        catch (Exception ex)
        {
            return new Response<AmigoDto> { Status = false, Mensagem = ex.Message };
        }
    }

    public async Task<Response<AmigoDto>> Update(int id,string nome)
    {
        try
        {
            var amigo = await _repository.GetById(id);

            if (amigo is null)
                return new Response<AmigoDto> { Status = false, Mensagem = "Não existe um amigo com esse Id." };

            amigo.Nome = nome;

            _repository.Update(amigo);
            await _repository.SaveChangesAsync();

            var amigoDto = new AmigoDto
            {
                Id = amigo.Id,
                Nome = amigo.Nome
            };

            return new Response<AmigoDto> { Data = amigoDto, Status = true, Mensagem = "Amigo atualizado com sucesso." };
        }
        catch (Exception ex)
        {
            return new Response<AmigoDto> { Status = false, Mensagem = ex.Message };
        }
    }

    public async Task<Response<bool>> Delete(int id)
    {
        try
        {
            var amigo = await _repository.GetById(id);

            if (amigo is null)
                return new Response<bool> { Status = false, Mensagem = "Não existe um amigo com esse Id." };

            _repository.Delete(amigo);
            await _repository.SaveChangesAsync();

            return new Response<bool> { Status = true, Mensagem = "Amigo deletado com sucesso" };

        }
        catch (Exception ex)
        {
            return new Response<bool> { Status = false, Mensagem = ex.Message };
        }
    }

}


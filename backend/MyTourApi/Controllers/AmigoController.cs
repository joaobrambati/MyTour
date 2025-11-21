using Application.DTOs.Amigo;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace MyTourApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AmigoController : ControllerBase
{
    private readonly IAmigoService _service;

    public AmigoController(IAmigoService service)
    {
        _service = service;
    }

    /// <summary>
    /// Retorna todos os amigos
    /// </summary>
    /// <returns></returns>
    [HttpGet("listarAmigos")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAll());
    }

    /// <summary>
    /// Retorna amigo por Id
    /// </summary>
    /// <returns></returns>
    [HttpGet("obterAmigo/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _service.GetById(id));
    }

    /// <summary>
    /// Cria amigo
    /// </summary>
    /// <returns></returns>
    [HttpPost("criaAmigo")]
    public async Task<IActionResult> Create(CreateAmigoDto dto)
    {
        return Ok(await _service.Create(dto.Nome));
    }

    /// <summary>
    /// Atualiza amigo
    /// </summary>
    /// <returns></returns>
    [HttpPut("atualizaAmigo/{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateAmigoDto DTO)
    {
        return Ok(await _service.Update(id, DTO.Nome));
    }

    /// <summary>
    /// Deleta amigo
    /// </summary>
    /// <returns></returns>
    [HttpDelete("deletaAmigo")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _service.Delete(id));
    }

}

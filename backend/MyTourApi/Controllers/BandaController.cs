using Application.DTOs.Amigo;
using Application.DTOs.Banda;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MyTourApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BandaController : ControllerBase
{
    private readonly IBandaService _service;

    public BandaController(IBandaService service)
    {
        _service = service;
    }

    /// <summary>
    /// Retorna todos as bandas
    /// </summary>
    /// <returns></returns>
    [HttpGet("listarBandas")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAll());
    }

    /// <summary>
    /// Retorna banda por Id
    /// </summary>
    /// <returns></returns>
    [HttpGet("obterBanda/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _service.GetById(id));
    }

    /// <summary>
    /// Cria banda
    /// </summary>
    /// <returns></returns>
    [HttpPost("criaBanda")]
    public async Task<IActionResult> Create(CreateBandaDto dto)
    {
        return Ok(await _service.Create(dto.Nome));
    }

    /// <summary>
    /// Atualiza banda
    /// </summary>
    /// <returns></returns>
    [HttpPut("atualizaBanda/{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateBandaDto dto)
    {
        return Ok(await _service.Update(id, dto.Nome));
    }

    /// <summary>
    /// Deleta banda
    /// </summary>
    /// <returns></returns>
    [HttpDelete("deletaBanda")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _service.Delete(id));
    }

}

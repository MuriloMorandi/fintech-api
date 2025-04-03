using Aplicacao.Core.Services;
using Aplicacao.Dominio.DTOs;
using Aplicacao.Dominio.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Aplicacao.API.Controller;

[ApiController]
[Route("api/[controller]")]
public class usuariosController : ControllerBase
{
    private UsuariosService _service;
    
    public usuariosController(UsuariosService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<Usuario>> CreateUsuario(UsuarioDTO usuario)
    {
        
        int newUserId = await _service.CreateUser(usuario);
        
        return CreatedAtAction(nameof(GetByIdUsuario), new { id = newUserId }, usuario);
    }
    
    [HttpPost("{id}")]
    public async Task<ActionResult<Usuario>> UpdateUsuario([FromRoute]int id, UsuarioDTO usuario)
    {

        Usuario user = await _service.UpdateUser(id, usuario);

        return NoContent();
    }
    
    [HttpGet()]
    public async Task<ActionResult<Usuario>> GetAllUsuario(int id)
    {
        var usuario = await _service.FindAll();
        return Ok(usuario);
    }
    
    [HttpGet("buscaId/{id}")]
    public async Task<ActionResult<Usuario>> GetByIdUsuario(int id)
    {
        var usuario = await _service.FindById(id);
        return Ok(usuario);
    }

    [HttpGet("buscaEmail/{email}")]
    public async Task<ActionResult<Usuario>> GetByEmailUsuario(string email)
    {
        var usuario = await _service.FindByEmail(email);
        return Ok(usuario);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
    {
        await _service.Delete(id);
        return Ok();
    }
    
}
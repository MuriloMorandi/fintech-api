using Aplicacao.Dominio.Entities;

namespace Aplicacao.Dominio.DTOs;

public class UsuarioDTO
{
    public int? Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }

    public UsuarioDTO(){}

    public UsuarioDTO(Usuario user)
    {
        this.Id = user.Id;
        this.Nome = user.Nome;
        this.Email = user.Email;
    }
}
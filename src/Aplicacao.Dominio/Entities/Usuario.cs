using Aplicacao.Dominio.DTOs;

namespace Aplicacao.Dominio.Entities;

public class Usuario: BaseEntidade
{
    public string Nome { get; set; }
    
    public string Email { get; set; }
    public string Senha { get; set; }
    public DateTime DataCriacao { get; set; }

    public Usuario()
    {
    }

    public static Usuario FromDTO(UsuarioDTO usuarioDTO)
    {
        return new Usuario
        {
            Nome = usuarioDTO.Nome,
            Email = usuarioDTO.Email,
            Senha = usuarioDTO.Senha,
            DataCriacao = DateTime.UtcNow,
        };
    }
}
using Aplicacao.Dominio.DTOs;
using Aplicacao.Dominio.Entities;
using Aplicacao.Dominio.Intefaces;

namespace Aplicacao.Core.Services;

public class UsuariosService
{
    private readonly IUsuarioRepository _repository;

    public UsuariosService(IUsuarioRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<int> CreateUser(UsuarioDTO dto)
    {
        if (dto.Nome.Length < 3)
            throw new Exception("O nome precisa ter pelo menos 3 caracteres.");

        if (await _repository.GetByEmail(dto.Email) != null)
        {
            throw new Exception("Email ja cadastrado.");
        }

        var usuario = Usuario.FromDTO(dto);
        int idNewUsuario = await _repository.Create(usuario);
        
        return idNewUsuario;
    }
    
    public async Task<Usuario> UpdateUser(int id, UsuarioDTO dto)
    {
        if (dto.Nome.Length < 3)
            throw new Exception("O nome precisa ter pelo menos 3 caracteres.");
        
        if (await _repository.GetByEmail(dto.Email, id) != null)
        {
            throw new Exception("Email ja cadastrado.");
        }
        
        var funcionario = Usuario.FromDTO(dto);
        await _repository.Update(id, funcionario);
        return funcionario;
    }
    
    public async Task<UsuarioDTO> FindById(int id)
    {
        Usuario? userDb =  await _repository.GetById(id);

        if (userDb == null)
        {
            throw new Exception("Not found");
        }
        
        return new UsuarioDTO(userDb);
    }

    public async Task<UsuarioDTO> FindByEmail(string email)
    {
        Usuario? userDb =  await _repository.GetByEmail(email);

        if (userDb == null)
        {
            throw new Exception("Not found");
        }
        
        return new UsuarioDTO(userDb);
    }
    
    public async Task<IEnumerable<UsuarioDTO>> FindAll()
    {
        List<UsuarioDTO> ret = new List<UsuarioDTO>();
        var usersDB = await _repository.ReadAll();
        foreach (var usuario in usersDB)
        {
            ret.Add(new UsuarioDTO(usuario));
        }
        
        return ret;
    }

    public async Task Delete(int id)
    {
        await _repository.Remove(id);
    }
}
namespace Aplicacao.Dominio.Entities;
using System.ComponentModel.DataAnnotations;

public class Categorias
{
    
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public DateTime CriadoEm { get; set; } = new DateTime();
}
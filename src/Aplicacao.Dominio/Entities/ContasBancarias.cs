namespace Aplicacao.Dominio.Entities;

public class ContasBancarias: BaseEntidade
{
    public int IdUsuario { get; set; }
    public string Nome { get; set; }
    public float Saldo { get; set; }
    public DateTime CriadoEm { get; set; }
}
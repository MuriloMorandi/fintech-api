using Aplicacao.Dominio.Enums;

namespace Aplicacao.Dominio.Entities;

public class TransacoesBancarias: BaseEntidade
{
    public int IdContaBancaria{get;set;}
    public int IdCategoria{get;set;}
    public TransacoesBancariasTiposEnum Tipo{get;set;}
    public float Valor{get;set;}
    public string descricao{get;set;}
    public DateOnly Data{get;set;}
    public float SaldoAtual{get;set;}
}

using Microsoft.EntityFrameworkCore;

namespace APIProva.Models;

[Keyless]
public class Funcionario
{

    public Funcionario(string nome, string cpf){
        Nome = nome;
        Cpf = cpf;
        FuncionarioId += 1;
    }

    public string? Nome { get; set; }

    public string? Cpf { get; set; }

    public int FuncionarioId { get; set; }


}

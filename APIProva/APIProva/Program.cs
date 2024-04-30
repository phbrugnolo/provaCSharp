using System.ComponentModel.DataAnnotations;
using APIProva.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();
var app = builder.Build();


List<Folha> Folhas = new List<Folha>();
List<Funcionario> Funcionarios = new List<Funcionario>();



app.MapPost("/api/funcionario/cadastrar/", ([FromBody] Funcionario funcionario, [FromServices] AppDbContext context) =>
{
    Funcionario? funcBuscado = context.Funcionarios.FirstOrDefault(x => x.Nome == funcionario.Nome);

    if (funcBuscado is null)
    {
        context.Funcionarios.Add(funcionario);
        context.SaveChanges();
        return Results.Created("Funcionario cadastrado com sucesso", funcionario);
    }
    return Results.BadRequest("Já existe um funcionario com este nome");

});

//GET  http://localhost:{porta}/api/produtos
app.MapGet("api/funcionario/listar", ([FromServices] AppDbContext context) =>
{

    if (context.Funcionarios.Any()) return Results.Ok(context.Funcionarios.ToList());
    return Results.NotFound("Funcionario não encontrado");

});

app.MapPost("api/folha/cadastrar" , ([FromBody] Folha folha, [FromServices] AppDbContext context) => {
    Folha? folhaBuscada = context.Folhas.FirstOrDefault(x => x.FolhaId == folha.FolhaId);

    if (folhaBuscada is null)
    {
        context.Folhas.Add(folha);
        context.SaveChanges();
        return Results.Created("Folha cadastrada com sucesso", folha);
    }
    return Results.BadRequest("Já existe uma folha com este nome");

});

app.MapGet("api/folha/listar" , ([FromServices] AppDbContext context) => {

    if (context.Folhas.Any()) return Results.Ok(context.Folhas.ToList());
    return Results.NotFound("Folha não encontrada");
});

app.MapGet("api/folha/buscar/{cpf}/{mes}/{ano}" , ([FromRoute] int cpf, int mes, int ano, [FromServices] AppDbContext context) => {
    
    Folha? folha = context.Folhas.FirstOrDefault(x => x.Ano == ano && x.Mes == mes);


    if (folha is null) return Results.NotFound("Folha não Encotrado");
    return Results.Ok(folha);
});


app.Run();

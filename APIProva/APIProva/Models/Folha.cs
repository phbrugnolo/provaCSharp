using Microsoft.EntityFrameworkCore;

namespace APIProva.Models;


[Keyless]
public class Folha 
{
    public Folha(double valor, int quantidade, int mes, int ano, int funcionarioId)
    {
        Valor = valor;
        Quantidade = quantidade;
        Mes = mes;
        Ano = ano;
        FolhaId += 1;
        Funcionario.FuncionarioId = funcionarioId;
        calcBruto();
        calcIrrf();
        calcInss();
    }

    
    public void calcBruto(){
        Bruto = Valor * Quantidade;
    }

    public void calcIrrf(){
        if(Bruto < 1903.98){
            irrf = 0;
        }else if(Bruto > 1903.99 && Bruto < 2826.65){
            irrf = Bruto * 0.075;
        }else if(Bruto > 2826.66 && Bruto < 3751.05){
            irrf = Bruto * 0.15;
        }else if(Bruto >  3751.06 && Bruto < 4664.68){
            irrf = Bruto * 0.225;
        }else {
            irrf = Bruto * 0.275;
        }
    }

    public void calcInss(){
        if(Bruto < 1693.72){
            inss = Bruto * 0.08;
        }else if(Bruto > 1693.73 && Bruto < 2822.90){
            inss = Bruto * 0.009;
        }else if(Bruto > 2822.91 && Bruto < 5645.80){
            inss = Bruto * 0.11;
        }else {
            inss = 621.03;
        }
    }

    public void calcFgts(){
        fgts = Bruto * 0.08;
    }

    public void calcLiquido(){
        liquido = Bruto - irrf - inss;
    }

    public double Valor { get; set; }

    public int Quantidade { get; set; }

    public int Mes { get; set; }

    public int Ano { get; set; }

    public int FolhaId { get; set; }

    public Funcionario Funcionario { get; set; }

    public double Bruto { get; set; }

    public double irrf { get; set; }

    public double inss { get; set; }

    public double fgts { get; set; }

    public double liquido { get; set; }
  
}

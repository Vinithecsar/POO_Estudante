using System;
using System.Collections.Generic;

class Sistema{
  private static List<Assunto> total_as = new List<Assunto>();
  //fisica, mecanica, 2 ; fisica, termodinamica, 1;
  public static void InserirAs(Assunto novo){
    total_as.Add(novo);
  }
  public static Assunto ProcurarAs(string nome){
    //para usar no atualizar
    foreach(Assunto i in total_as){
      if(i.Nome_a.Equals(nome)){
        return i;
      }
    }
  return null;
  }
  public static List<Assunto> ListarAs(string nome){
    //retornar a lista com todos os assuntos da disciplina
    List<Assunto> mesma_disciplina = new List<Assunto>();
    foreach(Assunto i in total_as){
      if(i.Nome_d.Equals(nome)){
        mesma_disciplina.Add(i);
      }
    }
  return mesma_disciplina;
  }
  public static void AtualizarAs(Assunto novo){
    Assunto atualize = Sistema.ProcurarAs(novo.Nome_a);
    if(atualize!=null){
      atualize.Qtd = novo.Qtd;
    }
  }
public static void ExcluirAs(Assunto novo){
  total_as.Remove(novo);
}
}
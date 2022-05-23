using System;
using System.Collections.Generic;

class Sistema{
  private static int NumDisciplina = 0;
  private static int index;
  private static Disciplina[] total_dis = new Disciplina[5];
  private static List<Assunto> total_as = new List<Assunto>();
  //fisica, mecanica, 2 ; fisica, termodinamica, 1;
  public static void InserirAs(Assunto novo){
    total_as.Add(novo);
  }
  public static Assunto ProcurarAs(string nome){
    //para usar no atualizar e excluir
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
    Assunto remover = Sistema.ProcurarAs(novo.Nome_a);
    total_as.Remove(remover);
  }
  
  public static void InserirDis(Disciplina novo) {
    if (NumDisciplina == total_dis.Length)
      Array.Resize(ref total_dis, total_dis.Length + 1);
    total_dis[NumDisciplina] = novo;
    NumDisciplina++;
  }
  
  public static Disciplina[] ListarDis() {
    Disciplina[] aux = new Disciplina[NumDisciplina];
    Array.Copy(total_dis, aux, NumDisciplina);
    Array.Sort(aux);
    return aux;
  }
  
  public static Disciplina ProcurarDis(string nome) {
    foreach(Disciplina dis in total_dis)
      if (dis != null && dis.Nome_dis == nome) return dis;
    return null;
  }
    
  public static void AtualizarDis(Disciplina novo) {
    Disciplina aux = ProcurarDis(novo.Nome_dis);
    if (aux != null)
      aux.Prio = novo.Prio;
  }
  
  public static void ExcluirDis(Disciplina novo) {
    for (int i = 0; i < NumDisciplina; i++) {
      Disciplina aux1 = total_dis[i];
      if (aux1.Nome_dis == novo.Nome_dis) index = i;
    }
    
    for (int j = index; j < NumDisciplina - 1; j++) {
      total_dis[j] = total_dis[j + 1];
    }
    NumDisciplina--;
  }

}
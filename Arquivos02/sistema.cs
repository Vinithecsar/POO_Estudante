using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class Sistema{
  private static List<Estudante> total_est = new List<Estudante>();
  private static int NumDisciplina = 0;
  private static int index;
  //pedro, física, matemática ; luisa, calculo 1, calculo 2
  private static Disciplina[] total_dis = new Disciplina[5];
  //fisica, mecanica, 2 ; fisica, termodinamica, 1;
  private static List<Assunto> total_as = new List<Assunto>();

  //arquivo para cada lista: estudante, disciplina, assunto
  public static void SalvarArquivo(){
    Arquivos<Disciplina[]> a = new Arquivos<Disciplina[]>();
    a.Salvar("./disciplinas.xml", ListarDis());

    Arquivos<List<Assunto>> b = new Arquivos<List<Assunto>>();
    b.Salvar("./assuntos.xml", total_as);
  }
  public static void AbrirArquivo(){
    Arquivos<Disciplina[]> a = new Arquivos<Disciplina[]>();
    total_dis = a.Abrir("./disciplinas.xml");
    //list vai receber dentro de xml

    Arquivos<List<Assunto>> c = new Arquivos<List<Assunto>>();
    total_as = c.Abrir("./assuntos.xml");
    //[] vai receber dentro de xml
  }

  public static void InserirAs(Assunto novo){
    int id_as=0;
    foreach(Assunto aux in total_as){
      if (aux != null && aux.IdAssunto > id_as) id_as = aux.IdAssunto;
      }
    novo.IdAssunto = id_as + 1;
    total_as.Add(novo);
  }
  public static Assunto ProcurarAs(int id_assunto){
    //para usar no atualizar e excluir
    foreach(Assunto i in total_as){
      if(i.IdAssunto.Equals(id_assunto)){
        return i;
      }
    }
  return null;
  }
  public static List<Assunto> ListarAs(int id_disciplina){
    //retornar a lista com todos os assuntos da disciplina
    List<Assunto> mesma_disciplina = new List<Assunto>();
    foreach(Assunto i in total_as){
      if(i.IdDisciplina.Equals(id_disciplina)){
        mesma_disciplina.Add(i);
      }
    }
  mesma_disciplina.Sort();
  return mesma_disciplina;
  }
  public static void AtualizarAs(Assunto novo){
    Assunto atualize = Sistema.ProcurarAs(novo.IdAssunto);
    if(atualize!=null){
      atualize.Qtd = novo.Qtd;
      atualize.Nome_a = novo.Nome_a;
    }
  }
  public static void ExcluirAs(Assunto novo){
    Assunto remover = Sistema.ProcurarAs(novo.IdAssunto);
    total_as.Remove(remover);
  }
  
  public static void InserirDis(Disciplina novo) {
    int id = 0;
    if (NumDisciplina == total_dis.Length)
      Array.Resize(ref total_dis, total_dis.Length + 1);
    
    foreach(Disciplina aux in total_dis) {
      if (aux != null && aux.IdDis > id) id = aux.IdDis; //erro está aqui
    }
    novo.IdDis = id + 1;
    total_dis[NumDisciplina] = novo;
    NumDisciplina++;
  }
  
  public static Disciplina[] ListarDis() {
    Disciplina[] aux = new Disciplina[NumDisciplina];
    Array.Copy(total_dis, aux, NumDisciplina);
    Array.Sort(aux);
    return aux;
  }
  
  public static Disciplina ProcurarDis(int id, int id2) {
    foreach(Disciplina dis in total_dis)
      if (dis != null && dis.IdDis==id2 && dis.Cadastro==id) return dis;
    return null;
  }
    
  public static void AtualizarDis(Disciplina novo) {
    Disciplina aux = ProcurarDis(novo.Cadastro, novo.IdDis);
    if (aux != null) {
      aux.Prio = novo.Prio;
      if (novo.Nome_dis != "") {
        aux.Nome_dis = novo.Nome_dis;
      }
    }
  }
  
  public static void ExcluirDis(Disciplina novo) {
    for (int i = 0; i < NumDisciplina; i++) {
      Disciplina aux1 = total_dis[i];
      if (aux1.IdDis == novo.IdDis && aux1.Cadastro == novo.Cadastro) index = i;
    }
    
    for (int j = index; j < NumDisciplina - 1; j++) {
      total_dis[j] = total_dis[j + 1];
    }
    NumDisciplina--;
  }

  public static void InserirEstudante(Estudante novo) {
    total_est.Add(novo);
  }

  public static List<Estudante> ListarEstudante() {
    total_est.Sort();
    return total_est;
  }

  public static Estudante ProcurarEstudante(int cadas) {
    foreach(Estudante i in total_est){
      if(i.Cadastro.Equals(cadas)){
        return i;
      }
    }
    return null;
  }

  public static void AtualizarEstudante(Estudante novo) {
    Estudante atualize = Sistema.ProcurarEstudante(novo.Cadastro);
    if(atualize!=null){
      atualize.Nome_cur = novo.Nome_cur;
    }
  }

  public static void ExcluirEstudante(int cadas) {
    Estudante remover = Sistema.ProcurarEstudante(cadas);
    total_est.Remove(remover);
  }

}
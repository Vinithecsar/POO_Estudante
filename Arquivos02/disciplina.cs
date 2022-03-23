using System;
using System.Collections.Generic;

public class Disciplina : IComparable<Disciplina> {
  string nome_estudante;//Joao
  int cadastro;//120, ou seja, foi a 120° pessoa a se cadastrar no app
  string nome_disciplina;//Física
  int prioridade;//1
  int id_disciplina;
  
  public Disciplina(){}
  public Disciplina(string n_est, int cadastro, string n_dis, int pri, int idDis) {
    nome_estudante = n_est;
    this.cadastro = cadastro;
    nome_disciplina = n_dis;
    prioridade = pri;
    id_disciplina = idDis;
  }
  public string Nome_est{
    get{return nome_estudante;}
    set{nome_estudante=value;}
  }
  public int Cadastro{
    get{return cadastro;}
    set{cadastro = value;}
  }
  public string Nome_dis{
    get{return nome_disciplina;}
    set{nome_disciplina=value;}
  }
  public int Prio{
    get{return prioridade;}
    set{prioridade=value;}
  }
  public int IdDis{
    get{return id_disciplina;}
    set{id_disciplina=value;}
  }
  
  public override string ToString() {
    return $"{nome_disciplina} (Id: {id_disciplina}) - Prioridade: {prioridade}";
  }

  public int CompareTo(Disciplina novo) {
    if (this.prioridade > novo.Prio) return 1;
    if (this.prioridade < novo.Prio) return -1;
    else return 0;
  }
}
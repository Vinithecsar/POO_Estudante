using System;
using System.Collections.Generic;

class Disciplina : IComparable<Disciplina> {
  string nome_estudante;//Joao
  string nome_disciplina;//Física
  int prioridade;//1

  public Disciplina(string n_est, string n_dis, int pri) {
    nome_estudante = n_est;
    nome_disciplina = n_dis;
    prioridade = pri;
  }
  public string Nome_est{get=>nome_estudante;}
  public string Nome_dis{get=>nome_disciplina;}
  public int Prio{
    get{return prioridade;}
    set{prioridade = value;}
  }
  
  public override string ToString() {
    return $"{nome_disciplina} - Prioridade: {prioridade}";
  }

  public int CompareTo(Disciplina novo) {
    if (this.prioridade > novo.Prio) return 1;
    if (this.prioridade < novo.Prio) return -1;
    else return 0;
  }
}
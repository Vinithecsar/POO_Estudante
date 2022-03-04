using System;
using System.Collections.Generic;
using System.Linq;

class Disciplina : IComparable<Disciplina> {
  public string nome_estudante;//Joao
  public string nome_disciplina;//Física
  public int prioridade;//1

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
    return $"Prioridade: {prioridade} - {nome_disciplina}";
  }

  public int CompareTo(Disciplina obj) {
    if (this.prioridade > obj.prioridade) return -1;
    if (this.prioridade < obj.prioridade) return 1;
    else return 0;
  }
}
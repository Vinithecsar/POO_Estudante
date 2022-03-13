using System;
using System.Collections.Generic;

class Estudante : IComparable<Estudante> {
  string nome;//pedro
  string curso;//filosofia
  int matricula;//3456

  public Estudante(string n_est, string n_cur, int mat) {
    nome = n_est;
    curso = n_cur;
    matricula = mat;
  }
  public string Nome_pessoa{get=>nome;}
  public string Nome_cur{get=>curso;}
  public int Matr{
    get{return matricula;}
    set{matricula = value;}
  }
  
  public override string ToString() {
    return $"{nome} - {curso} - Matrícula: {matricula}";
  }

  public int CompareTo(Estudante novo) {
    return this.nome.CompareTo(novo.Nome_pessoa);
  }
}
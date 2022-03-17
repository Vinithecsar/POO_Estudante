using System;
using System.Collections.Generic;

public class Estudante : IComparable<Estudante> {
  string nome;//pedro
  string curso;//filosofia
  int cadastro;//3456

  public Estudante(){}
  public Estudante(string n_est, string n_cur, int cadastro) {
    nome = n_est;
    curso = n_cur;
    this.cadastro = cadastro;
  }
  public string Nome_est{
    get{return nome;}
    set{nome=value;}
  }
  public string Nome_cur{
    get{return curso;}
    set{curso=value;}
  }
  public int Cadastro{
    get{return cadastro;}
    set{cadastro = value;}
  }
  
  public override string ToString() {
    return $"{nome} - {curso} - Cadastro: {cadastro}";
  }

  public int CompareTo(Estudante novo) {
    return this.nome.CompareTo(novo.Nome_est);
  }
}
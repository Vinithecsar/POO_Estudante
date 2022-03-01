using System;

class Assunto{
  string nome_disciplina;//Física
  string nome_assunto;//Termodinâmica
  int qtd_revisoes; 
  // Já revisei 3 vezes, 4 vezes até ter a capacidade necessária para encarar a prova

  public Assunto(string n_d, string n_a, int qtd){
    nome_disciplina = n_d;
    nome_assunto = n_a;
    qtd_revisoes = qtd;
  }
  
  public string Nome_d{get=>nome_disciplina;}
  public string Nome_a{get=>nome_assunto;}
  public int Qtd{
    get{ return qtd_revisoes;} 
    set{qtd_revisoes=value;}
  }

  public override string ToString(){
    return $"{nome_assunto} - {qtd_revisoes}";
  }
}
using System;

public class Assunto : IComparable<Assunto>{
  string nome_disciplina;//Física
  string nome_assunto;//Termodinâmica
  int qtd_revisoes; 
  int id_assunto;
  int id_disciplina;
  // Já revisei 3 vezes, 4 vezes até ter a capacidade necessária para encarar a prova
  public Assunto(){}
  public Assunto(string n_d, string n_a, int qtd, int id_as, int id_dis){
    nome_disciplina = n_d;
    nome_assunto = n_a;
    qtd_revisoes = qtd;
    id_assunto = id_as;
    id_disciplina = id_dis;
  }
  
  //propriedades
  public string Nome_d{
    get{return nome_disciplina;}
    set{nome_disciplina=value;}
  }
  public string Nome_a{
    get{return nome_assunto;}
    set{nome_assunto=value;}
  }
  public int Qtd{
    get{return qtd_revisoes;} 
    set{qtd_revisoes=value;}
  }

  public int IdAssunto{
    get{return id_assunto;}
    set{id_assunto=value;}
  }
  public int IdDisciplina{
    get{return id_disciplina;}
    set{id_disciplina=value;}
  }
  
  public override string ToString(){
    return $"{nome_assunto} (Id: {id_assunto}) - revisei {qtd_revisoes} vezes";
  }

  public int CompareTo(Assunto novo) {
    if (this.qtd_revisoes > novo.Qtd) return 1;
    if (this.qtd_revisoes < novo.Qtd) return -1;
    else return 0;
  }
}
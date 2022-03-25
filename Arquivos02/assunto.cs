using System;

public class Assunto : IComparable<Assunto>{
  string nome_disciplina;//Física
  int id_disciplina;// 21
  
  string nome_assunto;//Termodinâmica
  int qtd_revisoes; //revisei 3 vezes, 4 vezes, até ter capacidade de fazer a prova
  int id_assunto;// 100
  //construtores
  public Assunto(){}
  public Assunto(string n_d, int id_dis, string n_a, int qtd, int id_as){
    nome_disciplina = n_d;
    nome_assunto = n_a;
    qtd_revisoes = qtd;
    id_assunto = id_as;
    id_disciplina = id_dis;
  }
  //propriedades associação disciplina - assunto
  public string Nome_d{
    get{return nome_disciplina;}
    set{nome_disciplina=value;}
  }
  public int IdDisciplina{
    get{return id_disciplina;}
    set{id_disciplina=value;}
  }
  //propriedades assunto
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

  public override string ToString(){
    return $"{nome_assunto} (Id: {id_assunto}) - revisei {qtd_revisoes} vezes";
  }

  public int CompareTo(Assunto novo) {
    if (this.qtd_revisoes > novo.Qtd) return 1;
    if (this.qtd_revisoes < novo.Qtd) return -1;
    else return 0;
  }
}

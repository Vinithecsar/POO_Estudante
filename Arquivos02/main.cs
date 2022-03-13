using System;
using System.Collections;

class Program{
  public static void Main(){
    bool la=true;
    while(la){
      Console.WriteLine("");
      Console.WriteLine("------Escolha uma opção------");
      Console.WriteLine("01 - Inserir nova disciplina");
      Console.WriteLine("02 - Listar as disciplinas");
      Console.WriteLine("03 - Atualizar prioridade de uma disciplina");
      Console.WriteLine("04 - Excluir disciplina");
      Console.WriteLine("05 - Inserir novo assunto");
      Console.WriteLine("06 - Listar os assuntos de uma disciplina");
      Console.WriteLine("07 - Atualizar assunto de uma disciplina");
      Console.WriteLine("08 - Excluir assunto");
      Console.WriteLine("00 - Finalizar operações");

      Console.Write("Opção: ");
      int opcao = int.Parse(Console.ReadLine());
      if(opcao==1){DisInserir();}
      if(opcao==2){DisListar();}
      if(opcao==3){DisAtualizar();}
      if(opcao==4){DisExcluir();}
      if(opcao==5){AsInserir();}
      if(opcao==6){AsListar();}
      if(opcao==7){AsAtualizar();}
      if(opcao==8){AsExcluir();}
      if(opcao==0){break;}
    }
  }
  public static void DisInserir() {
    Console.WriteLine("");
    Console.WriteLine("------Inserir uma disciplina------");
    Console.Write("Informe o nome do estudante: ");
    string nome_e = Console.ReadLine();
    
    Console.Write("Informe o nome da disciplina: ");
    string nome_d2 = Console.ReadLine();
    
    Console.Write("Informe a prioridade: ");
    int pr = int.Parse(Console.ReadLine());

    Disciplina novo = new Disciplina(nome_e, nome_d2, pr);
    Sistema.InserirDis(novo);
    Console.WriteLine("");
    Console.WriteLine("Operação realizada com sucesso");
  }
  //funções quanto as disciplinas
  public static void DisListar() {
    Console.WriteLine("");
    Console.WriteLine("------Listar disciplinas------");
    foreach(Disciplina i in Sistema.ListarDis()) {
      Console.WriteLine(i);
    }
    Console.WriteLine("");
    Console.WriteLine("Operação realizada com sucesso");
  }

  public static void DisAtualizar() {
    Console.WriteLine("");
    Console.WriteLine("------Atualizar uma disciplina------");
    Console.Write("Informe o nome da disciplina: ");
    string nome = Console.ReadLine();

    Console.Write("Informe a nova prioridade: ");
    int prio = int.Parse(Console.ReadLine());

    Disciplina novo = new Disciplina("", nome, prio);
    Sistema.AtualizarDis(novo);
    Console.WriteLine("");
    Console.WriteLine("Operação realizada com sucesso");
  }

  public static void DisExcluir() {
    Console.WriteLine("");
    Console.WriteLine("------Excluir uma disciplina------");
    Console.Write("Informe o nome da disciplina: ");
    string nome = Console.ReadLine();

    Disciplina novo = new Disciplina("", nome, 0);
    Sistema.ExcluirDis(novo);
    Console.WriteLine("");
    Console.WriteLine("Operação realizada com sucesso");
  }
  //funções quanto aos assuntos
  public static void AsInserir(){
    Console.WriteLine("");
    Console.WriteLine("------Inserir um assunto------");
    Console.Write("Informe o nome da disciplina: ");
    string nome_d = Console.ReadLine();

    Console.Write("Informe o nome do assunto: ");
    string nome_a = Console.ReadLine();

    Console.Write("Informe a quantidade de vezes que já estudou esse assunto: ");
    int qtd = int.Parse(Console.ReadLine());

    Assunto novo = new Assunto(nome_d, nome_a, qtd);
    Sistema.InserirAs(novo);
    Console.WriteLine("");
    Console.WriteLine("Operação realizada com sucesso");
  }
  public static void AsListar(){
    Console.WriteLine("");
    Console.WriteLine("------Listar assuntos de uma disciplina------");
    Console.Write("Informe o nome da disciplina: ");
    string nome = Console.ReadLine();
    Console.WriteLine(nome);
    foreach(Assunto i in Sistema.ListarAs(nome)){
      Console.WriteLine(i);
    }
    Console.WriteLine("");
    Console.WriteLine("Operação realizada com sucesso");
  }
  public static void AsAtualizar(){
    Console.WriteLine("");
    Console.WriteLine("------Atualizar um assunto------");
    Console.Write("Informe o nome do assunto: ");
    string nome = Console.ReadLine();

    Console.Write("Informe a nova quantidade de revisões: ");
    int qtd = int.Parse(Console.ReadLine());

    Assunto novo = new Assunto("", nome, qtd);
    Sistema.AtualizarAs(novo);
    Console.WriteLine("");
    Console.WriteLine("Operação realizada com sucesso");
  }
  public static void AsExcluir(){
    Console.WriteLine("");
    Console.WriteLine("------Excluir um assunto------");
    Console.Write("Informe o nome do assunto: ");
    string nome = Console.ReadLine();

    Assunto novo = new Assunto("", nome, 0);
    Sistema.ExcluirAs(novo);
    Console.WriteLine("");
    Console.WriteLine("Operação realizada com sucesso");
  }
}
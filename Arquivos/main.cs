using System;
using System.Collections;

class Program{
  public static void Main(){
    Console.WriteLine("aaa");
    Console.WriteLine("teste de mudança");

    bool la=true;
    while(la){
      Console.WriteLine("------Escolha uma opção------");
      Console.WriteLine("05 - Inserir novo assunto");
      Console.WriteLine("06 - Listar os assuntos de uma disciplina");
      Console.WriteLine("07 - Atualizar assunto de uma disciplina");
      Console.WriteLine("08 - Excluir assunto");
      Console.WriteLine("00 - Finalizar operações");

      Console.Write("Opção: ");
      int opcao = int.Parse(Console.ReadLine());
      if(opcao==5){AsInserir();}
      if(opcao==6){AsListar();}
      if(opcao==7){AsAtualizar();}
      if(opcao==8){AsExcluir();}
      if(opcao==0){break;}
    }
  }
  public static void AsInserir(){
    Console.WriteLine("------Inserir um assunto------");
    Console.Write("Informe o nome da disciplina: ");
    string nome_d = Console.ReadLine();

    Console.Write("Informe o nome do assunto: ");
    string nome_a = Console.ReadLine();

    Console.Write("Informe a quantidade de vezes que já estudou esse assunto: ");
    int qtd = int.Parse(Console.ReadLine());

    Assunto novo = new Assunto(nome_d, nome_a, qtd);
    Sistema.InserirAs(novo);
    Console.WriteLine("Operação realizada com sucesso");
  }
  public static void AsListar(){
  Console.WriteLine("------Listar assuntos de uma disciplina------");

  Console.Write("Informe o nome da disciplina: ");
  string nome = Console.ReadLine();
  Console.WriteLine(nome);
  foreach(Assunto i in Sistema.ListarAs(nome)){
    Console.WriteLine(i);
  }

  Console.WriteLine("Operação realizada com sucesso");
}
  public static void AsAtualizar(){
    Console.WriteLine("------Atualizar um assunto------");
    Console.Write("Informe o nome do assunto: ");
    string nome = Console.ReadLine();

    Console.Write("Informe a nova quantidade de revisões: ");
    int qtd = int.Parse(Console.ReadLine());

    Assunto novo = new Assunto("", nome, qtd);
    Sistema.AtualizarAs(novo);
    Console.WriteLine("Operação realizada com sucesso");
  }
  public static void AsExcluir(){
    Console.WriteLine("------Excluir um assunto------");
    Console.Write("Informe o nome do assunto: ");
    string nome = Console.ReadLine();

    Assunto novo = new Assunto("", nome, 0);
    Sistema.ExcluirAs(novo);
    Console.WriteLine("Operação realizada com sucesso");
  }
}
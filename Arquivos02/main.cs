using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

class Program{
  private static Estudante login=null;
  public static void Main(){
    
    try{
     Sistema.AbrirArquivo(); //create
    }
    catch(Exception erro){
      Console.WriteLine(erro.Message);
    }
    int opcao=0;
    int escolher=0;
    do{
      if(escolher==0){//inicial
        escolher = MenuUsuario();//(1)adm ou (2)estudante
      }
      if(escolher==1){
        opcao = MenuAdm();
        /*
        quando tiver as funções estudante
        if(opcao==1){EstudanteInserir();}
        if(opcao==2){EstudanteListar();}
        if(opcao==3){EstudanteAtualizar();}
        if(opcao==4){EstudanteExcluir();}
        */
        if(opcao==5){DisListar(0);}
        if(opcao==6){AsListar(0);}
        if(opcao==99){escolher=0;}
      }
      if(escolher==2 && login==null){//estudante sem login
        opcao= MenuEstudanteSemLogin();
        if(opcao==1){Logar();}
        if(opcao==99){escolher=0;}
      }
      if(escolher==2 && login!=null){
        opcao= MenuEstudanteComLogin();
        int identi = login.Cadastro;
        string nome = login.Nome_est;
        if(opcao==1){DisInserir(nome, identi);}
        if(opcao==2){DisListar(identi);}
        if(opcao==3){DisAtualizar(identi);}
        if(opcao==4){DisExcluir(identi);}
        if(opcao==5){AsInserir(identi);}
        if(opcao==6){AsListar(identi);}
        if(opcao==7){AsAtualizar(identi);}
        if(opcao==8){AsExcluir(identi);}
        if(opcao==99){Logout(); escolher=0;}
      }
      
    }while(opcao!=-1);
    Sistema.SalvarArquivo(); //listas com valores dos xml
    /*
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
      Console.WriteLine("08 - Excluir assunto de uma disciplina");
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
    */
  }
  public static int MenuUsuario(){
    Console.WriteLine("");
    Console.WriteLine("----------Bem vindo(a) ao StudyClear----------");
    Console.WriteLine("01 - Sou administrador");
    Console.WriteLine("02 - Sou estudante");
    Console.Write("----------Opção: ");
    int opcao = int.Parse(Console.ReadLine());

    return opcao;
  }
  public static int MenuAdm(){
    Console.WriteLine("");
    Console.WriteLine("----------Olá, administrador(a)----------");
    Console.WriteLine("01 - Inserir novo estudante");
    Console.WriteLine("02 - Listar estudantes cadastrados");
    Console.WriteLine("03 - Atualizar dados de estudantes");
    Console.WriteLine("04 - Excluir estudantes cadastrados");
    Console.WriteLine("05 - Listar as disciplinas de um estudante");
    Console.WriteLine("06 - Listar os assuntos de um estudante");
    Console.WriteLine("99 - Voltar a tela inicial");
    Console.WriteLine("-1 - Encerrar");
    Console.Write("----------Opção: ");
    int opcao = int.Parse(Console.ReadLine());
    return opcao;
  }
  public static int MenuEstudanteSemLogin(){
    Console.WriteLine("");
    Console.WriteLine("----------Olá, estudante----------");
    Console.WriteLine("01 - Fazer login");
    Console.WriteLine("99 - Voltar a tela inicial");
    Console.WriteLine("-1 - Encerrar");
    Console.Write("----------Opção: ");
    int opcao = int.Parse(Console.ReadLine());
    return opcao;
  }
  public static int MenuEstudanteComLogin(){
    Console.WriteLine("");
    string nome_completo = login.Nome_est;
    string primeiro_nome = nome_completo.Substring(0,nome_completo.IndexOf(" "));
    
    Console.WriteLine($"----------Olá {primeiro_nome}, aqui está seu local de estudos!----------");
    Console.WriteLine("01 - Inserir nova disciplina");
    Console.WriteLine("02 - Listar as disciplinas");
    Console.WriteLine("03 - Atualizar prioridade de uma disciplina");
    Console.WriteLine("04 - Excluir disciplina");
    Console.WriteLine("05 - Inserir novo assunto");
    Console.WriteLine("06 - Listar os assuntos de uma disciplina");
    Console.WriteLine("07 - Atualizar assunto de uma disciplina");
    Console.WriteLine("08 - Excluir assunto de uma disciplina");
    Console.WriteLine("99 - Logout");
    Console.WriteLine("-1 - Encerrar");
    Console.Write("----------Opção: ");
    int opcao = int.Parse(Console.ReadLine());
    return opcao;
  }
  public static void Logar(){
    Console.WriteLine("");
    Console.WriteLine("----------Login do estudante----------");
    Console.Write("Informe seu nome e seu sobrenome: ");
    string estudante = Console.ReadLine();

    Console.Write("Informe o seu curso atual: ");
    string curso = Console.ReadLine();

    Console.Write("Informe o número de cadastro específico: ");
    int matricula = int.Parse(Console.ReadLine());

    Estudante novo = new Estudante(estudante, curso, matricula);
    login = novo;
  }
  public static void Logout(){
    Console.WriteLine("");
    Console.WriteLine("----------Logout----------");
    login = null;
    
  }
  //funções quanto as disciplinas
  public static void DisInserir(string nome, int id) {
    Console.WriteLine("");
    Console.WriteLine("------Inserir uma disciplina------");
    
    Console.Write("Informe o nome da disciplina: ");
    string nome_d2 = Console.ReadLine();
    
    Console.Write("Informe a prioridade: ");
    int pr = int.Parse(Console.ReadLine());

    Disciplina novo = new Disciplina(nome, id, nome_d2, pr);
    Sistema.InserirDis(novo);
    Console.WriteLine("");
    Console.WriteLine("Operação realizada com sucesso");
  }
  public static void DisListar(int id) {
    Console.WriteLine("");
    Console.WriteLine("------Listar disciplinas------");
    if(id==0){//adm está listando
      Console.WriteLine("01 - Listar todas as disciplinas de todos os estudantes: ");
      Console.WriteLine("02 - Listar disciplinas de um estudante específico");
      Console.Write("Opção: ");
      int op = int.Parse(Console.ReadLine());
      if(op ==1){
        foreach(Disciplina i in Sistema.ListarDis()){
          Console.WriteLine(i.Nome_est + " " + i);
        }
      }
      if(op ==2){
        Console.Write("Informe o número de cadastro: ");
        int cadastro = int.Parse(Console.ReadLine());
        foreach(Disciplina i in Sistema.ListarDis())
          if(i.Cadastro.Equals(cadastro)){
            Console.WriteLine(i.Nome_est + " " + i.Cadastro + " " + i);
          }
      }
    }
    if(id!=0){
    foreach(Disciplina i in Sistema.ListarDis()) {
      if(i.Cadastro.Equals(id)){
        Console.WriteLine(i); 
      }
    }  
  }
    Console.WriteLine("");
    Console.WriteLine("Operação realizada com sucesso");
  }

  public static void DisAtualizar(int id) {
    Console.WriteLine("");
    Console.WriteLine("------Atualizar uma disciplina------");
    Console.Write("Informe o nome da disciplina: ");
    string nome = Console.ReadLine();

    Console.Write("Informe a nova prioridade: ");
    int prio = int.Parse(Console.ReadLine());

    Disciplina novo = new Disciplina("", id, nome, prio);
    Sistema.AtualizarDis(novo);
    Console.WriteLine("");
    Console.WriteLine("Operação realizada com sucesso");
  }

  public static void DisExcluir(int id) {
    Console.WriteLine("");
    Console.WriteLine("------Excluir uma disciplina------");
    Console.Write("Informe o nome da disciplina: ");
    string nome = Console.ReadLine();

    Disciplina novo = new Disciplina("", id, nome, 0);
    Sistema.ExcluirDis(novo);
    Console.WriteLine("");
    Console.WriteLine("Operação realizada com sucesso");
  }
  //funções quanto aos assuntos
  public static void AsInserir(int id){
    Console.WriteLine("");
    Console.WriteLine("------Inserir um assunto------");
    //apresentar as opções válidas
    foreach(Disciplina i in Sistema.ListarDis()){
      if(i.Cadastro.Equals(id)){
        Console.WriteLine(i.Nome_dis); 
      }
    }
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
  public static void AsListar(int id){
    Console.WriteLine("");
    Console.WriteLine("------Listar assuntos de uma disciplina------");
    if(id==0){
      Console.WriteLine("01 - Listar todas os assuntos de todos os estudantes: ");
      Console.WriteLine("02 - Listar assuntos de um estudante específico");
      Console.Write("Opção: ");
      int op = int.Parse(Console.ReadLine());
      if(op ==1){
        foreach(Disciplina i in Sistema.ListarDis()){
          foreach(Assunto a in Sistema.ListarAs(i.Nome_dis)){
            Console.WriteLine(i.Nome_est + " " + i.Nome_dis + " " + a);
          }
        }
      }
      if(op ==2){
        Console.Write("Informe o número de cadastro: ");
        int cadastro = int.Parse(Console.ReadLine());
        foreach(Disciplina i in Sistema.ListarDis()){
          if(i.Cadastro.Equals(cadastro)){
            foreach(Assunto a in Sistema.ListarAs(i.Nome_dis)){
             Console.WriteLine(i.Nome_est + " " + i.Nome_dis + " " + a); 
            }
          }
        }
      }
    }
    if(id!=0){
    //apresentar as opções válidas
    foreach(Disciplina i in Sistema.ListarDis()){
      if(i.Cadastro.Equals(id)){
        Console.WriteLine(i.Nome_dis); 
      }
    }
    
    Console.Write("Informe o nome da disciplina: ");
    string nome = Console.ReadLine();
    Console.WriteLine(nome);
    foreach(Assunto i in Sistema.ListarAs(nome)){
      Console.WriteLine(i);
    }
    Console.WriteLine("");
    Console.WriteLine("Operação realizada com sucesso");      
    }
  }
  public static void AsAtualizar(int id){
    Console.WriteLine("");
    Console.WriteLine("------Atualizar um assunto------");
    foreach(Disciplina i in Sistema.ListarDis()){
      if(i.Cadastro.Equals(id)){
        Console.WriteLine(i.Nome_dis); 
      }
    }
    Console.Write("Informe o nome da disciplina: ");
    string nome_d = Console.ReadLine();

    foreach(Assunto i in Sistema.ListarAs(nome_d)){
      Console.WriteLine(i);
    }
    Console.Write("Informe o nome do assunto: ");
    string nome = Console.ReadLine();

    Console.Write("Informe a nova quantidade de revisões: ");
    int qtd = int.Parse(Console.ReadLine());

    Assunto novo = new Assunto("", nome, qtd);
    Sistema.AtualizarAs(novo);
    Console.WriteLine("");
    Console.WriteLine("Operação realizada com sucesso");
  }
  public static void AsExcluir(int id){
    Console.WriteLine("");
    Console.WriteLine("------Excluir um assunto------");
    foreach(Disciplina i in Sistema.ListarDis()){
      if(i.Cadastro.Equals(id)){
        Console.WriteLine(i.Nome_dis); 
      }
    }
    Console.Write("Informe o nome da disciplina: ");
    string nome_d = Console.ReadLine();

    foreach(Assunto i in Sistema.ListarAs(nome_d)){
      Console.WriteLine(i);
    }
    Console.Write("Informe o nome do assunto: ");
    string nome = Console.ReadLine();

    Assunto novo = new Assunto("", nome, 0);
    Sistema.ExcluirAs(novo);
    Console.WriteLine("");
    Console.WriteLine("Operação realizada com sucesso");
  }
}
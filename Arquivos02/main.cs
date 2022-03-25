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
      try{
        if(escolher==0){//inicial
          escolher = MenuUsuario();//(1)adm ou (2)estudante
        }
        if(escolher==1){
          opcao = MenuAdm();
          if(opcao==1){EstudanteInserir();}
          if(opcao==2){EstudanteListar();}
          if(opcao==3){EstudanteAtualizar();}
          if(opcao==4){EstudanteExcluir();}
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
          if(opcao==5){AsInserir(nome, identi);}
          if(opcao==6){AsListar(identi);}
          if(opcao==7){AsAtualizar(identi);}
          if(opcao==8){AsExcluir(identi);}
          if(opcao==99){Logout(); escolher=0;}
        }
      }
      catch (Exception erro) {
        opcao = -2;
        Console.WriteLine("Erro : " + erro.Message);
        Console.WriteLine("Tente novamente");
      }
    }while(opcao!=-1);
    try {
      Sistema.SalvarArquivo();
    }
    catch (Exception erro) {
      Console.WriteLine(erro.Message);
    }  
 //listas com valores dos xml

  }
  public static int MenuUsuario(){
    Console.WriteLine("");
    Console.WriteLine("----------Bem vindo(a) ao EstudoClaro----------");
    Console.WriteLine("01 - Sou administrador");
    Console.WriteLine("02 - Sou estudante");
    Console.WriteLine("-1 - Encerrar");
    Console.Write("----------Opção: ");
    int opcao = int.Parse(Console.ReadLine());

    if(opcao!= 1 && opcao!=2 && opcao!=-1){throw new ArgumentOutOfRangeException();}

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

    if(opcao < -1 || opcao == 0 || opcao > 6 && opcao < 99 || opcao > 99){throw new ArgumentOutOfRangeException();}
    
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

    if(opcao!= 1 && opcao!=99 && opcao!=-1){throw new ArgumentOutOfRangeException();}
    
    return opcao;
  }
  public static int MenuEstudanteComLogin(){
    Console.WriteLine("");
    string nome_completo = login.Nome_est;
    string primeiro_nome = nome_completo.Substring(0,nome_completo.IndexOf(" "));
    
    Console.WriteLine($"----------Olá {primeiro_nome}, aqui está seu local de estudos!----------");
    Console.WriteLine("01 - Inserir nova disciplina");
    Console.WriteLine("02 - Listar as disciplinas");
    Console.WriteLine("03 - Atualizar disciplina");
    Console.WriteLine("04 - Excluir disciplina");
    Console.WriteLine("05 - Inserir novo assunto");
    Console.WriteLine("06 - Listar os assuntos de uma disciplina");
    Console.WriteLine("07 - Atualizar assunto de uma disciplina");
    Console.WriteLine("08 - Excluir assunto de uma disciplina");
    Console.WriteLine("99 - Logout");
    Console.WriteLine("-1 - Encerrar");
    Console.Write("----------Opção: ");
    int opcao = int.Parse(Console.ReadLine());

    if(opcao < -1 || opcao == 0 || opcao > 8 && opcao < 99 || opcao > 99){throw new ArgumentOutOfRangeException();}
    
    return opcao;
  }
  public static void Logar(){
    Console.WriteLine("");
    Console.WriteLine("----------Login do estudante----------");

    Console.Write("Informe o número de cadastro específico: ");
    int cadastro = int.Parse(Console.ReadLine());

    login = Sistema.ProcurarEstudante(cadastro);
  }
  public static void Logout(){
    Console.WriteLine("");
    Console.WriteLine("----------Logout----------");
    login = null;
    
  }
  
  //funções quanto aos estudantes
  public static void  EstudanteInserir(){
    Console.WriteLine("");
    Console.WriteLine("------Inserir um estudante------");
    
    Console.Write("Informe o nome e sobrenome do estudante: ");
    string nome = Console.ReadLine();
    
    Console.Write("Informe o curso a ser estudado: ");
    string curso = Console.ReadLine();

    Console.Write("Informe o cadastro específico do estudante: ");
    int cadastro = int.Parse(Console.ReadLine());

    Estudante novo = new Estudante(nome, curso, cadastro);
    Sistema.InserirEstudante(novo);
    Console.WriteLine("");
    Console.WriteLine("Operação realizada com sucesso");
  }
  
  public static void EstudanteListar(){
    Console.WriteLine("");
    Console.WriteLine("------Listar estudantes------");
    foreach(Estudante novo in Sistema.ListarEstudante()){
      Console.WriteLine(novo);
    }
    Console.WriteLine("");
    Console.WriteLine("Operação realizada com sucesso");
  }

  public static void EstudanteAtualizar(){
    Console.WriteLine("");
    Console.WriteLine("------Atualizar um estudante------");
    foreach (Estudante i in Sistema.ListarEstudante()) {
      Console.WriteLine(i);
    }
    Console.WriteLine("---------------");
    
    Console.Write("Informe o novo nome do estudante: ");
    string estudante = Console.ReadLine();

    Console.Write("Informe o novo nome do curso: ");
    string curso = Console.ReadLine();

    Console.Write("Informe o cadastro do estudante: ");
    int cadastro = int.Parse(Console.ReadLine());

    Estudante novo = new Estudante(estudante, curso, cadastro);
    Sistema.AtualizarEstudante(novo);
    Console.WriteLine("");
    Console.WriteLine("Operação realizada com sucesso");
  }
  
  public static void EstudanteExcluir(){
    Console.WriteLine("");
    Console.WriteLine("------Excluir um estudante------");
    foreach (Estudante i in Sistema.ListarEstudante()) {
      Console.WriteLine(i);
    }
    Console.WriteLine("---------------");
    Console.Write("Informe o cadastro do estudante: ");
    int cadastro = int.Parse(Console.ReadLine());

    Estudante novo = new Estudante("", "", cadastro);
    Sistema.ExcluirEstudante(novo);
    Console.WriteLine("");
    Console.WriteLine("Operação realizada com sucesso");
  }

  //funções quanto as disciplinas
  public static void DisInserir(string nome, int id) {
    Console.WriteLine("");
    Console.WriteLine("------Inserir uma disciplina------");
    
    Console.Write("Informe o nome da disciplina: ");
    string nome_d2 = Console.ReadLine();
    
    Console.Write("Informe a prioridade: ");
    int pr = int.Parse(Console.ReadLine());

    Disciplina novo = new Disciplina(nome, id, nome_d2, pr, 0);
    Sistema.InserirDis(novo);
    Console.WriteLine("");
    Console.WriteLine("Operação realizada com sucesso");
  }
  public static void DisListar(int id) {
    Console.WriteLine("");
    Console.WriteLine("------Listar disciplinas------");
    if(id==0){//adm está listando
      Console.WriteLine("01 - Listar todas as disciplinas de todos os estudantes");
      Console.WriteLine("02 - Listar disciplinas de um estudante específico");
      Console.Write("Opção: ");
      int op = int.Parse(Console.ReadLine());
      if(op!= 1 && op!=2){throw new ArgumentOutOfRangeException();}
      
      if(op ==1){
        foreach(Disciplina i in Sistema.ListarDis()){
          Console.WriteLine(i.Nome_est + " - " + i);
        }
      }
      if(op ==2){
        foreach(Estudante novo in Sistema.ListarEstudante()){
          Console.WriteLine(novo);
        }
        Console.WriteLine("---------------");
        
        Console.Write("Informe o número de cadastro: ");
        int cadastro = int.Parse(Console.ReadLine());
        foreach(Disciplina i in Sistema.ListarDis()){
          if(i.Cadastro.Equals(cadastro)){
            Console.WriteLine(i.Nome_est + " - " + i.Cadastro + " - " + i);
          }
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

  //Erro!!!
  public static void DisAtualizar(int id) {
    Console.WriteLine("");
    Console.WriteLine("------Atualizar uma disciplina------");
    foreach (Disciplina i in Sistema.ListarDis()) {
      Console.WriteLine(i);
    }
    Console.WriteLine("---------------");
    
    Console.Write("Informe o id da disciplina: ");
    int id2 = int.Parse(Console.ReadLine());
    
    Console.Write("Informe o novo nome da disciplina: ");
    string nome = Console.ReadLine();

    Console.Write("Informe a nova prioridade: ");
    int prio = int.Parse(Console.ReadLine());

    Disciplina novo = new Disciplina("", id, nome, prio, id2);
    Sistema.AtualizarDis(novo);
    Console.WriteLine("");
    Console.WriteLine("Operação realizada com sucesso");
  }

  public static void DisExcluir(int id) {
    Console.WriteLine("");
    Console.WriteLine("------Excluir uma disciplina------");
    foreach (Disciplina i in Sistema.ListarDis()) {
      Console.WriteLine(i);}
    Console.WriteLine("---------------");
    Console.Write("Informe o Id da disciplina: ");
    int id2 = int.Parse(Console.ReadLine());

    Disciplina novo = new Disciplina("", id, "", 0, id2);
    Sistema.ExcluirDis(novo);
    Console.WriteLine("");
    Console.WriteLine("Operação realizada com sucesso");
  }
  
  //funções quanto aos assuntos
  public static void AsInserir(string nome, int id){
    //continuar = 0;
    Console.WriteLine("");
    Console.WriteLine("------Inserir um assunto------");
    //apresentar as opções válidas
    foreach(Disciplina i in Sistema.ListarDis()){
      if(i.Cadastro.Equals(id)){
        Console.WriteLine(i); 
      }
    }
    Console.WriteLine("---------------");
    Console.Write("Informe o id da disciplina, se ela não estiver na lista, coloque 0: ");
    int id_dis = int.Parse(Console.ReadLine());

    //se a disciplina já existir
    if(id_dis!=0){
      Console.Write("Informe o nome do assunto: ");
      string nome_a = Console.ReadLine();
      Console.Write("Informe a quantidade de vezes que já estudou esse assunto: ");
      int qtd = int.Parse(Console.ReadLine());
      //colocar o nome da disciplina
      Disciplina a = Sistema.ProcurarDis(id, id_dis);
      Assunto novo2 = new Assunto(a.Nome_dis, id_dis, nome_a, qtd, 0);
      Sistema.InserirAs(novo2);
      Console.WriteLine("");
      Console.WriteLine("Operação realizada com sucesso");
      
    } 
    //se a disciplina não existir
    if (id_dis == 0) {
      Console.Write("Informe o nome da disciplina: ");
      string nome_d = Console.ReadLine();
      Console.Write("Informe a prioridade: ");
      int pr = int.Parse(Console.ReadLine());
      Disciplina novo = new Disciplina(nome, id, nome_d, pr, 0);

      Console.Write("Informe o nome do assunto: ");
      string nome_a = Console.ReadLine();
      Console.Write("Informe a quantidade de vezes que já estudou esse assunto: ");
      int qtd = int.Parse(Console.ReadLine());

      Sistema.InserirDis(novo);
      Assunto novo3 = new Assunto(nome_d, Sistema.RetornoIdDis(novo), nome_a, qtd, 0);
      Sistema.InserirAs(novo3);
      Console.WriteLine("");
      Console.WriteLine("Operação realizada com sucesso");
    }
  }
  public static void AsListar(int id){
    Console.WriteLine("");
    Console.WriteLine("------Listar assuntos de uma disciplina------");
    if(id==0){
      Console.WriteLine("01 - Listar todos os assuntos de todos os estudantes");
      Console.WriteLine("02 - Listar assuntos de um estudante específico");
      Console.Write("Opção: ");
      int op = int.Parse(Console.ReadLine());
      if(op!= 1 && op!=2){throw new ArgumentOutOfRangeException();}
      
      if(op ==1){
        foreach(Disciplina i in Sistema.ListarDis()){
          foreach(Assunto a in Sistema.ListarAs(i.IdDis)){
            Console.WriteLine(i.Nome_est + " - " + i.Nome_dis + " - " + a);
          }
        }
        Console.WriteLine("---------------");
      }
      if(op ==2){
        foreach(Estudante novo in Sistema.ListarEstudante()){
          Console.WriteLine(novo);
        }
        Console.WriteLine("---------------");
        
        Console.Write("Informe o número de cadastro: ");
        int cadastro = int.Parse(Console.ReadLine());
        foreach(Disciplina i in Sistema.ListarDis()){
          if(i.Cadastro.Equals(cadastro)){
            foreach(Assunto a in Sistema.ListarAs(i.IdDis)){
             Console.WriteLine(i.Nome_est + " - " + i.Nome_dis + " - " + a); 
            }
          }
        }
        Console.WriteLine("---------------");
      }
    }
    if(id!=0){
    //mostrar as opções
    foreach(Disciplina i in Sistema.ListarDis()){
      if(i.Cadastro.Equals(id)){
        Console.WriteLine($"{i.Nome_dis} (Id: {i.IdDis})"); 
      }
    }
    Console.WriteLine("---------------");
      
    Console.Write("Informe o id da disciplina: ");
    int id_dis = int.Parse(Console.ReadLine());
    //imprimir só uma vez o nome da disciplina
    Disciplina a = Sistema.ProcurarDis(id, id_dis);
    Console.WriteLine(a.Nome_dis);
    //listar disciplinas daquele assunto
    Console.WriteLine("---------------");
    foreach(Assunto i in Sistema.ListarAs(id_dis)){
      Console.WriteLine(i);
    }
    Console.WriteLine("---------------");
      
    Console.WriteLine("");
    Console.WriteLine("Operação realizada com sucesso");      
    }
  }
  public static void AsAtualizar(int id){
    Console.WriteLine("");
    Console.WriteLine("------Atualizar um assunto------");
    //mostrar as opções
    foreach(Disciplina i in Sistema.ListarDis()){
      if(i.Cadastro.Equals(id)){
        Console.WriteLine($"{i.Nome_dis} (Id: {i.IdDis})"); 
      }
    }
    Console.WriteLine("---------------");
    
    Console.Write("Informe o id da disciplina: ");
    int iddis = int.Parse(Console.ReadLine());
    
    Console.WriteLine("---------------");
    foreach(Assunto i in Sistema.ListarAs(iddis)){
      Console.WriteLine(i);
    }
    Console.WriteLine("---------------");
    
    Console.Write("Informe o id do assunto: ");
    int idas = int.Parse(Console.ReadLine());

    Console.Write("Informe o novo nome do assunto: ");
    string nome = Console.ReadLine();
    
    Console.Write("Informe a nova quantidade de revisões: ");
    int qtd = int.Parse(Console.ReadLine());

    Assunto novo = new Assunto("", iddis, nome, qtd, idas);
    Sistema.AtualizarAs(novo);
    Console.WriteLine("");
    Console.WriteLine("Operação realizada com sucesso");
  }
  public static void AsExcluir(int id){
    Console.WriteLine("");
    Console.WriteLine("------Excluir um assunto------");
    //mostrar as opções
    foreach(Disciplina i in Sistema.ListarDis()){
      if(i.Cadastro.Equals(id)){
        Console.WriteLine($"{i.Nome_dis} (Id: {i.IdDis})"); 
      }
    }
    Console.WriteLine("---------------");
    
    Console.Write("Informe o id da disciplina: ");
    int iddis = int.Parse(Console.ReadLine());

    foreach(Assunto i in Sistema.ListarAs(iddis)){
      Console.WriteLine(i);
    }
    Console.WriteLine("---------------");
    
    Console.Write("Informe o id do assunto: ");
    int idas = int.Parse(Console.ReadLine());

    Assunto novo = new Assunto("",iddis, "", 0, idas);
    Sistema.ExcluirAs(novo);
    Console.WriteLine("");
    Console.WriteLine("Operação realizada com sucesso");
  }
}
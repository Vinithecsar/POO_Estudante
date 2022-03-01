using System;
using System.Collections;

class Program{
  public static void Main(){
    Console.WriteLine("aaa");
    Console.WriteLine("teste de mudança");

    Assunto a1 = new Assunto("fisica", "termodinamica", 1);
    Sistema.InserirAs(a1);
  }
}
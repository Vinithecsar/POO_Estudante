using System;//biblioteca .net
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Text;

class Arquivos<T>{
  public T Abrir(string nome_arquivo){
    //T vai receber XML
    XmlSerializer x = new XmlSerializer(typeof(T));
    StreamReader y = new StreamReader(nome_arquivo, Encoding.Default);
    
    T b = (T) x.Deserialize(y);
    y.Close();
    return b;
  }
  public void Salvar(string nome_arquivo, T obj){
    //XMl vai receber em formato T
    XmlSerializer x = new XmlSerializer(typeof(T));
    StreamWriter y = new StreamWriter(nome_arquivo, false, Encoding.Default);
    
    x.Serialize(y, obj);
    y.Close();
  }
}
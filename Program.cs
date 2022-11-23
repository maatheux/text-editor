using System;
using System.IO;
using System.Threading;

namespace TextEditor
{
  class Program
  {
    static void Main(string[] args)
    {
      Menu();
    }

    static void Menu()
    {
      Console.Clear();
      Console.WriteLine("O que você deseja fazer?\n1 - Abrir arquivo\n2 - Criar novo arquivo\n3 - Deletar arquivo\n0 - Sair");
      short? option = short.Parse(Console.ReadLine());

      switch (option)
      {
        case 0 : System.Environment.Exit(0); break;
        case 1 : OpenFile(); break;
        case 2 : EditFile(); break;
        case 3 : DeleteFile(); break;
        default : Menu(); break;
      }

    }

    static void OpenFile()
    {
      Console.Clear();
      Console.WriteLine("Insert the file path:");
      string path = Console.ReadLine();

      using(var file = new StreamReader(path))
      {
        string text = file.ReadToEnd(); // vai ler o arquivo todo
        Console.WriteLine(text);
      }

      Console.WriteLine("");
      Console.ReadLine();
      Menu();
    }

    static void EditFile()
    {
      Console.Clear();
      Console.WriteLine("Insert the text (ESC to exit):");
      Console.WriteLine("----------------------------");
      string text = "";

      do
      {
        text += Console.ReadLine();
        text += Environment.NewLine;
      }
      while (Console.ReadKey().Key != ConsoleKey.Escape);

      Save(text);

      Menu();

    }

    static void DeleteFile()
    {
      Console.Clear();
      Console.WriteLine("Insert the file path");
      var path = Console.ReadLine();

      try
      {
        if(File.Exists(path))
        {
          File.Delete(path);
          Console.WriteLine("File deleted successfully!");
        }
        else
        {
          Console.WriteLine("File not found!");
        }
      } 
      catch (IOException exception)
      {
        Console.WriteLine(exception.Message);
      }

      Thread.Sleep(5000);
      Menu();

    }

    static void Save(string text)
    {
      Console.Clear();
      Console.WriteLine("Insert the file path");
      var path = Console.ReadLine();

      using (var file = new StreamWriter(path))
      {
        file.Write(text);
      }
      // using serve para garantirmos que um objeto (arquivo, banco de dados) será aberto e depois fechado
      // StreamWriter é usado para abrir um arquivo e edita-lo. Temos tambem o StreamRead 

      Console.WriteLine("File saved successfully!");
      Console.WriteLine($"Path {path}");
      Thread.Sleep(5000);

    }

  }
}
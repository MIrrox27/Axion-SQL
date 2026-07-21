// author github.com/MIrrox27/Axion-SQL
// Program.cs

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using AxionSQL.Services;
using AxionSQL.Modules;
namespace AxionSQL 
{
  class Program
  {
    private static readonly object Locker = new();
    public static string ServerAddr = "http://localhost:5000";
     
     
     static void Main(string[] args)
    {

      _ = Task.Run(() => StartWebServer(args));

      Console.WriteLine("\n\n -- Axion SQL");
      Console.WriteLine($"Server started on {ServerAddr}. Commands must send to /db");
      
      while (true)   
      {
        Console.WriteLine($"\n\n-- Database name: {DataStore.DataBaseName}");
        Console.WriteLine($"-- Database path: {DataStore.DataBasePath}\n");

        Console.Write("\n> ");
        string? input = Console.ReadLine();
        if (input == "q" || input == "Q") break;
        Perfomer.Perfom(Parser.Parse(input));
        Console.Write("\n\n\n");
        PrintTable(DataStore.DataBase);
      }

    
    }
    static void PrintTable(List<List<string>> data)
    {
        if (data.Count == 0) return;
        int columnWidth = 20;
        PrintRow(data[0], columnWidth);

        
        int totalWidth = data[0].Count * (columnWidth + 3) - 1;
        Console.WriteLine(new string('-', totalWidth));

        for (int i = 1; i < data.Count; i++)
        {
            PrintRow(data[i], columnWidth);
        }
    }

    static void PrintRow(List<string> row, int width)
    {

        List<string> formats = new();
        for (int i = 0; i < row.Count; i++)
        {
            formats.Add($"{{{i}, -{width}}}");
        }
        
        string rowTemplate = string.Join(" | ", formats);

        Console.WriteLine(rowTemplate, row.ToArray());
    }

     public static string Perfom(List<string> _command)
    {
      lock (Locker)
      {
        return Perfomer.Perfom(_command);
      }
    } 


    public static void StartWebServer(string[] args)
    {
      Server.StartWebServer(Locker, args);
    }
  }
}
// author github.com/MIrrox27/Axion-SQL
// Program.cs

using System;
using System.Runtime.InteropServices;
using AxionSQL.Services;
using AxionSQL.Modules;
namespace AxionSQL 
{
  class Program
  {
     static void Main()
    {
      Console.WriteLine("Axion SQL\n> ");
      string command = Console.ReadLine();
      Perfomer.Perfom(Parser.Parse(command));

      PrintTable(DataStore.DataBase);

    // test command NEW COLUMN A NEW COLUMN B NEW ROW NEW ROW NEW ROW PUSH ROW 1 COLUMN 0 ELEMENT 67 GET ROW 1 COLUMN 0
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
  }
}
// author github.com/MIrrox27/Axion-SQL
// Services/Parser.cs

using System.Collections.Generic;
using AxionSQL.Modules;
using System.Linq;
using System.Text.RegularExpressions;
namespace AxionSQL.Services;

public class Parser
{
  public static List<string> Parse(string _command)
  {
    /*
      Чо мне надо?
      строка - разбить по пробелам - вернуть список 

    */
    _command = Regex.Replace(_command.Trim(), @"\s+", " ");
    List<string> command = _command.Split(' ').ToList();
    foreach (var a in command) Console.WriteLine(a);
    Console.WriteLine($"\n\n{command.Count}");
    return command;
    
  }

}
// author github.com/MIrrox27/Axion-SQL
// Services/Parser.cs

using System.Collections.Generic;
using AxionSQL.Modules;
using System.Linq;
namespace AxionSQL.Services;

public class Parser
{
  public static List<string> Parse(string _command)
  {
    /*
      Чо мне надо?
      строка - разбить по пробелам - вернуть список 

    */
    List<string> command = _command.Split(' ').ToList();
    return command;
    
  }

}
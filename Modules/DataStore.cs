// author github.com/MIrrox27/Axion-SQL
// Services/Database.cs

using System.Collections.Generic;

namespace AxionSQL.Modules;

public static class DataStore
{
  public static List<List<string>> DataBase { get; set; } = new List<List<string>> ();
}
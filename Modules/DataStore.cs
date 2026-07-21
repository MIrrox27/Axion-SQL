// author github.com/MIrrox27/Axion-SQL
// Services/Database.cs

using System.Collections.Generic;

namespace AxionSQL.Modules;

public static class DataStore
{
  public static List<List<string>> DataBase { get; set; } = new List<List<string>> ();
  
  private static readonly string DataBasePathDefault  = @"./";
  private static readonly string DataBaseNameDefault = @"table.json";
  
  public static string DataBasePath { get; set; } = DataBasePathDefault;
  public static string DataBaseName { get; set; } = DataBaseNameDefault;

  public static void SetDefault()
  {
    DataBasePath = DataBasePathDefault;
    DataBaseName = DataBaseNameDefault;
  }
}

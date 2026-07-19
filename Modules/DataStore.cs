// author github.com/MIrrox27/Axion-SQL
// Services/Database.cs

using System.Collections.Generic;

namespace AxionSQL.Modules;

public static class DataStore
{
  public static List<List<string>> DataBase { get; set; } = new List<List<string>> ();
  
  private static string DataBasePathDefault = "./";
  private static string DataBaseNameDefault = "table.json";
  
  public static string DataBasePath = DataBasePathDefault;
  public static string DataBaseName = DataBasePathDefault;

  public static void SetDefault()
  {
    DataBasePath = DataBasePathDefault;
    DataBaseName = DataBasePathDefault;
  }
}

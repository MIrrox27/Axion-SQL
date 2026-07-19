// author github.com/MIrrox27/Axion-SQL
// Services/FileGet.cs

using System.IO;          
using System.Text.Json; 

using AxionSQL.Modules;  


namespace AxionSQL.Services;

class FileGet
{
  public static int TableImport(string path)
  {
    if (File.Exists(path))
    {
    string importTable = File.ReadAllText(path);
      try
      {
        if (!string.IsNullOrEmpty(importTable) && !string.IsNullOrWhiteSpace(importTable))
        DataStore.DataBase = JsonSerializer.Deserialize<List<List<string>>>(importTable);
      }
      catch (JsonException)
      {
        return 1;
      }
    }
    return 0;

  }


}
// author github.com/MIrrox27/Axion-SQL
// Services/FileGet.cs

using System.IO;          
using System.Text.Json; 
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using AxionSQL.Modules;  


namespace AxionSQL.Services;

class FileGet
{
  public static int TableImport(string path)
  {
    if (File.Exists(path))
    {
    string importTable = File.ReadAllText(path);
    string fileName = Path.GetFileName(path);
    string filePath = Path.GetDirectoryName(path);

      try
      {
        if (!string.IsNullOrEmpty(importTable) && !string.IsNullOrWhiteSpace(importTable))
        DataStore.DataBase = JsonSerializer.Deserialize<List<List<string>>>(importTable);

        DataStore.DataBaseName = fileName;
        DataStore.DataBasePath = filePath;
      }
      catch (JsonException)
      {
        Console.WriteLine("Error with import table");
        return 1;
      }
    }
    return 0;

  }


}
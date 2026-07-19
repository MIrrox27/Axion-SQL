// author github.com/MIrrox27/Axion-SQL
// Services/FileSave.cs

using System.IO;          
using System.Text.Json; 

using AxionSQL.Modules;


namespace AxionSQL.Services;

class FileSave
{
  public static int TableSave()
  {
    string pathToSave = DataStore.DataBasePath + DataStore.DataBaseName;
    var options = new JsonSerializerOptions { WriteIndented = true };
    string prettyJson = JsonSerializer.Serialize(DataStore.DataBase, options); 

    File.WriteAllText(pathToSave, prettyJson);

    return 0;
  }

  public static int TableExport(string path)
  {
    var options = new JsonSerializerOptions { WriteIndented = true };
    string prettyJson = JsonSerializer.Serialize(DataStore.DataBase, options); 
    File.WriteAllText(path, prettyJson);
    return 0;
  }

  public static void TableNew()
  {
    TableSave();
    DataStore.SetDefault();
    DataStore.DataBase = new();
  }

}
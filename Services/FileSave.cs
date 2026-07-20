// author github.com/MIrrox27/Axion-SQL
// Services/FileSave.cs

using System.IO;          
using System.Text.Json; 

using AxionSQL.Modules;


namespace AxionSQL.Services;

class FileSave
{
  public static int TableSave() // TABLE NAME test TABLE PATH C:\table\ NEW COLUMN name NEW COLUMN age NEW ROW 2 PUSH ROW 1 COLUMN 0 ELEMENT Maksim PUSH ROW 1 COLUMN 1 ELEMENT 16
  {
    string pathToSave = Path.Combine(DataStore.DataBasePath,  DataStore.DataBaseName);
    Directory.CreateDirectory(DataStore.DataBasePath);
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
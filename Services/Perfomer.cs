// author github.com/MIrrox27/Axion-SQL
// Services/Perfomer.cs

using System.Diagnostics.Tracing;
using AxionSQL.Modules;
using AxionSQL.Services;


public class Perfomer
{
  public static void Perfom(List<string> _command)
  {

    for (int i = 0; i < _command.Count; i++)
    {
      switch (_command[i])
      {
        case "NEW": // NEW-0 COLUMN-1 A-2 NEW-3 COLUMN-4 B-5 NEW-6 ROW-7
          {
            i++; // 1\4

            if (DataStore.DataBase.Count == 0)
            {
                DataStore.DataBase.Add(new List<string>());
            }

            if (_command[i] == "COLUMN")
            {
              foreach (var el in DataStore.DataBase)
              {
                el.Add("");
              }
              i++; // 2\5
              int len = DataStore.DataBase[0].Count;
              DataStore.DataBase[0][len - 1] = _command[i];
            }

            else if (_command[i] == "ROW")
            {
              int len = DataStore.DataBase.Count;
              

              if (i+1 < len && !string.IsNullOrWhiteSpace(_command[i++]) && int.TryParse(_command[i++], out int number))
              { 
                i++;
                int rows = int.Parse(_command[i]);
                for (int t = 0; t < rows; t++) 
                {
                  List<string> new_row = new();
                  for (int j = 0; j < len; j++) new_row.Add("");
                  DataStore.DataBase.Add(new_row);
                }
                
              }
              else
              {
                List<string> new_row = new();
                for (int j = 0; j < len; j++) new_row.Add("");
                DataStore.DataBase.Add(new_row); 
              }
              i++;
              
            }
            break;
          }

        case "PUSH" :
          {
            i++;
            
            int col = 0;
            int row = 1;

            if (_command[i] == "ROW")
            {
              i++;
              row = int.Parse(_command[i]);
            }
            else throw new Exception($"Unexpected command {_command[i]}, expected 'ROW'");
            
            i++;

            if (_command[i] == "COLUMN")
            {
              i++;
              col = int.Parse(_command[i]);
            }
            else throw new Exception($"Unexpected command {_command[i]}, expected 'COLUMN'");

            i++;

            if (_command[i] == "ELEMENT")
            {
              i++;
              string element = _command[i];
              DataStore.DataBase[row][col] = element;
            }
            else throw new Exception($"Unexpected command {_command[i]}, expected 'ELEMENT'");
            break;
          }
        
        case "GET":
          {
            i++;
            
            int col = 0;
            int row = 1;

            if (_command[i] == "ROW")
            {
              i++;
              row = int.Parse(_command[i]);
            }
            else throw new Exception($"Unexpected command {_command[i]}, expected 'ROW'");
            
            i++;

            if (_command[i] == "COLUMN")
            {
              i++;
              col = int.Parse(_command[i]);
            }
            else throw new Exception($"Unexpected command {_command[i]}, expected 'COLUMN'");

            Console.WriteLine(DataStore.DataBase[row][col]); // пока просто вывод в консоль, потом сделаю возврат значения или отправку на сервер
            break;
          }

        /*case "DELETE":
          {
            
            break;
          }*/

        default: 
          throw new Exception($"Unexpected command '{_command[i]}'");

      }
    }    

  }

}
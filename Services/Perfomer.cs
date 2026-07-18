// author github.com/MIrrox27/Axion-SQL
// Services/Perfomer.cs

using System.Diagnostics.Tracing;
using AxionSQL.Modules;
using AxionSQL.Services;


public class Perfomer
{
  public static void Perfom(List<string> _command)
  {

    if (DataStore.DataBase.Count == 0)
      DataStore.DataBase.Add(new List<string>());
    

    for (int i = 0; i < _command.Count; i++)
    {
      switch (_command[i])
      {
        case "NEW": // NEW-0 COLUMN-1 A-2 NEW-3 COLUMN-4 B-5 NEW-6 ROW-7
          {
            i++; // 1\4

            //Console.WriteLine($"-start New-- {i-1}-{_command[i-1]} -- *{i}-{_command[i]}* -- {i + 1}-{_command[i+1]}");



            if (_command[i] == "COLUMN")
            {
              i++;
              //Console.WriteLine($"-col1-- {i-1}-{_command[i-1]} -- *{i}-{_command[i]}* -- {i + 1}-{_command[i+1]}"); 
              foreach (var el in DataStore.DataBase)
              {
                el.Add("ф"); // временно буду заполнять строки по умолчанию буквой "ф" чтобы видеть как работает добавление строк
              }
              DataStore.DataBase[0][^1] = _command[i];
              //Console.WriteLine($"-col2-- {i-1}-{_command[i-1]} -- *{i}-{_command[i]}* -- {i + 1}-{_command[i+1]}");
            }

            else if (_command[i] == "ROW")
            {
              int len = DataStore.DataBase[0].Count;
              i++;
              //Console.WriteLine($"-row1-- {i-1}-{_command[i-1]} -- *{i}-{_command[i]}* -- {i+1}");
              
              Console.WriteLine($"i={i}, count={_command.Count-1}\n\n");
              if (int.TryParse(_command[i], out int number))
              { 
                Console.WriteLine($"rows={_command[i]}");
                int rows = int.Parse(_command[i]);
                for (int t = 0; t < rows; t++)
                {
                  List<string> new_row = new();
                  for (int j = 0; j < len; j++) new_row.Add("ф"); // временно буду заполнять строки по умолчанию буквой "ф" чтобы видеть как работает добавление строк
                  DataStore.DataBase.Add(new_row);
                }
                
              }
              else
              {
                List<string> new_row = new();
                for (int j = 0; j < len; j++) new_row.Add("ф"); // временно буду заполнять строки по умолчанию буквой "ф" чтобы видеть как работает добавление строк
                DataStore.DataBase.Add(new_row); 
              }
              //Console.WriteLine($"-row2-- {i-1}-{_command[i-1]} -- *{i}-{_command[i]}* -- ");              
            }
            else Console.WriteLine($"Expected command {_command[i]}");

            //Console.WriteLine($"-end New-- {i-1}-{_command[i-1]} -- *{i}-{_command[i]}* -- ");
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
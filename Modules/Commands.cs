// author github.com/MIrrox27/Axion-SQL
// Modules/Commands.cs

namespace AxionSQL.Modules;

public enum CommandTokens
{
  NEW, // Создать новую строку/колонку
  PUSH, // добавить (обновить) элемент, пример ADD COLUMN "column_name" ROW "index" ELEMENT "element"
  GET, // получить элемент, пример ADD COLUMN "column_name" ROW "index" -> выведет значение элемента
  
  DELETE, // удалить элемент/строку/колонку, пример ADD COLUMN "column_name" ROW "index" -> удалит элемент

  ROW, // ключевое слово, после идет значение 
  COLUMN, // ключевое слово, после идет значение 
  ELEMENT // ключевое слово, после идет значение 
}
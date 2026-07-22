// author github.com/MIrrox27/Axion-SQL
// Modules/Commands.cs

namespace AxionSQL.Modules;

public enum CommandTokens
{
    // СПИСОК КОМАНД

  NEW, // Создать новую строку/колонку/таблицу
  PUSH, // добавить (обновить) элемент, пример ADD COLUMN index ROW index ELEMENT "element"
  GET, // получить элемент, пример ADD COLUMN index ROW index -> выведет значение элемента
  
  DELETE, // удалить элемент/строку/колонку, пример ADD COLUMN index ROW index -> удалит элемент

  TABLE, // вводная команда
  NAME, // установить имя
  PATH,  // установить путь 
  SAVE, // Сохранить таблицу по установленному пути
  CHANGE, // TABLE CHANGE <alias>

  ALIAS, // TABLE ALIAS <new_alias>


  IMPORT, // Сменить/открыть таблицу 
  EXPORT, // Сохранить таблицу по новому пути

  ROW, // ключевое слово, после идет значение 
  COLUMN, // ключевое слово, после идет значение 
  ELEMENT, // ключевое слово, после идет значение 

  ALL // 
}
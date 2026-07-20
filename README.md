# Axion SQL

This is simple program to make your database.

## How use it?

You can make new rows, new columns, place elements to cells and get elements from cells.

For do this, you can use this commands:

 * `NEW ROW <count rows>` - make new row
 * `NEW COLUMN <column_name_without_spaces>` - make new column 
 * `PUSH ROW <row number> COLUMN <column number> ELEMENT <your text wihtout space>` - place your element to cell
 * `GET ROW <row_number> COLUMN <column_number>` - print element from cell 
 * `TABLE NAME <new_name_without_spaces>` - set new name for table
 * `TABLE PATH <new_path_without_spaces>` - set new path to save
 * `TABLE NEW` - save last table and make new
 * `TABLE IMPORT <path_to_table_without_spaces>` - import table from your path
 * `TABLE EXPORT <path_to_export_without_spaces>` - save table to new path, new path not save
 * `TABLE SAVE` - save table to main path

First row use by name your columns.


## Install and Run

This app was make in C#.

### Requirements
 - .NET + C#

### Installing
``` bash
git clone https://github.com/MIrrox27/Axion-SQL
cd Axion-SQL
```


### Running
```bash
dotnet run
```
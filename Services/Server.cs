// author github.com/MIrrox27/Axion-SQL
// Services/Server.cs


using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using System.Collections.Concurrent;
using System.Threading.Tasks;

using AxionSQL.Services;
using AxionSQL.Modules;
using AxionSQL;

namespace AxionSQL.Services;

class Server
{
  public static void StartWebServer(object Locker, string[] args)
  {
    var builder = WebApplication.CreateBuilder();
    builder.Logging.ClearProviders();
    var app = builder.Build();

    app.MapGet("/db", async () =>
    {
      await Task.Delay(10);

      lock (Locker)
      {
        return Results.Ok(DataStore.DataBase);
      }  


    });

    app.MapPost("/db", async (string command) =>
    {
      await Task.Delay(10); // пауза

      lock (Locker)
      {
        return Perfomer.Perfom(Parser.Parse(command));
      }
    });
    app.Run(Program.ServerAddr);

  }


}
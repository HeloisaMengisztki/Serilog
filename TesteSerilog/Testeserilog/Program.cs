using System;
using Serilog;

namespace Testeserilog
{
    class Program
    {
        static void Main(string[] args)
        {
            // Log.Logger = new LoggerConfiguration().CreateLogger();
            // Log.Information("No one listens to me!");
            // Log.CloseAndFlush();
            // //não tem uma pia associada escutando esse log.

            var log = new LoggerConfiguration()
                .Enrich.FromLogContext()
                // Mantém props para todo os logs na aplicação
                .Enrich.WithProperty("HerculesContextId", Guid.NewGuid().ToString())
                // Adiciona algo ao log, enriquece de info; deve ser adicionado no autput template
                .MinimumLevel.Debug()
                // define o valor mais baixo q vai ser mostrado, se n setado, o info é o default
                .WriteTo.Console(outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {HerculesContextId:j} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                // define uma sink (destino) para o log
                .CreateLogger();

            var pessoa = new { nome = "heloisa", idade = 20 };
            log.Information("In my bowl I have {Fruit}", pessoa);

            log.Information("uma informação");
            log.Warning("alerta");
            log.Error("erro");
        }
    }
}
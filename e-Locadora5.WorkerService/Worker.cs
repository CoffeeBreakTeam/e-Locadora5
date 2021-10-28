using e_Locadora5.Aplicacao.LocacaoModule;
using e_Locadora5.Dominio.LocacaoModule;
using e_Locadora5.Email;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace e_Locadora5.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;    
        LocacaoAppService locacaoAppService;
        SMTP email = new SMTP();

        public Worker(ILogger<Worker> logger, LocacaoAppService locacaoAppService )
        {
            _logger = logger;
            this.locacaoAppService = locacaoAppService;
       

        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var locacoesComEmailPendente = locacaoAppService.SelecionarLocacoesEmailPendente();

                    if (locacoesComEmailPendente.Count == 0)
                    {
                        _logger.LogInformation("Nenhum email para enviar");
                        await Task.Delay(5000, stoppingToken);
                        continue;
                    }
                    if (!email.estaConectadoInternet())
                    {
                        _logger.LogInformation("Sem internet");
                        await Task.Delay(300000, stoppingToken);
                        continue;
                    }
                    Parallel.ForEach(locacoesComEmailPendente, (locacao) =>
                    {
                        locacaoAppService.EnviarEmail(locacao);
                    });

                }
                catch (Exception ex)
                {

                    _logger.LogError(ex, "Erro");
                    await Task.Delay(30000, stoppingToken);
                   
                }


                
            }
        }
    }
}

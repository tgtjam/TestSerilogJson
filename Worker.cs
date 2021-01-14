using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerTest {
    public class Worker : BackgroundService {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger) {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
            int i = 0;

            try {
                while (!stoppingToken.IsCancellationRequested) {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    await Task.Delay(5000, stoppingToken);

                    // Se lanza excepcion para pruebas.
                    if (i++ > 3) throw new Exception("Error en Worker");
                }

            } catch (Exception ex) {
                _logger.LogError(ex, ex.Message);
            }
        }
    }
}

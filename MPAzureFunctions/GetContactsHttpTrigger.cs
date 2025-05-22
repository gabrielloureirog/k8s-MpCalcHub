using System.Threading.Tasks;
using Fiap.Fase3.MPAzureFunctions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace GetContacts.Function
{
    public class GetContactsHttpTrigger
    {
        private readonly ILogger<GetContactsHttpTrigger> _logger;
        private readonly ApplicationDBContext _context;

        public GetContactsHttpTrigger(ILogger<GetContactsHttpTrigger> logger, ApplicationDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Function("GetContactsHttpTrigger")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("Iniciando a execução da função GetContactsHttpTrigger.");

            var contacts = await _context.GetContacts();

            _logger.LogInformation("Finalizando a execução da função GetContactsHttpTrigger.");

            return new OkObjectResult(contacts);

        }
    }
}

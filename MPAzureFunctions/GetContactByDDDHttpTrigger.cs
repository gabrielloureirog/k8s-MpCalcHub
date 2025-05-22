using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Fiap.Fase3.MPAzureFunctions;
using Microsoft.IdentityModel.Tokens;

namespace MPAzureFunctions
{
    public class GetContactByDDDHttpTrigger
    {
        private readonly ILogger<GetContactByDDDHttpTrigger> _logger;
        private readonly ApplicationDBContext _context;

        public GetContactByDDDHttpTrigger(ILogger<GetContactByDDDHttpTrigger> logger, ApplicationDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Function("GetContactByDDDHttpTrigger")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("Iniciando a execução da função GetContactsByDDDHttpTrigger.");

            var ddd = req.Query["ddd"];

            if (ddd.IsNullOrEmpty())
                return new BadRequestObjectResult("O DDD é obrigatório.");

            var contacts = await _context.GetContactsByDDD(int.Parse(ddd));

            _logger.LogInformation("Finalizando a execução da função GetContactsByDDDHttpTrigger.");

            return new OkObjectResult(contacts);
        }
    }
}

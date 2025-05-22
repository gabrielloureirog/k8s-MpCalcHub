using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Fiap.Fase3.MPAzureFunctions;

namespace MPAzureFunctions
{
    public class GetContactByIdHttpTrigger
    {
        private readonly ILogger<GetContactByIdHttpTrigger> _logger;
        private readonly ApplicationDBContext _context;

        public GetContactByIdHttpTrigger(ILogger<GetContactByIdHttpTrigger> logger, ApplicationDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Function("GetContactByIdHttpTrigger")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("Iniciando a execução da função GetContactByIdHttpTrigger.");

            var id = req.Query["id"];

            if (id.IsNullOrEmpty())
                return new BadRequestObjectResult("O DDD é obrigatório.");

            var contacts = await _context.GetContactById(Guid.Parse(id));

            _logger.LogInformation("Finalizando a execução da função GetContactByIdHttpTrigger.");

            return new OkObjectResult(contacts);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MPCalcHub.Application.DataTransferObjects;
using MPCalcHub.Application.Interfaces;
using static MPCalcHub.Domain.Constants.AppConstants;

namespace MPCalcHub.Api.Controllers
{
    /// <summary>
    /// Contact controller
    /// </summary>
    [Route("contacts")]
    public class ContactController(ILogger<ContactController> logger, IContactApplicationService contactApplicationService) : BaseController(logger)
    {
        private readonly IContactApplicationService _contactApplicationService = contactApplicationService;
    }
}

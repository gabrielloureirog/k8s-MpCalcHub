using MPCalcHub.Domain.Constants;
using MPCalcHub.Application.Interfaces;
using MPCalcHub.Domain.Settings;
using Microsoft.Extensions.Options;

namespace MPCalcHub.Api.Robots.RabbitMQ
{
    public class ContactConsumerService : BaseRabbitMQConsumerService
    {
        public override string Queue => "mpcalchub.contact_remove";

        public override string RoutingKey => "contact.remove.*";

        public ContactConsumerService(IServiceProvider serviceProvider, IOptions<MPCalcHubSettings> settings,  ILogger<ContactConsumerService> logger)
            : base(serviceProvider, settings, logger)
        {
            ServiceMaps.Add(AppConstants.Routes.RabbitMQ.ContactRemoved, sp => serviceProvider.GetService<IContactApplicationService>());
        }
    }
}
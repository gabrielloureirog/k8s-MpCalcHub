namespace MPCalcDeleterProducer.Services
{
    public interface IRabbitMqService
    {
        Task PublishMessageAsync(string message);
    }
}

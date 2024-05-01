namespace ConsultServiceState.Entities.Interfaces
{
    public interface IRabbitMQ
    {
        void CreateLog(MessageRabbit messageRabbit);
    }
}

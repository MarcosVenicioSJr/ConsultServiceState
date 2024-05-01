using ConsultServiceState.Entities;
using ConsultServiceState.Entities.Interfaces;
using RabbitMQ.Client;
using System.Text;

namespace ConsultServiceState.Services.RabbitMQ
{
    public class CreateLogRabbitMQ : IRabbitMQ
    {
        public void CreateLog(MessageRabbit messageRabbit)
        {
            try
            {

                var factory = new ConnectionFactory { HostName = "localhost" };
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                channel.QueueDeclare(
                    queue: messageRabbit.Queue,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                    );

                var body = Encoding.UTF8.GetBytes(messageRabbit.Message);

                channel.BasicPublish(
                    exchange: string.Empty,
                    routingKey: messageRabbit.Queue,
                    basicProperties: null,
                    body: body
                    );
            }
            catch
            {
                throw;
            }

        }
    }
}

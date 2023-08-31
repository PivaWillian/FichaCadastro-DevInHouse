using RabbitMQ.Client;

namespace FichaCadastroRabbitMQ
{
    public class MessageRabbitMQ : IMessageRabbitMQ
    {
        private IModel _channel;
        private readonly IFactoryConnectionRabbitMQ _factoryConnectionRabbitMQ;

        public MessageRabbitMQ(IFactoryConnectionRabbitMQ connection)
        {
            _factoryConnectionRabbitMQ = connection;
        }

        public IModel ConfigureVirtualHost(string virtualHost)
        {
            _channel = _factoryConnectionRabbitMQ.CreateConnection(virtualHost);
            return _channel;
        }
    }
}

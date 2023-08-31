using RabbitMQ.Client;

namespace FichaCadastroRabbitMQ
{
    public interface IMessageRabbitMQ
    {
        IModel ConfigureVirtualHost(string virtualHost);
    }
}
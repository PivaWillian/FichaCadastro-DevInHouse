using FichaCadastroRabbitMQ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FichaCadastroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FichasController : ControllerBase
    {
        private readonly IMessageRabbitMQ _messageRabbitMQ;

        public FichasController(IMessageRabbitMQ messageRabbitMQ)
        {
            _messageRabbitMQ = messageRabbitMQ;
        }

        [HttpPost]
        [Route("cadastro/novo/topic")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult CadastroNovoTopicPost()
        {
            try
            {
                _messageRabbitMQ.ConfigureVirtualHost("ficha");
                return StatusCode(HttpStatusCode.Created.GetHashCode());
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }            
        }



    }
}

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OkurtProject.API.Model;
using OkurtProject.Contract;

namespace OkurtProject.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {
        private readonly ILogger<ExampleController> _logger;

        public ExampleController(ILogger<ExampleController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExampleCommand request)
        {
            var bus = BusConfigurator.ConfigureBus();

            var sendToUri = new Uri($"{RabbitMqConsts.RabbitMqUri}{RabbitMqConsts.ExampleQueueName}");
            var endPoint = await bus.GetSendEndpoint(sendToUri);

            await endPoint.Send<IExampleCommand>(new
            {
                Name = request.Name,
                Surname = request.Surname
            });

            return Ok("Success");
        }
    }
}
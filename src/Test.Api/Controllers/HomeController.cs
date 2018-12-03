using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using System.Threading.Tasks;
using Test.Common.Commands;

namespace Test.Api.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        #region Members

        private readonly IBusClient _busClient;

        #endregion Members

        #region Ctor

        public HomeController(IBusClient busClient)
        {
            _busClient = busClient;
        }

        #endregion Ctor

        #region Methods

        public IActionResult Get() => Content("Hello Api!");

        [HttpPost("turn")]
        public async Task<IActionResult> TurnCommand([FromBody] Turn command)
        {
            await _busClient.PublishAsync(command);

            return Accepted($"Requested execution of turn command {(command.Clockwise ? "clockwise" : "anticlockwise")}");
        }

        [HttpDelete("move")]
        public async Task<IActionResult> MoveCommand([FromBody] Move command)
        {
            await _busClient.PublishAsync(command);

            return Accepted("Requested execution of move forward command ");
        }

        #endregion Methods
    }
}
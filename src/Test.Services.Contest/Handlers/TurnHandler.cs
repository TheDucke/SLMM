using Microsoft.Extensions.Logging;
using RawRabbit;
using System.Threading.Tasks;
using Test.Common.Commands;
using Test.Common.Events;
using Test.Common.Exceptions;
using Test.Services.SLMM.Services;

namespace Test.Services.SLMM.Handlers
{
    public class TurnHandler : ICommandHandler<Turn>
    {
        #region Members

        private readonly IBusClient _busClient;
        private readonly IService _service;
        private readonly ILogger<TurnHandler> _logger;

        #endregion Members

        #region Ctor

        public TurnHandler(IBusClient busClient, IService service, ILogger<TurnHandler> logger)
        {
            _busClient = busClient;
            _service = service;
            _logger = logger;
        }

        #endregion Ctor

        #region Methods

        public async Task HandleAsync(Turn command)
        {
            _logger.LogInformation("Turning SLMM");

            try
            {
                await _service.TurnAsync(command.Clockwise);

                var currentPosition = await _service.GetCurrentPositionAsync();

                await _busClient.PublishAsync(new Turned(currentPosition));
            }
            catch (TestException ex)
            {
                await _busClient.PublishAsync(new CommandFailed(ex.Message));

                _logger.LogError(ex.Message);
            }
        }

        #endregion Methods
    }
}
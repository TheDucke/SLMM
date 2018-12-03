using Microsoft.Extensions.Logging;
using RawRabbit;
using System.Threading.Tasks;
using Test.Common.Commands;
using Test.Common.Events;
using Test.Common.Exceptions;
using Test.Services.SLMM.Services;

namespace Test.Services.SLMM.Handlers
{
    public class MoveHandler : ICommandHandler<Move>
    {
        #region Members

        private readonly IBusClient _busClient;
        private readonly IService _service;
        private readonly ILogger<MoveHandler> _logger;

        #endregion Members

        #region Ctor

        public MoveHandler(IBusClient busClient, IService service, ILogger<MoveHandler> logger)
        {
            _busClient = busClient;
            _service = service;
            _logger = logger;
        }

        #endregion Ctor

        #region Methods

        public async Task HandleAsync(Move command)
        {
            _logger.LogInformation("Moving SLMM");

            try
            {
                await _service.MoveAsync();

                var currentPosition = await _service.GetCurrentPositionAsync();

                await _busClient.PublishAsync(new Moved(currentPosition));
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
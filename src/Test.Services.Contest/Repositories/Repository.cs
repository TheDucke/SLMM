using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Test.Common.Domain;

namespace Test.Services.SLMM.Repositories
{
    public class Repository : IRepository
    {
        #region Members

        private readonly Common.Domain.SLMM Slmm;

        #endregion Members

        #region Ctor

        public Repository(IConfiguration configuration)
        {
            var options = new SLMMOptions();
            var section = configuration.GetSection("slmm");
            section.Bind(options);

            Slmm = new Common.Domain.SLMM(options.Dimension, options.Position);
        }

        #endregion Ctor

        #region Methods

        public Task<Position> GetCurrentPositionAsync()
        {
            return new Task<Position>(() => Slmm.CurrentPosition);
        }

        public async Task MoveAsync()
        {
            await new Task(() => { System.Threading.Thread.Sleep(5000); });

            Slmm.Move();
        }

        public async Task TurnAsync(bool clockWise)
        {
            await new Task(() => { System.Threading.Thread.Sleep(2000); });

            Slmm.Turn(clockWise);
        }

        #endregion Methods
    }
}
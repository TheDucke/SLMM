using System.Threading.Tasks;
using Test.Common.Domain;
using Test.Services.SLMM.Repositories;

namespace Test.Services.SLMM.Services
{
    public class Service : IService
    {
        #region Members

        private readonly IRepository _repository;

        #endregion Members

        #region Ctor

        public Service(IRepository repository)
        {
            _repository = repository;
        }

        #endregion Ctor

        #region Methods

        public async Task TurnAsync(bool clockwise)
        {
            await _repository.TurnAsync(clockwise);
        }

        public async Task MoveAsync()
        {
            await _repository.MoveAsync();
        }

        public async Task<Position> GetCurrentPositionAsync()
        {
            return await _repository.GetCurrentPositionAsync();
        }

        #endregion Methods
    }
}
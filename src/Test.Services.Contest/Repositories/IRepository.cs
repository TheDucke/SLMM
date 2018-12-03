using System.Threading.Tasks;
using Test.Common.Domain;

namespace Test.Services.SLMM.Repositories
{
    public interface IRepository
    {
        Task<Position> GetCurrentPositionAsync();

        Task MoveAsync();

        Task TurnAsync(bool clockWise);
    }
}
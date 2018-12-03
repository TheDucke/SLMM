using System.Threading.Tasks;
using Test.Common.Domain;

namespace Test.Services.SLMM.Services
{
    public interface IService
    {
        Task TurnAsync(bool clockwise);

        Task MoveAsync();

        Task<Position> GetCurrentPositionAsync();
    }
}
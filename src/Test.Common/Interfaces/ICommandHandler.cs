using System.Threading.Tasks;
using Test.Common.Interfaces;

namespace Test.Common.Commands
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}
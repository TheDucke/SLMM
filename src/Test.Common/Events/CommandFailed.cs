using Test.Common.Interfaces;

namespace Test.Common.Events
{
    public class CommandFailed : IEvent
    {
        #region Ctor

        public CommandFailed(string message)
        {
            Message = message;
        }

        #endregion Ctor

        #region Properties

        public string Message { get; }

        #endregion Properties
    }
}
using Test.Common.Domain;
using Test.Common.Interfaces;

namespace Test.Common.Events
{
    public class Turned : IEvent
    {
        #region Ctor

        public Turned(Position currentPosition)
        {
            CurrentPosition = currentPosition;
        }

        #endregion Ctor

        #region Properties

        public Position CurrentPosition { get; }

        #endregion Properties
    }
}
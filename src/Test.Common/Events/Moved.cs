using Test.Common.Domain;
using Test.Common.Interfaces;

namespace Test.Common.Events
{
    public class Moved : IEvent
    {
        #region Ctor

        public Moved(Position currentPosition)
        {
            CurrentPosition = currentPosition;
        }

        #endregion Ctor

        #region Properties

        public Position CurrentPosition { get; }

        #endregion Properties
    }
}
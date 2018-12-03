using ICommand = Test.Common.Interfaces.ICommand;

namespace Test.Common.Commands
{
    public class Turn : ICommand
    {
        #region Properties

        public bool Clockwise { get; set; }

        #endregion Properties
    }
}
namespace Test.Common.Domain
{
    public class SLMM
    {
        #region Members

        private const int Gridcells = 10;
        private readonly double _minimunXMovement;
        private readonly double _minimunYMovement;

        #endregion Members

        #region Ctor

        public SLMM(Dimension dimension, Position position)
        {
            CurrentDimension = dimension;
            CurrentPosition = position;

            _minimunYMovement = (double)CurrentDimension.Length / Gridcells;
            _minimunXMovement = (double)CurrentDimension.Width / Gridcells;
        }

        #endregion Ctor


        #region Properties

        public Dimension CurrentDimension { get; private set; }

        public Position CurrentPosition { get; private set; }

        #endregion Properties

        #region Methods

        public void Turn(bool clockwise)
        {
            if (clockwise)
            {
                switch (CurrentPosition.Orientation)
                {
                    case Orientations.North:
                        CurrentPosition.Orientation = Orientations.East;
                        break;

                    case Orientations.East:
                        CurrentPosition.Orientation = Orientations.South;
                        break;

                    case Orientations.South:
                        CurrentPosition.Orientation = Orientations.West;
                        break;

                    case Orientations.West:
                        CurrentPosition.Orientation = Orientations.North;
                        break;
                }
            }
            else
            {
                switch (CurrentPosition.Orientation)
                {
                    case Orientations.North:
                        CurrentPosition.Orientation = Orientations.West;
                        break;

                    case Orientations.East:
                        CurrentPosition.Orientation = Orientations.North;
                        break;

                    case Orientations.South:
                        CurrentPosition.Orientation = Orientations.East;
                        break;

                    case Orientations.West:
                        CurrentPosition.Orientation = Orientations.South;
                        break;
                }
            }
        }

        public void Move()
        {
            switch (CurrentPosition.Orientation)
            {
                case Orientations.North:
                    if (CurrentPosition.Y - _minimunYMovement > 0)
                        CurrentPosition.Y -= _minimunYMovement; 
                    break;
                case Orientations.East:
                    if (CurrentPosition.X + _minimunYMovement < CurrentDimension.Length)
                        CurrentPosition.X += _minimunYMovement;
                    break;
                case Orientations.South:
                    if (CurrentPosition.Y + _minimunYMovement < CurrentDimension.Length)
                        CurrentPosition.Y += _minimunYMovement;
                    break;

                case Orientations.West:
                    if (CurrentPosition.X - _minimunXMovement > 0)
                        CurrentPosition.X -= _minimunXMovement;
                    break;
            }
        }

        #endregion Methods
    }
}
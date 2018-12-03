namespace Test.Common.Domain
{
    public class Position
    {
        #region Ctor

        protected Position()
        {
        }

        #endregion Ctor

        #region Properties

        public double X { get; set; }

        public double Y { get; set; }

        public Orientations Orientation { get; set; }

        #endregion Properties
    }

    public enum Orientations
    {
        North,
        East,
        South,
        West
    }
}
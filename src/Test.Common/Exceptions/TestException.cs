using System;

namespace Test.Common.Exceptions
{
    public class TestException : Exception
    {
        public string Code { get; }

        public TestException()
        {
        }

        public TestException(string code)
        {
            Code = code;
        }

        public TestException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        public TestException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        public TestException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
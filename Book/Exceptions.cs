using System;
using System.Collections.Generic;
using System.Text;

namespace Book
{
    public class Exceptions
    {

        public class InvalidAuthorException : Exception
        {
            public InvalidAuthorException() { }
            public InvalidAuthorException(string message) : base(message) { }
            public InvalidAuthorException(string message, Exception inner) : base(message, inner) { }
            protected InvalidAuthorException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }

        public class InvalidBookException : Exception
        {
            public InvalidBookException() { }
            public InvalidBookException(string message) : base(message) { }
            public InvalidBookException(string message, Exception inner) : base(message, inner) { }
            protected InvalidBookException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
    }
}

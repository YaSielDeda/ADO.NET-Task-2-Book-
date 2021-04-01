using System;
using System.Collections.Generic;
using System.Text;

namespace Book
{
    class Exceptions
    {

        [Serializable]
        public class LackOfData : Exception
        {
            public LackOfData() { }
            public LackOfData(string message) : base(message) { }
            public LackOfData(string message, Exception inner) : base(message, inner) { }
            protected LackOfData(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
    }
}

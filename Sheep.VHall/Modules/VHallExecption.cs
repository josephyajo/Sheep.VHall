using System;
using System.Runtime.Serialization;

namespace Sheep.VHall.Modules
{
    [Serializable]
    public class VHallException : Exception
    {
        public VHallException()
        {
        }

        public VHallException(string message) : base(message)
        {
        }

        protected VHallException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public VHallException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}

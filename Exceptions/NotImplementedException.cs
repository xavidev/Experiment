using System;
using System.Runtime.Serialization;

public class NotImplementedException : Exception
{
    public NotImplementedException()
    {
    }

    public NotImplementedException(string message) : base(message)
    {
    }

    public NotImplementedException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected NotImplementedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
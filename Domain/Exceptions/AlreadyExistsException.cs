using System.Runtime.Serialization;

namespace Domain.Exceptions;

/// <summary>
/// Exception which raises when we try to add an already existing item
/// </summary>
[Serializable]
public class AlreadyExistsException : Exception
{
    protected AlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public AlreadyExistsException() : base("Already exists")
    {
        
    }
}
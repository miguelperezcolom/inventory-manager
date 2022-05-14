namespace Domain.Exceptions;

public class AlreadyExistsException : Exception
{
    public AlreadyExistsException() : base("Already exists")
    {
        
    }
}
using System;

namespace StoreBackend.Exceptions;

public class ResourceNotFoundException:Exception
{
    public ResourceNotFoundException() : base("Resource not found")
    {
    }

    public ResourceNotFoundException(String message): base(message)
    {
    }
}

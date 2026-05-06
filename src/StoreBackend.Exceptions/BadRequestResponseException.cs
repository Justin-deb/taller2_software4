using System;

namespace StoreBackend.Exceptions;

public class BadRequestResponseException : Exception
{
    public BadRequestResponseException() : base("Invalid Request") { }
    public BadRequestResponseException(string message) : base(message) { }
}

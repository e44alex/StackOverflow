namespace StackOverflow.Common.Services;

public interface IEchoClient
{
    Task<string?> Echo(string message);
}
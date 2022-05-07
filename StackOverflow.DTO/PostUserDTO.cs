namespace StackOverflow.DTO;

public static class PostUserDTO
{
    public record Request(string Username, string Password, string Name, string Email, int Id, string Bio);

    public record Response(string Username, string Password, string Name, string Email, int Id, string Bio);
}

public static class PutUserDTO
{
    public record Request(string Username, string Password, string Name, string Email, int Id, string Bio);

    public record Response(string Username, string Password, string Name, string Email, int Id, string Bio);
}
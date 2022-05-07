namespace StackOverflow.DTO;

public static class GetAnswerDTO
{
    public record Request(Guid questionId);

    public record Response();
}

public static class PostAnswerDTO
{
    public record Request(Guid questionId, string Body, DateTime DateCreated, string Creator);

    public record Response(bool Success);
}

public static class PutAnswerDTO
{
    public record Request(Guid answerId, string Body, DateTime DateCreated, string Creator);

    public record Response(bool Success);
}

public static class DeleteAnswerDTO
{
    public record Request(Guid answerId);

    public record Response(bool Success);
}
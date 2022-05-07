namespace StackOverflow.DTO;

public static class QuestionDTO
{
    public record Request(Guid QuestionId);

    public record Response(Guid Id, string Topic, string Body, bool Opened, DateTime DateCreated, DateTime LastActivity, string Creator);
}

public static class PostQuestionDTO
{
    public record Request(string Topic, string Body, bool Opened, DateTime DateCreated, DateTime LastActivity, string Creator);

    public record Response(bool Success);
}

public static class PutQuestionDTO
{
    public record Request(Guid QuestionId, string Topic, string Body, bool Opened, DateTime DateCreated, DateTime LastActivity, string Creator);

    public record Response(bool Success);
}

public static class DeleteQuestionDTO
{
    public record Request(Guid QuestionId);

    public record Response(bool Success);
}
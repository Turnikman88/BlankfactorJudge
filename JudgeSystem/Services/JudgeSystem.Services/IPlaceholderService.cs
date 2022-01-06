namespace JudgeSystem.Services
{
    public interface IPlaceholderService
    {
        bool IsPlaceholderMissing(string code);
        string ReplacePlaceholders(string code, string start, string method);
    }
}
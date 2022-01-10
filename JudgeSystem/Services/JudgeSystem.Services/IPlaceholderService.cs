namespace JudgeSystem.Services
{
    public interface IPlaceholderService
    {
        string GetPlacholderErrorMessage(string code);
        string ReplacePlaceholders(string code, string start, string method);
    }
}

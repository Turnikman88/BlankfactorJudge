namespace JudgeSystem.Executors
{
    public interface ISqlConnectorService
    {
        bool Execute(string sql);
    }
}
using JudgeSystem.Workers.Common;

namespace JudgeSystem.Executors
{
    public interface ISqlConnectorService
    {
        SqlWorkerResult Check(string sql);

        SqlExecutionResult Execute(string sql);
    }
}

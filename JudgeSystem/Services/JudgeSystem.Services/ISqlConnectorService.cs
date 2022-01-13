using JudgeSystem.Workers.Common;
using System.Collections.Generic;

namespace JudgeSystem.Executors
{
    public interface ISqlConnectorService
    {
        SqlWorkerResult Check(string sql);

        SqlExecutionResult Execute(List<string> args);

        SqlExecutionResult ExecuteView(List<string> args);
    }
}

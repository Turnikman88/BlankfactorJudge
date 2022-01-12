using System;
using System.Collections.Generic;
using System.Text;

namespace JudgeSystem.Workers.Common
{
    public class SqlCheckerResult : SqlExecutionResult
    {
        public SqlCheckerResult(SqlExecutionResult executionResult)
        {
            Output = executionResult.Output;
            Error = executionResult.Error;
            Type = executionResult.Type;
        }
        public bool IsCorrect { get; set; }
    }
}

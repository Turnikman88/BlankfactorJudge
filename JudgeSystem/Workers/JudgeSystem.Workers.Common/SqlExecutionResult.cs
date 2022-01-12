using System;
using System.Collections.Generic;
using System.Text;

namespace JudgeSystem.Workers.Common
{
    public class SqlExecutionResult
    {
        public SqlExecutionResult()
        {
            Output = string.Empty;
            Error = string.Empty;
            ExitCode = 0;
            Type = ProcessExecutionResultType.Success;
        }

        public string Output { get; set; }

        public string Error { get; set; }

        public bool IsSuccesfull => string.IsNullOrEmpty(Error);

        public int ExitCode { get; set; }

        public ProcessExecutionResultType Type { get; set; }

    }
}

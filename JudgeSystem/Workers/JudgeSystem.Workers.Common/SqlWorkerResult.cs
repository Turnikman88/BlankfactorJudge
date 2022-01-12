using System;
using System.Collections.Generic;
using System.Text;

namespace JudgeSystem.Workers.Common
{
    public class SqlWorkerResult
    {
        public SqlWorkerResult()
        {

        }

        public SqlWorkerResult(string errors)
        {
            Errors = errors;
        }

        public string Errors { get; private set; }

        public bool IsCompiledSuccessfully => string.IsNullOrEmpty(Errors);
    }
}

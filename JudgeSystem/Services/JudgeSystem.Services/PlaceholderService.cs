using JudgeSystem.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace JudgeSystem.Services
{
    public class PlaceholderService : IPlaceholderService
    {
        public string ReplacePlaceholders(string code, string start, string method)
        {
            string modifiedCode = code.Insert(0, GlobalConstants.Usings)
                .Replace(GlobalConstants.StartPlaceholder, start)
                .Replace(GlobalConstants.MethodPlaceholder, method);

            return modifiedCode;
        }
        public bool IsPlaceholderMissing(string code)
        {
            return !(code.Contains(GlobalConstants.StartPlaceholder) && code.Contains(GlobalConstants.MethodPlaceholder));
        }
    }
}

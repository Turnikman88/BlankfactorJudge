using JudgeSystem.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

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
        public string GetPlacholderErrorMessage(string code)
        {
            if (!(code.Contains(GlobalConstants.StartPlaceholder) && code.Contains(GlobalConstants.MethodPlaceholder)))
            {
                return ErrorMessages.PlaceholderModifiedMessage;
            }

            var reg = new Regex(@"[\t\n\r\s+]");
            string temp = reg.Replace(code, "");

            if (!(temp.Contains(GlobalConstants.StartPlaceholder + "}") && temp.Contains(GlobalConstants.MethodPlaceholder + "}")))
            {
                return ErrorMessages.PlaceholderMovedMessage;
            }

            return null;
        }
    }
}

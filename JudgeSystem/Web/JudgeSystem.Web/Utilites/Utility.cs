using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using JudgeSystem.Data.Models.Enums;
using JudgeSystem.Web.Infrastructure.Extensions;
using JudgeSystem.Workers.Common;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JudgeSystem.Web.Utilites
{
    public static class Utility
    {
        public static IEnumerable<SelectListItem> GetSelectListItems<T>(bool useDisplayNameAttributes = false) where T : Enum
        {
            var values = EnumExtensions.GetEnumValuesAsString<T>().ToList();
            var texts = EnumExtensions.GetEnumDisplayNames<T>().ToList();
            for (int i = 0; i < values.Count; i++)
            {
                yield return new SelectListItem
                {
                    Text = useDisplayNameAttributes ? texts[i] : values[i],
                    Value = values[i]
                };
            }
        }

        public static IEnumerable<SelectListItem> GetFormatedSelectListItems<T>()
        {
            var items = EnumExtensions.GetEnumValuesAsString<T>()
                .Select(t => new SelectListItem
                {
                    Value = t,
                    Text = t.InsertSpaceBeforeUppercaseLetter()
                })
                .ToList();
            return items;
        }

        public static List<string> GetSelectListOfProgrammingLangugages()
        {
            var items = new List<string>();

            foreach (object programmingLanguageObject in Enum.GetValues(typeof(ProgrammingLanguage)))
            {
                var programmingLanguage = (ProgrammingLanguage)programmingLanguageObject;
                switch (programmingLanguage)
                {
                    case ProgrammingLanguage.CSharp:
                        items.Add("C# code");
                        break;

                    case ProgrammingLanguage.Java:
                        items.Add("Java code");
                        break;

                    case ProgrammingLanguage.CPlusPlus:
                        items.Add("C++ code");
                        break;
                }
            }
            return items;
        }

        public static List<string> GetSelectListOfDbLangugages()
        {
            var items = new List<string>();
            foreach (object dbLanguageObject in Enum.GetValues(typeof(ProgrammingLanguage)))
            {
                var programmingLanguage = (ProgrammingLanguage)dbLanguageObject;
                
                switch (programmingLanguage)
                {                    
                    case ProgrammingLanguage.MsSQL:
                        items.Add("MsSQL code");
                        break;
                }
            }
            return items;
        }

        public static string GetLessonName(string lessonBaseName, LessonType lessonType)
        {
            if (lessonType != LessonType.Exam)
            {
                return lessonBaseName + " - " + lessonType.ToString();
            }
            return lessonBaseName;
        }

        public static string ExtractModelStateErrors(ModelStateDictionary modelState, string separator)
        {
            IEnumerable<string> errors = modelState.Select(x => x.Value).SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
            return string.Join(separator, errors);
        }

        public static string GetBaseUrl(HttpContext httpContext) => $"{httpContext.Request.Scheme}://{httpContext.Request.Host.ToUriComponent()}";

        public static IEnumerable<string> ValidateObject(object obj)
        {
            var validationContext = new ValidationContext(obj);
            ICollection<ValidationResult> results = new List<ValidationResult>(); // Will contain the results of the validation
            Validator.TryValidateObject(obj, validationContext, results, true);
            foreach (ValidationResult result in results)
            {
                yield return result.ErrorMessage;
            }
        }
    }
}

using JudgeSystem.Services.Mapping;
using System.Collections.Generic;

namespace JudgeSystem.Web.Dtos.Problem
{
    public class ProblemConstraintsDto : IMapFrom<Data.Models.Problem>
    {
        public int AllowedTimeInMilliseconds { get; set; }

        public double AllowedMemoryInMegaBytes { get; set; }

        public bool IsSqlTask { get; set; }

        public List<string> SqlCodeItem { get; set; }

        public List<string> ProgLangItem { get; set; }
    }
}

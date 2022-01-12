﻿using System.ComponentModel.DataAnnotations;

using JudgeSystem.Data.Models.Enums;
using JudgeSystem.Services.Mapping;
using static JudgeSystem.Common.ModelConstants;
using static JudgeSystem.Common.GlobalConstants;

namespace JudgeSystem.Web.InputModels.Problem
{
    public class ProblemInputModel : IMapTo<Data.Models.Problem>
	{
        public ProblemInputModel()
        {
            AllowedMemoryInMegaBytes = DefaultAllowedMemoryInMegaBytes;
            AllowedTimeInMilliseconds = DefaultAllowedTimeInMilliseconds;
            MaxPoints = DefaultMaxPoints;
            TimeIntervalBetweenSubmissionInSeconds = DefaultTimeIntervalBetweenSubmissionInSeconds;
        }

        [Required]
        [StringLength(ProblemNameMaxLength, MinimumLength = ProblemNameMinLength)]
        public string Name { get; set; }

        [Range(OrderByMinValue, OrderByMaxValue)]
        public int OrderBy { get; set; }

        [Display(Name = ProblemIsExtraTaskDisplayName)]
        public bool IsExtraTask { get; set; }

        [Range(ProblemMinPoints, ProblemMaxPoints)]
        [Display(Name = ProblemMaxPointsDisplayName)]
        public int MaxPoints { get; set; }


        [Range(MinAllowedTimeInMilliseconds, MaxAllowedTimeInMilliseconds)]
        [Display(Name = ProblemAllowedTimeInMillisecondsDisplayName)]
        public int AllowedTimeInMilliseconds { get; set; }

        [Range(MinAllowedMemoryInMegaBytes, MaxAllowedMemoryInMegaBytes)]
        [Display(Name = ProblemAllowedMemoryInMegaBytesDisplayName)]
        public double AllowedMemoryInMegaBytes { get; set; }

        [Range(ProblemMinTimeIntervalBetweenSubmissionInSeconds, ProblemMaxTimeIntervalBetweenSubmissionInSeconds)]
        [Display(Name = ProblemTimeIntervalBetweenSubmissionInSecondsDisplayName)]
        public int TimeIntervalBetweenSubmissionInSeconds { get; set; }

        [Range(ProblemAllowedMinCodeDifferenceInPercentageMinValue, ProblemAllowedMinCodeDifferenceInPercentageMaxValue)]
        [Display(Name = ProblemAllowedMinCodeDifferenceInPercentageDisplayName)]
        public int AllowedMinCodeDifferenceInPercentage { get; set; }

        public int LessonId { get; set; }

        [Display(Name = ProblemSubmissionTypeDisplayName)]
        public SubmissionType SubmissionType { get; set; }

        [Display(Name = ProblemTestingStrategyDisplayName)]
        public TestingStrategy TestingStrategy { get; set; }

        [Display(Name = HasPlaceholderDisplayName)]
        public bool HasPlaceholder { get; set; }

        [Display(Name = StartPlaceholderDisplayName)]
        [StringLength(3000, MinimumLength = 3)]
        public string StartPlaceholder { get; set; }

        [Display(Name = MethodPlaceholderDisplayName)]
        [StringLength(30000, MinimumLength = 10)]
        public string MethodPlaceholder { get; set; }

        public bool IsSqlTask { get; set; }

        /*[StringLength(200, MinimumLength = 5)]
        [Display(Name = SqlProcedureDisplayName)]

        public string SqlProcedureName { get; set; }*/
    }
}

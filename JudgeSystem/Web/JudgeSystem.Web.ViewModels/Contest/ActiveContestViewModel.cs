using System;

using JudgeSystem.Services.Mapping;

using AutoMapper;

namespace JudgeSystem.Web.ViewModels.Contest
{
    public class ActiveContestViewModel : IMapFrom<Data.Models.Contest>
	{
		public string Name { get; set; }

		public int Id { get; set; }

		public int LessonId { get; set; }

		public DateTime EndTime { get; set; }

        [IgnoreMap] //net6change
        public int RemainingDays => (EndTime - DateTime.Now).Days;

        [IgnoreMap] //net6change
        public int RemainingHours => (EndTime - DateTime.Now).Hours;

        [IgnoreMap] //net6change
        public int RemainingMinutes => (EndTime - DateTime.Now).Minutes;
	}
}

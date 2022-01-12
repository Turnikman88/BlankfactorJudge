using System.Threading.Tasks;

using JudgeSystem.Services.Data;
using JudgeSystem.Web.Dtos.Problem;
using JudgeSystem.Web.Filters;
using JudgeSystem.Web.Utilites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JudgeSystem.Web.Controllers
{
    [Authorize]
    public class ProblemController : BaseController
	{
        private readonly IProblemService problemService;

        public ProblemController(IProblemService problemService)
		{
            this.problemService = problemService;
        }

        [EndpointExceptionFilter]
        public async Task<IActionResult> Get(int id)
        {
            ProblemConstraintsDto problem = await problemService.GetById<ProblemConstraintsDto>(id);
            if (problem.IsSqlTask)
            {
                problem.SqlCodeItem = Utility.GetSelectListOfDbLangugages();
            }

            return Ok(problem);
        }
	}
}

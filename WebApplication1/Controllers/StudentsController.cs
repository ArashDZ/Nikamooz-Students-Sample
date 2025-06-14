using Microsoft.AspNetCore.Mvc;
using SampleApp.Core.RequestResponse.Students;
using Zamin.EndPoints.Web.Controllers;

namespace SampleApp.Endpoints.Api.Controllers
{
    [Route("students")]
    public class StudentsController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] StudentFilterModel filter)
        {
            return await Query<StudentFilterModel, List<StudentListModel>>(filter);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var query = new StudentGetByIdModel { Id = id };
            return await Query<StudentGetByIdModel, StudentViewModel>(query);
        }

    }
}

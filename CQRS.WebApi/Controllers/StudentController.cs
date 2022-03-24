using CQRS.WebApi.Context;
using CQRS.WebApi.Features.StudentFeatures.Commands;
using CQRS.WebApi.Features.StudentFeatures.Queries;
using CQRS.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.WebApi.Controllers
{
    namespace EFCore.CodeFirst.WebApi.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class StudentController : ControllerBase
        {
            private IMediator _mediator;

            //protected IMediator Mediator => _mediator;// ??= HttpContext.RequestServices.GetService<IMediator>();
            public StudentController(IMediator mediator)
            {
                _mediator = mediator;
            }

            [HttpPost]
            public async Task<IActionResult> Create(CreateStudentCommand command)
            {
                return Ok(await _mediator.Send(command));
            }
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                return Ok(await _mediator.Send(new GetAllStudentsQuery()));
            }
            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                return Ok(await _mediator.Send(new GetStudentByIdQuery { Id = id }));
            }
            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                return Ok(await _mediator.Send(new DeleteStudentByIdCommand { Id = id }));
            }
            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, UpdateStudentCommand command)
            {
                if (id != command.Id)
                {
                    return BadRequest();
                }
                return Ok(await _mediator.Send(command));
            }
        }
    }
}

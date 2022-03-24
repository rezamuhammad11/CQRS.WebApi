using CQRS.WebApi.Context;
using CQRS.WebApi.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.WebApi.Features.StudentFeatures.Commands
{
    public class CreateStudentCommand : IRequest<int>
    {
        public int Age { get; set; }
        public int Roll { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }
        public string Section { get; set; }
        public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateStudentCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
            {
                var student = new Student();
                student.Name = command.Name;
                student.Age = command.Age;
                student.Roll = command.Roll;
                student.Class = command.Class;
                student.Section = command.Section;
                _context.Students.Add(student);
                await _context.SaveChanges();
                return student.Id;
            }
        }
    }
}

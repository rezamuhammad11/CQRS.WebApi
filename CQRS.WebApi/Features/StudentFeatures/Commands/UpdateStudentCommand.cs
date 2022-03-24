using CQRS.WebApi.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.WebApi.Features.StudentFeatures.Commands
{
    public class UpdateStudentCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public int Roll { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }
        public string Section { get; set; }
        public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateStudentCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
            {
                var student = _context.Students.Where(a => a.Id == command.Id).FirstOrDefault();

                if (student == null)
                {
                    return default;
                }
                else
                {
                    student.Name = command.Name;
                    student.Roll = command.Roll;
                    student.Class = command.Class;
                    student.Age = command.Age;
                    student.Section = command.Section;
                    await _context.SaveChanges();
                    return student.Id;
                }
            }
        }
    }
}

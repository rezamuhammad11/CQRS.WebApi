using CQRS.WebApi.Context;
using CQRS.WebApi.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.WebApi.Features.StudentFeatures.Queries
{
    public class GetStudentByIdQuery : IRequest<Student>
    {
        public int Id { get; set; }
        public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Student>
        {
            private readonly IApplicationDbContext _context;
            public GetStudentByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Student> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken)
            {
                var product = _context.Students.Where(a => a.Id == query.Id).FirstOrDefault();
                if (product == null) return null;
                return product;
            }
        }
    }
}

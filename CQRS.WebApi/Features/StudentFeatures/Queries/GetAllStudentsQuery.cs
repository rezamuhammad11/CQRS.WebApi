using CQRS.WebApi.Context;
using CQRS.WebApi.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.WebApi.Features.StudentFeatures.Queries
{
    public class GetAllStudentsQuery : IRequest<IEnumerable<Student>>
    {
        public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<Student>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllStudentsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Student>> Handle(GetAllStudentsQuery query, CancellationToken cancellationToken)
            {
                var productList = await _context.Students.ToListAsync();
                if (productList == null)
                {
                    return null;
                }
                return productList.AsReadOnly();
            }
        }
    }
}

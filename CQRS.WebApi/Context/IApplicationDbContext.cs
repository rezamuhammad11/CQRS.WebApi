using CQRS.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CQRS.WebApi.Context
{
    public interface IApplicationDbContext
    {
        DbSet<Student> Students { get; set; }

        Task<int> SaveChanges();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesLearn.Models;

namespace RazorPagesLearn.Data
{
    public class RazorPagesLearnContext : DbContext
    {
        public RazorPagesLearnContext (DbContextOptions<RazorPagesLearnContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesLearn.Models.TodoTask> Task => Set<TodoTask>();

        public DbSet<RazorPagesLearn.Models.Customer> Customer => Set<Customer>();
    }
}

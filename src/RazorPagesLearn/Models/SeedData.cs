using Microsoft.EntityFrameworkCore;
using RazorPagesLearn.Data;

namespace RazorPagesLearn.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesLearnContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesLearnContext>>()))
            {
                if (context == null || context.Task == null || context.Customer == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                if (context.Task.Any() && context.Customer.Any())
                {
                    return; // DB has been seeded
                }

                context.Task.AddRange(
                    new TodoTask
                    {
                        Title = "Some Problem with Connection",
                        Description = "Some user cant use telecom",
                        CreateDate = DateTime.Now
                    }
                    );

                context.Customer.AddRange(
                    new Customer
                    {
                        UserName = "Johnny",
                        Email = "some@gmail.com",
                        Password = "123456AaAa",
                    }
                    );

                context.SaveChanges();
            }
        }
    }
}

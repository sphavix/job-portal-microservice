
using Portal.Domain.Entities;
using Portal.Infrastructure.Persistance;

namespace Portal.Infrastructure.SeedData
{
    public class PortalDataSeeder(PortalDbContext context) : IPortalDataSeeder
    {
        public async Task SeedData()
        {
            if(await context.Database.CanConnectAsync())
            {
                if(!context.Categories.Any())
                {
                    var categories = GetCategories();
                    context.Categories.AddRange(categories);
                    await context.SaveChangesAsync();
                }
            }
        }

        private List<Category> GetCategories()
        {
            List<Category> categories = [
                new() 
                {
                    CategoryName = "Information Technology",
                    Vacancies =
                    [
                        new()
                        {
                            Title = "Software Engineer",
                            Description = "Software Engineer responsibilities include gathering user requirements, defining system functionality and writing code in various languages, like Java, Ruby on Rails or .NET programming languages (e.g. C++ or JScript.NET.)",
                            RequiredSkills = "Execute full software development life cycle (SDLC), Develop flowcharts, layouts and documentation to identify requirements and solutions, Write well-designed, testable code"
                        },
                        new()
                        {
                            Title = "Data Engineer",
                            Description = "We are looking for an experienced data engineer to join our team. You will use various methods to transform raw data into useful data systems.",
                            RequiredSkills = "Analyze and organize raw data, Build data systems and pipelines, Evaluate business needs and objectives, Prepare data for prescriptive and predictive modeling"
                        }
                    ]
                },
                new()
                {
                    CategoryName = "Accounting",
                    Vacancies = 
                    [
                        new()
                        {
                            Title = "Trainee CA",
                            Description = "",
                            RequiredSkills = ""
                        }
                    ]
                }
            ];
            return categories;
        }
    }
}
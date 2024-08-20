
namespace Portal.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }
    }
}
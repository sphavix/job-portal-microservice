
namespace Portal.Domain.Entities
{
    public class Vacancy
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ContractType { get; set; }
        public string RequiredSkills { get; set; }
        
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        // https://spacelift.io/blog/ansible-kubernetes
    }
}
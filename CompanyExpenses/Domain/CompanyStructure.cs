using CompanyExpenses.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyExpenses.Domain
{
    public class CompanyStructure : ITree<CompanyStructure>  
    {
        [MaxLength(36)]
        public required string Id { get; set; }

        [MaxLength(36)]
        public string? ParentId { get; set; }

        [MaxLength(150)]
        public string? Name { get; set; }

        [NotMapped]
        public List<CompanyStructure> Children { get; set; } = [];

        [NotMapped]
        public bool Expanded { get; set; }
    }
}

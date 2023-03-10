using Api.Domain.Entities.Identity;

namespace Api.Domain.Entities;

public class Customer : BaseEntity
{
    public AppUser AppUser { get; set; } = null!;

    public ICollection<Sale> Sales { get; set; } = new List<Sale>();
}

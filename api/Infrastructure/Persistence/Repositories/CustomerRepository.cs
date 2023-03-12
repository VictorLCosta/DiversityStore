using Api.Application.Common.Interfaces.Repositories;
using Api.Domain.Entities;

namespace Api.Infrastructure.Persistence.Repositories;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(ApplicationDbContext context) 
        : base(context)
    {
    }
}

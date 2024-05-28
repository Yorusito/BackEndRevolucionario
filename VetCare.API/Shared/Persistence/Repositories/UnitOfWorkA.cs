using VetCare.API.Advice.Domain.Repositories;
using VetCare.API.Shared.Persistence.Contexts;

namespace VetCare.API.Shared.Persistence.Repositories;

public class UnitOfWorkA : IUnitOfWorkA
{
    private readonly AppDbContext _context;

    public UnitOfWorkA(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}
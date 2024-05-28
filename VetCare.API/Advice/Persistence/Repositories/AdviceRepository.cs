using Microsoft.EntityFrameworkCore;
using VetCare.API.Advice.Domain.Repositories;
using VetCare.API.Shared.Persistence.Contexts;
using VetCare.API.Shared.Persistence.Repositories;

namespace VetCare.API.Advice.Persistence.Repositories;

public class AdviceRepository : BaseRepository, IAdviceRepository
{
    public AdviceRepository(AppDbContext context) : base(context)
    {
        
    }

    public async Task<IEnumerable<Domain.Models.Advice>> ListAsync()
    {
        return await _context.Advices
            .ToListAsync();
    }

    public async Task AddAsync(Domain.Models.Advice advice)
    {
        await _context.Advices.AddAsync(advice);
    }

    public async Task<Domain.Models.Advice> FindByIdAsync(int adviceId)
    {
        return await _context.Advices
            .FirstOrDefaultAsync(p => p.Id == adviceId);
    }

    public void Update(Domain.Models.Advice advice)
    {
        _context.Advices.Update(advice);
    }

    public void Remove(Domain.Models.Advice advice)
    {
        _context.Advices.Remove(advice);
    }
    
}
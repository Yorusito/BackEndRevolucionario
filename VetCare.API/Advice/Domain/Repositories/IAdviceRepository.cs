using VetCare.API.Advice.Domain.Models;

namespace VetCare.API.Advice.Domain.Repositories;


public interface IAdviceRepository
{
    Task<IEnumerable<Models.Advice>> ListAsync();

    Task AddAsync(Models.Advice advice);

    Task<Models.Advice> FindByIdAsync(int adviceId);

    void Update(Models.Advice advice);

    void Remove(Models.Advice advice);


}
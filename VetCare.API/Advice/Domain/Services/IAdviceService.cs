using VetCare.API.Advice.Domain.Services.Communication;

namespace VetCare.API.Advice.Domain.Services;

public interface IAdviceService
{
    Task<IEnumerable<Models.Advice>> ListAsync();

    Task<AdviceResponse> SaveAsync(Models.Advice advice);

    Task<AdviceResponse> UpdateAsync(int adviceId, Models.Advice advice);

    Task<AdviceResponse> DeleteAsync(int adviceId);

}
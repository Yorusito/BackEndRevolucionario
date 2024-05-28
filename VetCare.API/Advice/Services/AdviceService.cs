using VetCare.API.Advice.Domain.Repositories;
using VetCare.API.Advice.Domain.Services;
using VetCare.API.Advice.Domain.Services.Communication;

namespace VetCare.API.Advice.Services;

public class AdviceService : IAdviceService
{
    private readonly IAdviceRepository _adviceRepository;
    private readonly IUnitOfWorkA _unitOfWorkA;

    public AdviceService(IAdviceRepository adviceRepository, IUnitOfWorkA unitOfWorkA)
    {
        _adviceRepository = adviceRepository;
        _unitOfWorkA = unitOfWorkA;
    }

    public async Task<IEnumerable<Domain.Models.Advice>> ListAsync()
    {
        return await _adviceRepository.ListAsync();
    }

    public async Task<AdviceResponse> SaveAsync(Domain.Models.Advice advice)
    {
        var existingAdviceWithId = await _adviceRepository.FindByIdAsync(advice.Id);
        if (existingAdviceWithId != null)
            return new AdviceResponse("Advice already exists");
        try
        {
            await _adviceRepository.AddAsync(advice);
            await _unitOfWorkA.CompleteAsync();
            return new AdviceResponse(advice);
        }
        catch (Exception e)
        {
            return new AdviceResponse($"An error occurred while saving the question: {e.Message}");
        }
    }

    public async Task<AdviceResponse> UpdateAsync(int adviceId, Domain.Models.Advice advice)
    {
        var existingAdvice = await _adviceRepository.FindByIdAsync(adviceId);
        if (existingAdvice == null)
            return new AdviceResponse("Advice not found");

        existingAdvice.strAdvice = advice.strAdvice;
        existingAdvice.strAdviceCategory = advice.strAdviceCategory;
        existingAdvice.strAdviceThumb = advice.strAdviceThumb;
        existingAdvice.strAdviceDescription = advice.strAdviceDescription;
        try
        {
            _adviceRepository.Update(existingAdvice);
            await _unitOfWorkA.CompleteAsync();
            return new AdviceResponse(existingAdvice);
        }
        catch (Exception e)
        {
            return new AdviceResponse($"An error occurred while updating the question: {e.Message}");
        }
    }

    public async Task<AdviceResponse> DeleteAsync(int adviceId)
    {
        var existingAdvice = await _adviceRepository.FindByIdAsync(adviceId);

        if (existingAdvice == null)
            return new AdviceResponse("Advice not found.");
        try
        {
            _adviceRepository.Remove(existingAdvice);
            await _unitOfWorkA.CompleteAsync();
            return new AdviceResponse(existingAdvice);
        }
        catch (Exception e)
        {
            return new AdviceResponse($"An error occurred while deleting the advice: {e.Message}");
        }
    }
    
}
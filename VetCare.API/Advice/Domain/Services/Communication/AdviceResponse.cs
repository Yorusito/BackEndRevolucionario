using VetCare.API.Shared.Domain.Services.Communication;

namespace VetCare.API.Advice.Domain.Services.Communication;

public class AdviceResponse : BaseResponse<Models.Advice>
{
    public AdviceResponse(string message) : base(message)
    {
        
    }

    public AdviceResponse(Models.Advice resource) : base(resource)
    {
        
    }
}
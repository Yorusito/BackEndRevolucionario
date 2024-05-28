using VetCare.API.Advice.Resources;

namespace VetCare.API.Advice.Mapping;

public class ResourceToModelAdvice: AutoMapper.Profile
{

    public ResourceToModelAdvice()
    {
        CreateMap<SaveAdviceResource, Domain.Models.Advice>();
    }
    
}
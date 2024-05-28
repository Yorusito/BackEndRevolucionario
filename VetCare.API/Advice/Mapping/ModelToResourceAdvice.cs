using VetCare.API.Advice.Resources;

namespace VetCare.API.Advice.Mapping;

public class ModelToResourceAdvice : AutoMapper.Profile
{
    public ModelToResourceAdvice()
    {
        CreateMap<Domain.Models.Advice, AdviceResource>();
    }
}
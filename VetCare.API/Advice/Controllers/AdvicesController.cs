using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VetCare.API.Advice.Domain.Services;
using VetCare.API.Advice.Resources;
using VetCare.API.Shared.Extensions;

namespace VetCare.API.Advice.Controllers;


[ApiController]
[Route("/api/v1/[controller]")]
public class AdvicesController: ControllerBase
{
    private readonly IAdviceService _adviceService;
    private readonly IMapper _mapper;

    public AdvicesController(IAdviceService adviceService, IMapper mapper)
    {
        _adviceService = adviceService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<AdviceResource>> GetAllAsync()
    {
        var advices = await _adviceService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Domain.Models.Advice>, IEnumerable < AdviceResource >> (advices);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveAdviceResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var advice = _mapper.Map<SaveAdviceResource, Domain.Models.Advice>(resource);

        var result = await _adviceService.SaveAsync(advice);

        if (!result.Success)
            return BadRequest(result.Message);

        var adviceResource = _mapper.Map<Domain.Models.Advice, AdviceResource>(result.Resource);

        return Ok(adviceResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAdviceResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var advice = _mapper.Map<SaveAdviceResource, Domain.Models.Advice>(resource);

        var result = await _adviceService.UpdateAsync(id, advice);

        if (!result.Success)
            return BadRequest(result.Message);

        var adviceResource = _mapper.Map<Domain.Models.Advice, AdviceResource>(result.Resource);

        return Ok(adviceResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _adviceService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var adviceResource = _mapper.Map<Domain.Models.Advice>(result.Resource);
        return Ok(adviceResource);
    }
    
}
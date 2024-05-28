using System.ComponentModel.DataAnnotations;
namespace VetCare.API.Advice.Resources;

public class SaveAdviceResource
{
    
    [Required]
    [MaxLength(50)]
    public string strAdvice { get; set; } 
    
    [Required]
    public string strAdviceThumb { get; set; } 
        
    [Required]
    [MaxLength(50)]
    public string strAdviceCategory { get; set; } 
    
    [Required]
    [MaxLength(200)]
    public string strAdviceDescription { get; set; } 
}
using SportsManagement.Models;

namespace SportsManagement.DTOs.Responses;

public class OutfitResponseDTO
{
    public int Id { get; set; }
    public OutfitType Type { get; set; }
    public string BrandName { get; set; }
    public short No { get; set; }

  

}

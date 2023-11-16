using SportsManagement.Models;

namespace SportsManagement.DTOs.Requests;

public class UpdateOutfitRequestDTO
{
    public int Id { get; set; }
    public OutfitType Type { get; set; }
    public string BrandName { get; set; }
    public short No { get; set; }



    public int PlayerId { get; set; }
}

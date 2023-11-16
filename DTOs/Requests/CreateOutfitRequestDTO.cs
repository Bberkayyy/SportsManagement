using SportsManagement.Models;

namespace SportsManagement.DTOs.Requests;

public class CreateOutfitRequestDTO
{
    public int Id { get; set; }
    public OutfitType Type { get; set; }
    public string BrandName { get; set; }
    public short No { get; set; }
    public string PlayerName { get; set; }
}

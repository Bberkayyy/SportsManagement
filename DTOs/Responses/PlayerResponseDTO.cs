namespace SportsManagement.DTOs.Responses;

public class PlayerResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public decimal Price { get; set; }


    public TeamResponseDTO Team { get; set; }
    public BranchResponseDTO Branch { get; set; }
    public OutfitResponseDTO Outfit { get; set; }


}

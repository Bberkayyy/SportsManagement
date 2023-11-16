namespace SportsManagement.DTOs.Requests;

public class UpdatePlayerRequestDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public decimal Price { get; set; }
    public string BranchName { get; set; }
    public string TeamName { get; set; }
    public short OutfitNo { get; set; }
}


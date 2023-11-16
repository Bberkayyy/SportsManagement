namespace SportsManagement.Models;

public class Team
{
    public int Id { get; set; }
    public string TeamName { get; set; }

    public List<Player> Players { get; set; }
}

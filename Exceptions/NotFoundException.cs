namespace SportsManagement.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(int id) : base($"Girdiğiniz id'ye ait veri bulunamadı. ({id})")
    {
    }
}

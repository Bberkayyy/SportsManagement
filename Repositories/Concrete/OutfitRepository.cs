using Microsoft.EntityFrameworkCore;
using SportsManagement.Context;
using SportsManagement.Exceptions;
using SportsManagement.Models;
using SportsManagement.Repositories.Abstract;

namespace SportsManagement.Repositories.Concrete;

public class OutfitRepository : IOutfitRepository
{
    private readonly BaseDbContext _context;

    public OutfitRepository(BaseDbContext context)
    {
        _context = context;
    }

    public void Add(Outfit entity)
    {
        _context.Outfits.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var outfit = _context.Outfits.Find(id);
        if (outfit is null)
            throw new NotFoundException(id);
        _context.Outfits.Remove(outfit);
        _context.SaveChanges();
    }

    public List<Outfit> GetAll()
    {
        return _context.Outfits.Include(x => x.Player).ToList();
    }

    public Outfit? GetById(int id)
    {
        var outfit = _context.Outfits.Include(_x => _x.Player).SingleOrDefault(x => x.Id == id);
        if (outfit is null)
            throw new NotFoundException(id);
        return outfit;
    }

    public void Update(Outfit entity)
    {
        var outfit = _context.Outfits.Find(entity.Id);
        if (outfit is null)
            throw new NotFoundException(entity.Id);
        _context.Update(entity);
        _context.SaveChanges();
    }
}

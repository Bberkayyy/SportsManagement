using Microsoft.EntityFrameworkCore;
using SportsManagement.Context;
using SportsManagement.Exceptions;
using SportsManagement.Models;
using SportsManagement.Repositories.Abstract;

namespace SportsManagement.Repositories.Concrete;

public class TeamRepository : ITeamRepository
{
    private readonly BaseDbContext _context;

    public TeamRepository(BaseDbContext context)
    {
        _context = context;
    }

    public void Add(Team entity)
    {
        _context.Teams.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var team = _context.Teams.Find(id);
        if (team is null)
            throw new NotFoundException(id);
        _context.Teams.Remove(team);
        _context.SaveChanges();
    }

    public List<Team> GetAll()
    {
        return _context.Teams.Include(x => x.Players).ToList();
    }

    public Team? GetById(int id)
    {
        var team = _context.Teams.Include(x => x.Players).SingleOrDefault(x => x.Id == id);
        if (team is null)
            throw new NotFoundException(id);
        return team;
    }

    public void Update(Team entity)
    {
        var team = _context.Teams.Find(entity.Id);
        if ( team is null)
            throw new NotFoundException(entity.Id);
        _context.Teams.Update(entity);
        _context.SaveChanges();
    }
}

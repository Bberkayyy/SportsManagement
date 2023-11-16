using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportsManagement.Context;
using SportsManagement.Exceptions;
using SportsManagement.Models;
using SportsManagement.Repositories.Abstract;

namespace SportsManagement.Repositories.Concrete;

public class PlayerRepository : IPlayerReposiroty
{
    private readonly BaseDbContext _context;


    public PlayerRepository(BaseDbContext context)
    {
        _context = context;
    }

    public void Add(Player entity)
    {
        _context.Players.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var player = _context.Players.Find(id);
        if (player is null)
        {
            throw new NotFoundException(id);
        }
        _context.Players.Remove(player);
        _context.SaveChanges();

    }

    public List<Player> GetAll()
    {
        return _context.Players.Include(x => x.Branch).Include(x => x.Team).Include(x => x.Outfit).ToList();
    }

    public Player? GetById(int id)
    {
        var player = _context.Players.Include(x => x.Branch).Include(x => x.Team).Include(x => x.Outfit).SingleOrDefault(x => x.Id == id);
        if (player is null)
            throw new NotFoundException(id);
        return player;
    }

    public void Update(Player entity)
    {
        var updatePlayer = _context.Players.Find(entity.Id);
        if (updatePlayer is null)
            throw new NotFoundException(entity.Id);
        _context.Players.Update(entity);
        _context.SaveChanges();

    }
}

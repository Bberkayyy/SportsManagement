using Microsoft.EntityFrameworkCore;
using SportsManagement.Context;
using SportsManagement.Exceptions;
using SportsManagement.Models;
using SportsManagement.Repositories.Abstract;

namespace SportsManagement.Repositories.Concrete;

public class BranchRepository : IBranchRepository
{
    private readonly BaseDbContext _context;

    public BranchRepository(BaseDbContext context)
    {
        _context = context;
    }

    public void Add(Branch entity)
    {
        _context.Branches.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var branch = _context.Branches.Find(id);
        if (branch == null)
            throw new NotFoundException(id);
        _context.Branches.Remove(branch);
        _context.SaveChanges();
    }

    public List<Branch> GetAll()
    {
        return _context.Branches.Include(x => x.Players).ToList();
    }

    public Branch? GetById(int id)
    {
        var branch = _context.Branches.Include(_x => _x.Players).SingleOrDefault(x => x.Id == id);
        if (branch == null)
            throw new NotFoundException(id);
        return branch;
    }

    public void Update(Branch entity)
    {
        var branch = _context.Branches.Find(entity.Id);
        if (branch is null)
            throw new NotFoundException(entity.Id);
        _context.Branches.Update(branch);
        _context.SaveChanges();
    }
}

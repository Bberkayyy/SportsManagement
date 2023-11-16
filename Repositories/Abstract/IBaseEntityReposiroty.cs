
namespace SportsManagement.Repositories.Abstract;

public interface IBaseEntityReposiroty<TEntity> 
{
    void Add(TEntity entity);
    TEntity? GetById(int id);
    void Update(TEntity entity);
    void Delete(int id);
    List<TEntity> GetAll();
}

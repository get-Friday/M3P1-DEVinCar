namespace DEVinCar.Repository.Data.Repositories
{
    public class BaseRepository <TEntity, TKey> where TEntity : class
    {
        protected readonly DevInCarDbContext _context;
        public BaseRepository(DevInCarDbContext context)
        {
            _context = context;
        }
        public IQueryable<TEntity> Get()
        {
            return _context.Set<TEntity>().AsQueryable();
        }
        public TEntity GetById(TKey key)
        {
            return _context.Set<TEntity>().Find(key);
        }
        public void Post(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }
        public void Alter(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }
        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }
    }
}

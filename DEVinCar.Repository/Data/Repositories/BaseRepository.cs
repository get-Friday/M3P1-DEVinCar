namespace DEVinCar.Repository.Data.Repositories
{
    public class BaseRepository <TEntity, TKey> where TEntity : class
    {
        protected readonly DevInCarDbContext _context;
        public BaseRepository(DevInCarDbContext context)
        {
            _context = context;
        }
        public IEnumerable<TEntity> Get(TEntity entity)
        {
            return _context.Set<TEntity>();
        }
        public TEntity GetById(TKey key)
        {
            return _context.Set<TEntity>().Find(key);
        }
        public void Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }
        public void Edit(TEntity entity)
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

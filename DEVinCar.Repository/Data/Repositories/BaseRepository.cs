namespace DEVinCar.Repository.Data.Repositories
{
    internal class BaseRepository <TEntity, TKey> where TEntity : class
    {
        protected readonly DevInCarDbContext _context;
        public BaseRepository(DevInCarDbContext context)
        {
            _context = context;
        }
    }
}

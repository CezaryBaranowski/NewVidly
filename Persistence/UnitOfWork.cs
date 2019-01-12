using System.Threading.Tasks;
using NewVidly2.Core;

namespace NewVidly2.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VidlyDbContext _dbContext;
        public UnitOfWork(VidlyDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task Complete()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
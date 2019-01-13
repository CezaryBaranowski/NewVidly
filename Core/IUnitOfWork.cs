using System.Threading.Tasks;

namespace NewVidly2.Core
{

    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
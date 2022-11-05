using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SimpleOrderApp.Application.Common.Interfaces
{
    /// <summary>
    /// Db context interface
    /// </summary>
    public interface IApplicationDbContext
    {
        /// <summary>
        /// db set
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        /// <summary>
        /// a readonly reference to a dbset
        /// </summary>
        /// <typeparam name="TEnt"></typeparam>
        /// <returns></returns>
        IQueryable<TEnt> ReadSet<TEnt>() where TEnt : class;

        /// <summary>
        /// saves changes
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<int> SaveChangesExAsync(CancellationToken token = default);

        /// <summary>
        /// reject changes
        /// </summary>
        /// <param name="entries"></param>
        void RejectChanges(IList<EntityEntry> entries = null);
    }
}

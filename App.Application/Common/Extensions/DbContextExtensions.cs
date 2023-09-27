using App.Application.Common.Exceptions;
using App.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Common.Extensions
{
    public static class DbContextExtensions
    {
        public static async Task<T> GetNonNullableByIdAsync<T>(this DbSet<T> dbSet, Guid id, CancellationToken cancellationToken) where T : class
        {
            var result = await dbSet.FindAsync(new object?[] { id }, cancellationToken);

            return result is null
                ? throw new NotFoundException($"The item of type {typeof(T)} and Id: {id} was not found")
                : result;
        }

        public static async Task<T> GetNonNullableByIdAsync<T>(this IQueryable<T> dbSet, Guid id, CancellationToken cancellationToken) where T : BaseEntity
        {
            var result = await dbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            return result is null
                ? throw new NotFoundException($"The item of type {typeof(T)} and Id: {id} was not found")
                : result;
        }

        public static async Task<T?> GetNullableByIdAsync<T>(this DbSet<T> dbSet, Guid id, CancellationToken cancellationToken) where T : class
        {
            return await dbSet.FindAsync(new object?[] { id }, cancellationToken);
        }
    }
}

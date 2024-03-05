using App.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Common.Extensions
{
    public abstract class BaseDbContext(DbContextOptions options, IMediator mediator) : DbContext(options)
    {
        private readonly IMediator _mediator = mediator;

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            await DispatchDomainEvents(this);

            return await base.SaveChangesAsync(cancellationToken);

        }

        public async Task DispatchDomainEvents(DbContext? context)
        {
            if (context == null) return;

            var entities = context.ChangeTracker
                .Entries<BaseEntity>()
                .Where(e => e.Entity.DomainEvents.Count != 0)
                .Select(e => e.Entity);

            var domainEvents = entities
                .SelectMany(e => e.DomainEvents)
                .ToList();

            entities.ToList().ForEach(e => e.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
                await _mediator.Publish(domainEvent);
        }
    }
}

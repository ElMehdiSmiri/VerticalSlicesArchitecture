using App.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Common.Extensions
{
    public class BaseDbContext : DbContext
    {
        private readonly IMediator _mediator;

        public BaseDbContext(DbContextOptions options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

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
                .Where(e => e.Entity.DomainEvents.Any())
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

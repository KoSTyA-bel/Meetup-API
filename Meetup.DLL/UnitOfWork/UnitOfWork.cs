using Meetup.BLL.Interfaces;
using Meetup.DLL.Contexts;

namespace Meetup.DLL.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly MeetingContext context;

    public UnitOfWork(MeetingContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Task<int> Save() => this.context.SaveChangesAsync();
}

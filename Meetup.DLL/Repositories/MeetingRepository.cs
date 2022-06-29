using Meetup.BLL.Interfaces;
using Meetup.BLL.Entities;
using Meetup.DLL.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Meetup.DLL.Repositories;

public class MeetingRepository : IRepository<Meeting>
{
    private readonly MeetingContext context;

    public MeetingRepository(MeetingContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Create(Meeting entity)
    {
        this.context.Meetings.AddAsync(entity);
    }

    public void Delete(Meeting entity)
    {
        this.context.Remove(entity);
    }

    public Task<List<Meeting>> GetAll() => this.context.Meetings.ToListAsync();

    public Task<Meeting?> GetById(int entityId) => context.Meetings.FirstOrDefaultAsync(meeting => meeting.Id == entityId);

    public void Update(Meeting entity)
    {
        if (this.context.Entry(entity).State == EntityState.Detached)
        {
            this.context.Attach(entity);
        }

        this.context.Entry(entity).State = EntityState.Modified;
    }
}

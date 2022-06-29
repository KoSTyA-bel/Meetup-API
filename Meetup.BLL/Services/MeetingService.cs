using Meetup.BLL.Interfaces;
using Meetup.BLL.Entities;

namespace Meetup.BLL.Services;

public class MeetingService : IService<Meeting>
{
    private readonly IRepository<Meeting> repository;
    private readonly IUnitOfWork unitOfWork;

    public MeetingService(IRepository<Meeting> repository, IUnitOfWork unitOfWork)
    {
        this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Meeting> Create(Meeting entity)
    {
        this.repository.Create(entity);
        await this.unitOfWork.Save();
        return entity;
    }

    public Task Delete(Meeting entity)
    {
        this.repository.Delete(entity);
        return this.unitOfWork.Save();
    }

    public Task<List<Meeting>> GetAll() => this.repository.GetAll();

    public Task<Meeting?> GetById(int id) => this.repository.GetById(id);

    public Task Update(Meeting entity)
    {
        this.repository.Update(entity);
        return this.unitOfWork.Save();
    }
}

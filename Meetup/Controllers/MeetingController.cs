using Meetup.BLL.Interfaces;
using Meetup.BLL.Entities;
using Microsoft.AspNetCore.Mvc;
using Meetup.Model;
using AutoMapper;

namespace Meetup.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MeetingController : ControllerBase
{
    private readonly IService<Meeting> service;
    private readonly IMapper mapper;

    public MeetingController(IService<Meeting> service, IMapper mapper)
    {
        this.service = service ?? throw new ArgumentNullException(nameof(service));
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var meetings = await this.service.GetAll();

        if (meetings is null)
        {
            return NotFound();
        }

        if (!meetings.Any())
        {
            return NoContent();
        }

        return Ok(this.mapper.Map<IEnumerable<MeetingViewModel>>(meetings));
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var meeting = await this.service.GetById(id);

        if (meeting is null)
        {
            return NotFound();
        }

        return Ok(this.mapper.Map<MeetingViewModel>(meeting));
    }

    [HttpPost]
    public async Task<IActionResult> Create(MeetingViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var meeting = this.mapper.Map<Meeting>(model);

        var added = await this.service.Create(meeting);

        return Ok(added.Id);
    }

    [HttpPut]
    public async Task<IActionResult> Update(MeetingViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(model);
        }

        var meeting = this.mapper.Map<Meeting>(model);

        await this.service.Update(meeting);

        return Ok(this.mapper.Map<MeetingViewModel>(meeting));
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var meeting = await this.service.GetById(id);

        if (meeting is null)
        {
            return NotFound();
        }

        await this.service.Delete(meeting);

        return Ok(id);
    }
}

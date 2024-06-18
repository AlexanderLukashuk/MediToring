using MediatR;
using MediToring.Application.Common.Exceptions;
using MediToring.Application.Interfaces;
using MediToring.Domain;
using MediToring.Domain.Medications;
using Microsoft.EntityFrameworkCore;

namespace MediToring.Application.Features.MedicationSchedules.Commands.UpdateScheduleCommand;

public class UpdateScheduleCommandHandler(IMedicationScheduleRepository repository)
    : IRequestHandler<UpdateScheduleCommand>
{
    public async Task Handle(UpdateScheduleCommand request, CancellationToken cancellationToken)
    {
        var schedule = await repository.Get(request.Id);

        if (schedule == null)
        {
            throw new NotFoundException(nameof(MedicationSchedule), request.Id);
        }

        schedule.MedicationId = request.MedicationId;
        schedule.UserId = request.UserId;
        schedule.StartTime = request.StartTime;
        schedule.EndTime = request.EndTime;
        schedule.DailyDoses = request.DailyDoses.Select(d => 
            new DailyDose { TimeOfDay = d.TimeOfDay, BeforeMeal = d.BeforeMeal }).ToList();

        repository.Update(schedule);
        await repository.UnitOfWork.SaveEntitiesASync(cancellationToken);
    }
}
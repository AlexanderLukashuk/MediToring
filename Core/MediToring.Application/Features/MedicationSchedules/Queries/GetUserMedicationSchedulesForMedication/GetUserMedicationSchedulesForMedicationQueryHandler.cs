using MediatR;
using MediToring.Application.Features.MedicationSchedules.Queries.Models;
using MediToring.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediToring.Application.Features.MedicationSchedules.Queries.GetUserMedicationSchedulesForMedication;

public class GetUserMedicationSchedulesForMedicationQueryHandler(IMediToringDbContext context)
    : IRequestHandler<GetUserMedicationSchedulesForMedicationQuery, MedicationScheduleVm>
{
    public async Task<MedicationScheduleVm> Handle(GetUserMedicationSchedulesForMedicationQuery request, CancellationToken cancellationToken)
    {
        var schedules = await context.MedicationSchedules
            .Where(schedule => schedule.Id == request.UserId && schedule.MedicationId == request.MedicationId)
            .ToListAsync(cancellationToken);

        var scheduleDtos = schedules.Select(schedule => new MedicationScheduleDto
        {
            Id = schedule.Id,
            MedicationName = schedule.Medication.Name,
            StartTime = schedule.StartTime,
            EndTime = schedule.EndTime,
            IsTaken = schedule.IsTaken
        }).ToList();

        return new MedicationScheduleVm { Schedules = scheduleDtos };
    }
}
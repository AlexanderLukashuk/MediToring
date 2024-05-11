using AutoMapper;
using MediatR;
using MediToring.Application.Features.MedicationSchedules.Queries.Models;
using MediToring.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediToring.Application.Features.MedicationSchedules.Queries.GetUserMedicationSchedules;

public class GetUserMedicationSchedulesQueryHandler(IMediToringDbContext context)
    : IRequestHandler<GetUserMedicationSchedulesQuery, MedicationScheduleVm>
{
    public async Task<MedicationScheduleVm> Handle(GetUserMedicationSchedulesQuery request, CancellationToken cancellationToken)
    {
        // var schedules = await context.MedicationSchedules
        //     .Where(schedule => schedule.UserId == request.UserId)
        //     .ToListAsync();

        // var schedules = await context.MedicationSchedules
        //     .Select(schedule => new MedicationScheduleDto
        //     {
        //         Id = schedule.Id,
        //         MedicationName = schedule.Medication.Name,
        //         StartTime = schedule.StartTime,
        //         EndTime = schedule.EndTime,
        //         IsTaken = schedule.IsTaken
        //     })
        //     .ToListAsync(cancellationToken);

        // return new MedicationScheduleVm { Schedules = schedules };
        // return mapper.Map<MedicationScheduleVm>(schedules);

        var schedules = await context.MedicationSchedules
            .Where(schedule => schedule.UserId == request.UserId)
            .ToListAsync();

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
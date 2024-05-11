using AutoMapper;
using MediToring.Application.Common.Mappings;
using MediToring.Domain.Medications;

namespace MediToring.Application.Features.MedicationSchedules.Queries.Models;

public class MedicationScheduleDto : IMapWith<MedicationSchedule>
{
    public Guid Id { get; set; }
    public string MedicationName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsTaken { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<MedicationSchedule, MedicationScheduleDto>()
            .ForMember(scheduleDto => scheduleDto.Id,
                opt => opt.MapFrom(schedule => schedule.Id))
            .ForMember(scheduleDto => scheduleDto.MedicationName,
                opt => opt.MapFrom(schedule => schedule.Medication.Name))
            .ForMember(scheduleDto => scheduleDto.StartTime,
                opt => opt.MapFrom(schedule => schedule.StartTime))
            .ForMember(scheduleDto => scheduleDto.EndTime,
                opt => opt.MapFrom(schedule => schedule.EndTime))
            .ForMember(scheduleDto => scheduleDto.IsTaken,
                opt => opt.MapFrom(schedule => schedule.IsTaken));
    }
}
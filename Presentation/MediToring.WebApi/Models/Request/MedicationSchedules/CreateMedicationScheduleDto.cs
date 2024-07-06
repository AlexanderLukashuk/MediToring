namespace MediToring.WebApi.Models.Request.MedicationSchedules;

public class CreateMedicationScheduleDto : IMapWith<CreateScheduleCommand>
{
    public Guid MedicationId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public required ICollection<DailyDoseDto> DailyDoses { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateMedicationScheduleDto, CreateScheduleCommand>();
    }
}
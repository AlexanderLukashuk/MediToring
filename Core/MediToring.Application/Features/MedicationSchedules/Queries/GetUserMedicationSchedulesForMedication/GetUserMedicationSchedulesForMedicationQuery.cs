namespace MediToring.Application.Features.MedicationSchedules.Queries.GetUserMedicationSchedulesForMedication;

public class GetUserMedicationSchedulesForMedicationQuery : IRequest<MedicationScheduleVm>
{
    public required string UserId { get; set; }
    public Guid ScheduleId { get; set; }
}
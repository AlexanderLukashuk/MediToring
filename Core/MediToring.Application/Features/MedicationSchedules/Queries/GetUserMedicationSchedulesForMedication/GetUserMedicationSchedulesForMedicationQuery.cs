namespace MediToring.Application.Features.MedicationSchedules.Queries.GetUserMedicationSchedulesForMedication;

public class GetUserMedicationSchedulesForMedicationQuery : IRequest<MedicationScheduleVm>
{
    public Guid UserId { get; set; }
    public Guid MedicationId { get; set; }
}
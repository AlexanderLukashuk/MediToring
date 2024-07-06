namespace MediToring.Application.Features.MedicationSchedules.Queries.GetUserMedicationSchedules;

public class GetUserMedicationSchedulesQuery : IRequest<MedicationScheduleVm>
{
    public required string UserId { get; set; }
}
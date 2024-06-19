namespace MediToring.Application.Features.MedicationSchedules.Queries.GetUserMedicationSchedules;

public class GetUserMedicationSchedulesQuery : IRequest<MedicationScheduleVm>
{
    public Guid UserId { get; set; }
}
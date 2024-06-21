namespace MediToring.Application.Features.MedicationSchedules.Queries.GetUserMedicationSchedules;

public class GetUserMedicationSchedulesQuery : IRequest<MedicationScheduleVm>
{
    public string UserId { get; set; }
}
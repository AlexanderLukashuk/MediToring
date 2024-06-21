namespace MediToring.Application.Features.MedicationSchedules.Commands.CreateScheduleCommand;

public class CreateScheduleCommandValidator : AbstractValidator<CreateScheduleCommand>
{
    public CreateScheduleCommandValidator()
    {
        RuleFor(schedule =>
            schedule.MedicationId).NotEqual(Guid.Empty);
        RuleFor(schedule =>
            schedule.UserId).NotEmpty();
        RuleFor(schedule =>
            schedule.StartTime).NotEmpty();
        RuleFor(schedule =>
            schedule.EndTime).NotEmpty()
            .GreaterThan(schedule => schedule.StartTime);
        RuleFor(schedule =>
            schedule.DailyDoses).NotNull();
    }
}
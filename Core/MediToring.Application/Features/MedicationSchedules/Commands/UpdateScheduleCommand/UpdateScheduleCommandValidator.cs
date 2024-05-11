using FluentValidation;

namespace MediToring.Application.Features.MedicationSchedules.Commands.UpdateScheduleCommand;

public class UpdateScheduleCommandValidator : AbstractValidator<UpdateScheduleCommand>
{
    public UpdateScheduleCommandValidator()
    {
        RuleFor(schedule =>
            schedule.Id).NotEqual(Guid.Empty);
        RuleFor(schedule =>
            schedule.MedicationId).NotEqual(Guid.Empty);
        RuleFor(schedule =>
            schedule.UserId).NotEqual(Guid.Empty);
        RuleFor(schedule =>
            schedule.StartTime).NotEmpty();
        RuleFor(schedule =>
            schedule.EndTime).NotEmpty()
            .GreaterThan(schedule => schedule.StartTime);
        RuleFor(schedule =>
            schedule.DailyDoses).NotNull();
    }
}
using FluentValidation;

namespace MediToring.Application.Features.Medications.Commands.CreateMedication;

public class CreateMedicationCommandValidator : AbstractValidator<CraeteMedicationCommand>
{
    public CreateMedicationCommandValidator()
    {
        RuleFor(medication => 
            medication.Name).NotEmpty().MaximumLength(2500);
        RuleFor(medication => 
            medication.Dosage).NotEmpty().MaximumLength(50);
        RuleFor(medication => 
            medication.Instruction).NotEmpty().MaximumLength(250);
    }
}
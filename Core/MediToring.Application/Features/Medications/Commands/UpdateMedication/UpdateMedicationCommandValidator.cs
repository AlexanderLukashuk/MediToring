namespace MediToring.Application.Features.Medications.Commands.UpdateMedication;

public class UpdateMedicationCommandValidator : AbstractValidator<UpdateMedicationCommand>
{
    public UpdateMedicationCommandValidator()
    {
        RuleFor(medication => 
            medication.Id).NotEqual(Guid.Empty);
        RuleFor(medication => 
            medication.Name).NotEmpty().MaximumLength(2500);
        RuleFor(medication => 
            medication.Dosage).NotEmpty().MaximumLength(50);
        RuleFor(medication => 
            medication.Instruction).NotEmpty().MaximumLength(250);
    }
}
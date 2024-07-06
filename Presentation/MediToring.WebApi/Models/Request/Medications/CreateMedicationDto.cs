namespace MediToring.WebApi.Models.Request.Medications;

public class CreateMedicationDto : IMapWith<CraeteMedicationCommand>
{
    public required string Name { get; set; }
    public required string Dosage { get; set; }
    public required string Instruction { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateMedicationDto, CraeteMedicationCommand>();
    }
}
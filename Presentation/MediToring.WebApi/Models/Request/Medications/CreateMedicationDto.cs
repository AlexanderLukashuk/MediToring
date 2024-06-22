namespace MediToring.WebApi.Models.Request.Medications;

public class CreateMedicationDto : IMapWith<CraeteMedicationCommand>
{
    public string Name { get; set; }
    public string Dosage { get; set; }
    public string Instruction { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateMedicationDto, CraeteMedicationCommand>();
    }
}
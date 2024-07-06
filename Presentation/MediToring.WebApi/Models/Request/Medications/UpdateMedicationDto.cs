namespace MediToring.WebApi.Models.Request.Medications;

public class UpdateMedicationDto : IMapWith<UpdateMedicationCommand>
{
    public required string Name { get; set; }
    public required string Dosage { get; set; }
    public required string Instruction { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateMedicationDto, UpdateMedicationCommand>();
    }
}
namespace MediToring.WebApi.Models.Request.Medications;

public class UpdateMedicationDto : IMapWith<UpdateMedicationCommand>
{
    public string Name { get; set; }
    public string Dosage { get; set; }
    public string Instruction { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateMedicationDto, UpdateMedicationCommand>();
    }
}
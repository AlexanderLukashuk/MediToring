namespace MediToring.Application.Features.Medications.Queries.GetMedicationDetails;

public class MedicationDetailsVm : IMapWith<Medication>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Dosage { get; set; }
    public required string Instruction { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Medication, MedicationDetailsVm>()
            .ForMember(medicationVm => medicationVm.Name,
                opt => opt.MapFrom(medication => medication.Name))
            .ForMember(medicationVm => medicationVm.Dosage,
                opt => opt.MapFrom(medication => medication.Dosage))
            .ForMember(medicationVm => medicationVm.Instruction,
                opt => opt.MapFrom(medication => medication.Instruction));
    }
}
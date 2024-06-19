namespace MediToring.Application.Features.Medications.Queries.GetMedicationList;

public class MedicationLookupDto : IMapWith<Medication>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Medication, MedicationLookupDto>()
            .ForMember(medicationDto => medicationDto.Id,
                opt => opt.MapFrom(medication => medication.Id))
            .ForMember(medicationDto => medicationDto.Name,
                opt => opt.MapFrom(medication => medication.Name));
    }
}
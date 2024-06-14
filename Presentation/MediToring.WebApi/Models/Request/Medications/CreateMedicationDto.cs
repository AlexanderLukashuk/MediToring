namespace MediToring.WebApi.Models.Request.Medications;

public class CreateMedicationDto
{
    public string Name { get; set; }
    public string Dosage { get; set; }
    public string Instruction { get; set; }
}
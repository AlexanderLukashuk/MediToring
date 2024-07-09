namespace MediToring.Application.Common.Mappings;

public class AssemblyMappingProfile : Profile
{
    public AssemblyMappingProfile(Assembly assembly) =>
        ApplyMappingFromAssembly(assembly);

    private void ApplyMappingFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(type => type.GetInterfaces()
                .Any(i => i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
            .ToList();

            foreach (var type in types)
            {
                Console.WriteLine($"Type found for mapping: {type.Name}");
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping")
                                ?? type.GetInterface("IMapWith`1").GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
    }
}
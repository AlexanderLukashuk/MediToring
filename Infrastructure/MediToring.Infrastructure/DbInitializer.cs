namespace MediToring.Infrastructure;

public class DbInitializer
{
    public static void Initialize(MediToringDbContext context)
    {
        context.Database.EnsureCreated();
    }
}
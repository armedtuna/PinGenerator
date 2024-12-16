namespace PinGenerator.Models.Generators;

public interface IPinsGenerator
{
    HashSet<string> CreateUniquePins(int count);
}
namespace PinGenerator.Models.Generators;

public interface IPinGenerator
{
    string CreatePin(int length);
}
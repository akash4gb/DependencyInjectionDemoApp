namespace DependencyInjectionDemo.Logic;

public class AnotherDemoLogic:IDemoLogic
{
    public int Value1 { get; private set; }
    public int Value2 { get; private set; }

    public AnotherDemoLogic()

    {
        Value1 = Random.Shared.Next(999, 9999);
        Value2 = Random.Shared.Next(5000, 7000);

    }
}

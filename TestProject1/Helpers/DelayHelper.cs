namespace TestProject1.Helpers;

public class DelayHelper
{
    public static void Delay()
    {
        Thread.Sleep(3000); // Задержка в 3 секунды
    }

    public static void ShortDelay()
    {
        Thread.Sleep(1000); // Задержка в 1 секунду
    }
}
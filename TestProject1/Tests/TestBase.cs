using NUnit.Framework;

namespace TestProject1.Tests;

public class TestBase
{
    protected ApplicationManager App { get; private set; }

    [SetUp]
    public void SetupTest()
    {
        try
        {
            App = new ApplicationManager();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to initialize ApplicationManager: {ex.Message}");
            Assert.Fail("Failed to initialize ApplicationManager");
        }
    }

    [TearDown]
    public void TeardownTest()
    {
        if (App != null)
        {
            try
            {
                App.Driver.Quit(); // Закрывает браузер и освобождает ресурсы
                App.Driver.Dispose(); // Утилизирует объект IWebDriver
            }
            catch (Exception)
            {
                // Игнорируем ошибки, если не удается закрыть браузер
            }
        }
    }
}
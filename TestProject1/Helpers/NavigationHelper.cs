using OpenQA.Selenium;

namespace TestProject1.Helpers;

public class NavigationHelper : BaseHelper
{
    private string baseURL;
    private IWebDriver driver;
    public NavigationHelper(ApplicationManager manager, string baseURL)
        : base(manager)
    {
        this.baseURL = baseURL;
        this.driver = manager.Driver;
    }
    
    public void OpenLoginPage()
    {
        try
        {
            driver.Navigate().GoToUrl("http://localhost:8000/Users/login/");
            DelayHelper.Delay();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while opening login page: {ex.Message}");
            throw;
        }
    }

    public void OpenHomePage()
    {
        try
        {
            driver.Navigate().GoToUrl("http://localhost:8000/MiracleArt/");
            DelayHelper.Delay(); 
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while opening home page: {ex.Message}");
            throw; 
        }
    }
    
    public void OpenGalleryPage()
    {
        try
        {
            driver.Navigate().GoToUrl("http://localhost:8000/MiracleArt/gallery/");
            DelayHelper.Delay();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while opening gallery page: {ex.Message}");
            throw;
        }
    }
    
    public void OpenWorkShopPage()
    {
        try
        {
            driver.Navigate().GoToUrl("http://localhost:8000/MiracleArt/workshop/");
            DelayHelper.Delay();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while opening gallery page: {ex.Message}");
            throw;
        }
    }
}
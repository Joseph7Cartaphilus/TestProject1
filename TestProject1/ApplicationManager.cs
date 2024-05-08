using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TestProject1.Helpers;


public class ApplicationManager
{
    private static ThreadLocal<ApplicationManager> appManager = new ThreadLocal<ApplicationManager>();
    
    private IWebDriver driver;
    private StringBuilder verificationErrors;
    private string baseURL;

    public NavigationHelper navigation;
    public LoginHelper authorization;
    public PinHelper pin;
    
    public ApplicationManager()
    {
        driver = new FirefoxDriver();
        baseURL = "http://localhost:8000/admin/";
        verificationErrors = new StringBuilder();
        pin = new PinHelper(this);
        authorization = new LoginHelper(this);
        navigation = new NavigationHelper(this, baseURL);
    }
    
    public static ApplicationManager GetInstance()
    {
        if (!appManager.IsValueCreated)
        {
            ApplicationManager newInstance = new ApplicationManager();
            appManager.Value = newInstance;
        }
        return appManager.Value;
    }

    ~ApplicationManager()
    {
        try
        {
            driver.Quit();
        }
        catch (Exception)
        {
            // Игнорируем исключения, если возникают при завершении работы
        }
    }
    
    public IWebDriver Driver
    {
        get { return driver; }
    }
    
    public NavigationHelper Navigation
    {
        get { return navigation; }
    }
    
    public LoginHelper Auth
    {
        get { return authorization; }
    }

    public PinHelper Pin
    {
        get { return pin; }
    }
}
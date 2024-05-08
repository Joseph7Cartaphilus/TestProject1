using System.Diagnostics;
using OpenQA.Selenium;
using TestProject1.Model;


namespace TestProject1.Helpers;

public class LoginHelper : BaseHelper
{   
    private readonly ApplicationManager app;
    private IWebDriver driver;
    public LoginHelper(ApplicationManager manager)
        : base(manager)
    {
        this.driver = manager.Driver;
        app = manager;
    }
    
    protected void Logout()
    {
        driver.Navigate().GoToUrl("http://localhost:8000/Users/logout/");
        DelayHelper.Delay();
    }
    
    public bool IsLoggedIn(AccountData user)
    {
        try
        {
            // Найдем ссылку на выход, используя XPath
            IWebElement logoutLink = app.Driver.FindElement(By.XPath("/html/body/header/div/div/div/nav/div[2]/div[2]/ul/li[5]/a"));
            // Проверим, что ссылка отображается на странице
            return logoutLink != null && logoutLink.Displayed;
        }
        catch (NoSuchElementException)
        {
            // Если ссылка не найдена, пользователь не авторизован
            return false;
        }
    }
    
    public void Authorization(AccountData user)
    {
        driver.FindElement(By.Id("id_username")).Click();
        driver.FindElement(By.Id("id_username")).Clear();
        driver.FindElement(By.Id("id_username")).SendKeys(user.Username);
        driver.FindElement(By.Id("id_password")).Click();
        driver.FindElement(By.Id("id_password")).Clear();
        driver.FindElement(By.Id("id_password")).SendKeys(user.Password);
        DelayHelper.Delay();
        driver.FindElement(By.XPath("//input[@value='Authorization']")).Click();
    }
}


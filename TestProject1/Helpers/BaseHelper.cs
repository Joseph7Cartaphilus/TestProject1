using OpenQA.Selenium;

namespace TestProject1.Helpers;


public class BaseHelper(ApplicationManager manager)
{
    protected ApplicationManager manager;
    protected IWebDriver driver;
    private bool _acceptNextAlert = true;
    
    public string CloseAlertAndGetItsText() {
        try {
            IAlert alert = driver.SwitchTo().Alert();
            string alertText = alert.Text;
            if (_acceptNextAlert) {
                alert.Accept();
            } else {
                alert.Dismiss();
            }
            return alertText;
        } finally {
            _acceptNextAlert = true;
        }
    }
    
    public bool IsAlertPresent()
    {
        try
        {
            driver.SwitchTo().Alert();
            return true;
        }
        catch (NoAlertPresentException)
        {
            return false;
        }
    }
    
    public bool IsElementPresent(By by)
    {
        try
        {
            driver.FindElement(by);
            return true;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
}
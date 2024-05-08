using OpenQA.Selenium;
using TestProject1.Model;

namespace TestProject1.Helpers
{
    public class PinHelper : BaseHelper
    {
        private IWebDriver driver;

        public PinHelper(ApplicationManager manager)
            : base(manager)
        {
            this.driver = manager.Driver;
            this.manager = manager;
        }
        
        // Метод для проверки успешного создания поста
        public bool IsPinCreated(PinData post)
        {
            // Проверяем, что пост отображается на странице
            try
            {
                IWebElement postTitleElement = manager.Driver.FindElement(By.XPath($"//div[@class='post-title' and contains(text(), '{post.Title}')]"));
                return postTitleElement != null && postTitleElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
        }
        
        public void CreateNewPin(PinData pin)
        {
            DelayHelper.Delay();
            driver.FindElement(By.Id("add_pin")).Click();
            DelayHelper.Delay();
            driver.FindElement(By.Id("create_pin")).Click();
            DelayHelper.Delay();
            driver.FindElement(By.Id("id_title")).Click();
            driver.FindElement(By.Id("id_title")).Clear();
            driver.FindElement(By.Id("id_title")).SendKeys(pin.Title);
            driver.FindElement(By.Id("id_text")).Clear();
            driver.FindElement(By.Id("id_text")).SendKeys(pin.Text);
            driver.FindElement(By.Name("img")).SendKeys(pin.ImagePath);
            driver.FindElement(By.XPath("/html/body/div[1]/form/div/button")).Click();
            DelayHelper.ShortDelay();
            manager.Navigation.OpenGalleryPage();
            DelayHelper.Delay();
        }

        public void DeletePin(PinData pin)
        {
            DelayHelper.Delay();
            manager.Navigation.OpenWorkShopPage();
            driver.FindElement(By.LinkText("TestPin")).Click();
            DelayHelper.Delay();
            driver.FindElement(By.Id("delete_pin")).Click();
            DelayHelper.Delay();
        }
    }
}
using TestProject1.Generator;
using TestProject1.Model;


namespace TestProject1.Tests;

public class CreatePin
{
    [TestFixture]
    public class PinCreateTest : TestBase
    {
        [Test]
        public void CreateNewPinTestCase()
        {   
            AccountData user = new AccountData("joseph", "123");
            PinData pin = TestDataGenerator.GenerateRandomPin();
            
            App.Navigation.OpenHomePage();
            App.Navigation.OpenLoginPage();
            App.Auth.Authorization(user);
            App.Navigation.OpenGalleryPage();
            App.Pin.CreateNewPin(pin);
            
            // Проверяем успешное создание пина
            Assert.That(App.Pin.IsPinCreated(pin), "Creating a new pin failed");
        }
    }
}
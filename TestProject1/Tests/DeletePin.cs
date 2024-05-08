using TestProject1.Model;


namespace TestProject1.Tests;

public class DeletePin
{
    [TestFixture]
    public class PinDeleteTest : TestBase
    {
        [Test]
        public void DeletePinTestCase()
        {   
            AccountData user = new AccountData("joseph", "123");
            PinData pin = new PinData("TestPin", "TestText", "/home/joseph/Изображения/kek_files/1_forum_logo.png");

            App.Navigation.OpenHomePage();
            App.Navigation.OpenLoginPage();
            App.Auth.Authorization(user);
            App.Navigation.OpenWorkShopPage();
            App.Pin.DeletePin(pin);
        }
    }
}
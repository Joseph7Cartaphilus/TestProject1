using NUnit.Framework;
using TestProject1.Model;

namespace TestProject1.Tests
{
    [TestFixture]
    public class AuthorizationTest : TestBase 
    {
        [Test]
        public void Authorization()
        {
            AccountData user = new AccountData("joseph", "123");
            
            App.Navigation.OpenHomePage();
            App.Navigation.OpenLoginPage();
            App.Auth.Authorization(user);
            App.Auth.IsLoggedIn(user);
            
            // Проверяем успешность авторизации
            Assert.That(App.Auth.IsLoggedIn(user), "Authorization failed");
        }
    }
}
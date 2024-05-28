using TestProject1.Generator;
using TestProject1.Model;

namespace TestProject1.Tests
{
    [TestFixture]
    public class AuthorizationTest : TestBase 
    {
        [Test]
        public void AuthorizationWithValidCredentials()
        {
            AccountData user = new AccountData("joseph", "123");
            
            App.Navigation.OpenHomePage();
            App.Navigation.OpenLoginPage();
            App.Auth.Authorization(user);
            App.Auth.IsLoggedIn(user);
            
            // Проверяем успешность авторизации
            Assert.That(App.Auth.IsLoggedIn(user), "Authorization failed");
        }
        [Test]
        public void AuthorizationWithInvalidCredentials()
        {
            AccountData invalidUser = TestDataGenerator.GenerateRandomAccount();
            
            App.Navigation.OpenHomePage();
            App.Navigation.OpenLoginPage();
            App.Auth.Authorization(invalidUser);
            App.Auth.IsLoggedIn(invalidUser);
            
            if (App.Auth.IsLoggedIn(invalidUser))
            {
                Assert.Fail("Authorization should have failed with invalid credentials");
            }
        }
    }
}
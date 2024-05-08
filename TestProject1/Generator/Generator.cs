using System;

namespace TestProject1.Model
{
    public static class TestDataGenerator
    {
        public static AccountData GenerateRandomAccount()
        {
            // Генерация случайного имени пользователя и пароля
            string username = GenerateRandomString(8);
            string password = GenerateRandomString(10);
            return new AccountData(username, password);
        }

        public static PinData GenerateRandomPin()
        {
            // Генерация случайного названия, текста и пути к изображению для пина
            string title = GenerateRandomString(10);
            string text = GenerateRandomString(20);
            string imagePath = GenerateRandomImagePath();
            return new PinData(title, text, imagePath);
        }

        private static string GenerateRandomString(int length)
        {
            // Генерация случайной строки заданной длины
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static string GenerateRandomImagePath()
        {
            // Генерация случайного пути к изображению (здесь можно использовать вашу логику)
            return "/path/to/image.png";
        }
    }
}
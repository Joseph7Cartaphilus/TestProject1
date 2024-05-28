using TestProject1.Model;

namespace TestProject1.Generator
{
    public static class TestDataGenerator
    {
        private static readonly Random Random = new Random();
        
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
            string imagePath = GenerateRandomImagePath("/home/joseph/files/");
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

        private static string GenerateRandomImagePath(string directoryPath)
        {
            string[] imageFiles = Directory.GetFiles(directoryPath, "*.png");
            if (imageFiles.Length == 0)
            {
                throw new FileNotFoundException("No PNG image files found in the specified directory.");
            }

            // Выбираем случайный файл из списка
            int randomIndex = Random.Next(imageFiles.Length);
            return imageFiles[randomIndex];
        }
    }
}
namespace TestProject1.Model;

public class PinData
{
    public PinData(string title, string text, string imagePath)
    {
        Title = title;
        Text = text;
        ImagePath = imagePath;
    }

    public string Title { get; set; }
    public string Text { get; set; }
    public string ImagePath { get; set; }
}

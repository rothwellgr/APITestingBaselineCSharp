namespace APITestingBaselineCSharp.DTOs;

/// <summary>
/// HTTPBin Slideshow DTO
/// </summary>
public record SlideshowDTO
{
    public required Slideshow Slideshow { get; set; }
}

public record Slideshow
{
    public required string Author { get; set; }
    public required string Date { get; set; } // Docs read literally "date of publication", hense string
    public required List<Slides> Slides { get; set; }
    public required string Title { get; set;}
}

public record Slides 
{
    public required string Title { get; set; }
    public required string Type { get; set; }
    public string[] Items { get; set; } = [];
}
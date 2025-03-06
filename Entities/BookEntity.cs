namespace ALCAssessment.Entities;

public class BookEntity
{
    public int BookId { get; set; }

    public string Title { get; set; }

    public string Author { get; set; }

    public string ISBN { get; set; }

    public bool IsDeleted { get; set; } = false;
}
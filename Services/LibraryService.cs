using System.Text.Json;
using ALCAssessment.Dtos.Book.Request;
using ALCAssessment.Dtos.Book.Response;
using ALCAssessment.Entities;

namespace ALCAssessment.Services;

public class LibraryService
{
    private List<BookEntity> Books { get; set; } = [];
    private int _lastBookId;

    public void AddBook(BookRequestDto bookRequestDto)
    {
        BookEntity book = new()
        {
            BookId = ++_lastBookId,
            Title = bookRequestDto.Title,
            Author = bookRequestDto.Author,
            ISBN = bookRequestDto.ISBN
        };

        Books.Add(book);

        Console.WriteLine($"Book added successfully: {JsonSerializer.Serialize(book)}");
    }

    public void GetBooks()
    {
        IEnumerable<BookResponseDto> books = Books
                                        .Where(x => x.IsDeleted == false)
                                        .Select(x => new BookResponseDto()
                                        {
                                            BookId = x.BookId,
                                            Title = x.Title,
                                            Author = x.Author,
                                            ISBN = x.ISBN
                                        });

        if (!books.Any())
        {
            Console.WriteLine("No books found.");
            return;
        }

        string jsonString = JsonSerializer.Serialize(books);
        Console.WriteLine(jsonString);
    }

    public void RemoveBookById(int bookId)
    {
        BookEntity book = Books.FirstOrDefault(x => x.BookId == bookId);

        if (book is null)
        {
            Console.WriteLine($"Book with ID: {bookId} does not exist.");
            return;
        }

        book.IsDeleted = true;
        Console.WriteLine($"Book with ID: {bookId} removed.");
    }
}
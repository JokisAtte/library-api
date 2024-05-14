using Xunit;
using LibraryApi.Controllers;
using LibraryApi.Services;


namespace LibraryApi.tests;
public class UnitTest1
{
    [Fact]
    public void Test_GetBooks_ReturnsNotNull()
    {
        // Arrange
        var controller = new LibraryApi.Controllers.BooksController(/* dependencies here */);

        // Act
        var result = controller.GetBooks();

        // Assert
        Assert.NotNull(result);
    }
}
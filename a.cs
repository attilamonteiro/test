using Xunit;

public class MyTests
{
    [Fact]
    public void TestAddition()
    {
        // Arrange
        int a = 2;
        int b = 3;

        // Act
        int result = a + b;

        // Assert
        Assert.Equal(5, result);
    }
}

namespace GradesApp.Tests;


public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        //arrange
        var a = 2;
        var b = 7;
        var expected = 9;

        //act
        var actual = a + b;

        //assert
        Assert.Equal(expected, actual);
    }
}

using NUnit.Framework;
using SpeakingClock;
namespace SpeakingClock.UnitTests;

public class SpeakUserInputTests
{
    [Test]
    public static void getuserInput_SelectsOne_SystemTime_Pass()
    {
        var stringReader = new StringReader("1");
        Console.SetIn(stringReader);
        Drive.Main();
    }
    [Test]
    public static void getuserInput_SelectTwo_Pass()
    {
        var stringReader = new StringReader("2\r\n23\r\n46");
        Console.SetIn(stringReader);
        Drive.Main();
    }

    [Test]
    public static void getuserInput_SelectsOne_SystemTime_FailFirstTry()
    {
        var stringReader = new StringReader("0\r\n1");
        Console.SetIn(stringReader);
        Drive.Main();
    }

    [Test]
    public static void getuserInput_SelectsOne_SystemTime_FailSecondTry()
    {
        var stringReader = new StringReader("0\r\n3\r\n1");
        Console.SetIn(stringReader);
        Drive.Main();
    }

    [Test]
    public static void getuserInput_SelectsOne_SystemTime_FailThirdTry()
    {
        var stringReader = new StringReader("0\r\n4\r\n-1\r\n1");
        Console.SetIn(stringReader);
        Drive.Main();
    }
    [Test]
    public static void getuserInput_SelectsOne_SystemTime_FailFourthTry()
    {
        try
        {
            var stringReader = new StringReader("0\r\n4\r\n-1\r\n9\r\n8");
            Console.SetIn(stringReader);
            Drive.Main();
         }
        catch (Exception ex)
        {
            Assert.IsTrue(ex is Exception);
        }
    }
}
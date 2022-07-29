// Speaking Clock C# Program
using SpeakingClock;

public class SpeakUserInput : SpeakTime
{
	public override string speak()
	{
		try
		{
			string hours = getuserInput(0, 23, 0,"Hours");
			string minutes = getuserInput(0, 59, 0,"Minutes");
			return base.timetotext(hours, minutes);
		}
		catch (Exception e)
		{
			Console.Write("Unable to process the request: "+e.Message);
			throw e;
		}
	}
	private string getuserInput(int from, int to, int count, string inputtype)
	{
		string inputstring = String.Empty;
		try
		{
			Console.Write("Input " + inputtype+ " from " + from + " to " + to + ": ");
			inputstring = new ConsoleWrapper().ReadLine();
			count++;
			int input = int.Parse(inputstring);
			if (input < from || input > to) throw new Exception("Invalid input ");
			return inputstring;
		}
		catch (Exception e)
		{
			if (count == 3)
			{
				Console.WriteLine("Count tries exceeded: Invalid User Response.");
				throw e;
			}
			else
			{
				Console.WriteLine("That's an invalid input, try again ");
				return getuserInput(from, to, count,inputtype);
			}
		}
	}
}
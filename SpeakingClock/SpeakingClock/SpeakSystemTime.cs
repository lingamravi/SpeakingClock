// Speaking Clock C# Program
using System;
using SpeakingClock;

class SpeakSystemTime : SpeakTime
{
	public  override string speak()
	{
		string Systime = DateTime.Now.ToString("hh:mm");
		string[] splittime = Systime.Split(new char[] { ':' });
        try
        {
            return base.timetotext(splittime[0], splittime[1]);

        }
        catch (Exception ex)
        {
            Console.Write("Unable to process the request: " + ex.Message);
            throw ex;
        }
	}
}
using System;
namespace SpeakingClock
{
	public abstract class SpeakTime
	{
		public abstract string speak();

		//This method performs the parsing and conversion of hours and minutes input to text
		public string timetotext(string hours, string minutes)
		{
			int h = int.Parse(hours);
			int m = int.Parse(minutes);
			string[] data = { "Zero", "One", "Two", "Three", "Four",
				"Five", "Six", "Seven", "Eight", "Nine",
				"Ten", "Eleven", "Twelve", "Thirteen",
				"Fourteen", "Fifteen", "Sixteen", "Seventeen",
				"Eighteen", "Nineteen", "Twenty", "Twenty One",
				"Twenty Two", "Twenty Three", "Twenty Four",
				"Twenty Five", "Twenty Six", "Twenty Seven",
				"Twenty Eight", "Twenty Nine"
			};
			if (m == 0)
			{
				Console.WriteLine(data[h % 12] + " o' clock ");
				return data[h % 12] + " o' clock ";
			}
			else if (m == 1)
			{
				string result = (h % 12 == 0 && h == 12) ? "One Past Noon" : "One Past "+ data[h % 12];
				Console.WriteLine(result) ;
				return result;
			}
			else if (m == 59)
			{
				Console.WriteLine("one to " + data[(h % 12) + 1]);
				return "one to " + data[(h % 12) + 1];
			}
			else if (m == 15)
			{
				Console.WriteLine("quarter past " + data[h % 12]);
				return "quarter past " + data[h % 12];
			}
			else if (m == 30)
			{
				Console.WriteLine("half past " + data[h % 12]);
				return "half past " + data[h % 12];
			}
			else if (m == 45)
			{
				Console.WriteLine("quarter to " + data[(h % 12) + 1]);
				return "quarter to " + data[(h % 12) + 1];
			}
			else if (m <= 30)
			{
				string result = (h % 12 == 0 && h == 12) ? data[m] +" Past Noon" :data[m]+ " Past " + data[h % 12];
				Console.WriteLine(result);
				return result;
			}
			else if(m > 30 && m<59)
			{
				Console.WriteLine(data[60 - m] + " Minutes to " + data[(h % 12) + 1]);
				return data[60 - m] + " Minutes to " + data[(h % 12) + 1];
			}
			else
			{
				throw new Exception("Invalid State: Can't process the request.");
			}
		}
	}
}
using System;
namespace SpeakingClock
{
    public class Drive
    {
        public static void Main()
        {
            try
            {
                int selection = getUserInput(0);
                if (selection == 1)
                {
                     new SpeakSystemTime().speak();
                }
                else
                {
                     new SpeakUserInput().speak();
                }
            }
            catch (Exception e)
            {
                Console.Write("Unable to process the request: " + e.Message);
                throw e;
            }
        }

        //This method redirects user to select systemtime or arbitrarytime
        public static int getUserInput(int count)
        {
            int selection = 0;
            try
            {
                if (count < 1)
                Console.WriteLine("Which time do you want me to speak?");
                Console.Write("Key-in '1' for System Time,'2' for UserInputTime: ");
                String userInput = new ConsoleWrapper().ReadLine();
                count++;
                selection = int.Parse(userInput);
                if (selection < 1 || selection > 2)
                {
                    throw new Exception("Invalid selection");
                }
                return selection;
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input");
                if (count > 3)
                {
                    Console.WriteLine("Count tries exceeded: Invalid User Response: "+ e.Message);
                    throw e;
                }
                return getUserInput(count);
            }
        }
    }
}


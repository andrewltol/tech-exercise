using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrownPeak_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Query and receive input from user.
            Console.WriteLine("Enter number to spiral.  Use whole numbers.  Partial numbers and letters will not be accepted. ");
            string consoleInput = Console.ReadLine();

            // Validate entry was number.
            int number;
            if (!int.TryParse(consoleInput, out number))
            {
                Console.WriteLine("Invalid value received.");
            }
            else
            {
                SpiralCountdown countdown = new SpiralCountdown(number);
                countdown.PrintSpiral();
            }

            WaitForClose();
        }

        static void WaitForClose()
        {
            Console.WriteLine("Press enter key to close program...");
            Console.ReadLine();
        }
    }
}

using System;

namespace SplitOrder
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            CalcSplitOrder calc = new CalcSplitOrder();
    
            Console.WriteLine("This program will split an order/bill as evenly as possible between a specified number of people.");
            bool runCalc = true;
            while(runCalc)
            {
                Console.WriteLine("Please enter the number of people: ");
                int numPeople;
                bool success = Int32.TryParse(Console.ReadLine(), out numPeople);
                while (!success)
                {
                    Console.WriteLine("You must enter an integer for the number of people.");
                    Console.WriteLine("Please enter the number of people: ");
                    success = Int32.TryParse(Console.ReadLine(), out numPeople);
                }
                Console.WriteLine("Please enter the order/bill amount: ");
                double orderTotal;
                success = double.TryParse(Console.ReadLine(), out orderTotal);
                while (!success)
                {
                    Console.WriteLine("You must enter a decimal value for the order total.");
                    Console.WriteLine("Please enter the order/bill amount: ");
                    success = double.TryParse(Console.ReadLine(), out orderTotal);
                }
                try
                {
                    var ord = calc.SplitOrder(numPeople, orderTotal);
                    Console.WriteLine("Split order between " + numPeople + " people");
                    Console.WriteLine("[{0}]", string.Join(", ", ord));
                    Console.WriteLine("Order Total ");
                    Console.WriteLine(orderTotal);

                }
                catch (Exception)
                {
                    Console.WriteLine("Error: The sum of the array doesn't equal the order.");
                }
                Console.WriteLine("To run another calculation type: y");
                Console.WriteLine("To exit the program enter any other key");
                string calcAgain = Console.ReadLine();
                if(calcAgain == "y")
                {
                    runCalc = true;
                } 
                else
                {
                    runCalc = false;
                }
            }
            
        }
    }
}

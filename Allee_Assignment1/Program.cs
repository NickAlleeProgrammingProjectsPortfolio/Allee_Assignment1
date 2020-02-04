using System;

namespace Allee_Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            int stopper = 0;
            while (stopper == 0)
            {
                Console.WriteLine("**** Welcome to B&B Theatre ****");

                Console.WriteLine("Please enter the full name:");
                var name = Console.ReadLine();

                while (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Sorry, Please enter your name?");
                    name = Console.ReadLine();
                }


                Console.WriteLine("Please enter your age?");
                var age = Console.ReadLine();

                while (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Sorry, Please enter your age?");
                    name = Console.ReadLine();
                }
                int intAge;
                while (int.TryParse(age, out intAge))
                {
                    if (intAge < 15)
                    {
                        Console.WriteLine("Your Age is below 15, you cannot book ticket online. Please talk to your parent or guardian!!");
                        stopper = 1;
                    }
                    if (intAge > 90)
                    {
                        Console.WriteLine("You are too old to watch a movie, sorry!");
                        stopper = 1;
                    }
                }
            }

        }
    }
}

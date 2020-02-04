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
                list<int> ticketsWanted;
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
                if (ageChecker(age) == 1)
                {
                    while (ticketsWanted.Length < 3)
                    {
                        // a ticket with the number 4 indicates a 3d movie with 3d glasses
                        ticketsWanted.Append(ticketOfferer());
                    }
                    
                }

                

                }
        }
        public static int ticketOfferer()
        {
            Console.WriteLine("1. Standard");
            Console.WriteLine("2. Imax");
            Console.WriteLine("3. Imax-3D");
            Console.WriteLine("Please enter the type of movie you would like to see?");
            var moviePick = Console.ReadLine();

            while (string.IsNullOrEmpty(moviePick))
            {
                Console.WriteLine("Sorry, Please enter the type of movie you would like to see?");
                moviePick = Console.ReadLine();
            }
            int intMoviePick;
            // while age is not an int
            while (!int.TryParse(moviePick, out intMoviePick))
            {
                Console.WriteLine("the number must be between 1 and 3");
                moviePick = Console.ReadLine();

            }
            // while its not between 1 and 3
            while (!(intMoviePick < 4 || intMoviePick > 0))
            {
                Console.WriteLine("the number must be between 1 and 3");
                return ticketOfferer();

            }

            if (intMoviePick == 3)
            {
                Console.WriteLine("do you want 3d glasses? (y/n)");
                string pick = Console.ReadLine();
                if (pick == "y")
                {
                    return 4;
                }

            }

            return intMoviePick;
        }

        public static int ageChecker(string age)
        {
            while (string.IsNullOrEmpty(age))
            {
                Console.WriteLine("Sorry, Please enter your age?");
                age = Console.ReadLine();
            }
            int intAge;
            // while age is an int
            while (!(int.TryParse(age, out intAge)))
            {
                Console.WriteLine("Sorry, Please enter your age?");
                age = Console.ReadLine();
            }
            if (intAge < 15)
            {
                Console.WriteLine("Your Age is below 15, you cannot book ticket online. Please talk to your parent or guardian!!");
                return 0;
            }
            if (intAge > 90)
            {
                Console.WriteLine("You are too old to watch a movie, sorry!");
                return 0;
            }
            else
            {
                return 1;
            }
        }

        
    }
}

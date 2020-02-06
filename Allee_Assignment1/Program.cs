using System;
using System.Collections.Generic;

namespace Allee_Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            introLine();
            // now call age checker. mabye make each function call the next???
        }
        public static void introLine()
        {
            Console.WriteLine("**** Welcome to B&B Theatre ****");
            nameChecker();
        }

        public static void nameChecker()
        {
            Console.WriteLine("Please enter the full name:");
            var Name = Console.ReadLine();

            while (string.IsNullOrEmpty(Name))
            {
                Console.WriteLine("Sorry, Please enter your name?");
                Name = Console.ReadLine();
            }
            ageChecker(Name);
        }

        public static void ageChecker(String Name)
        {
            Console.WriteLine("Please enter your age?");
            var age = Console.ReadLine();

            while (string.IsNullOrEmpty(age))
            {
                Console.WriteLine("Sorry, Please enter your age?");
                age = Console.ReadLine();
            }
            int intAge;
            // while age is not an int
            while (!(int.TryParse(age, out intAge)))
            {
                Console.WriteLine("Sorry, Please enter your age?");
                age = Console.ReadLine();
            }
            if (intAge < 15)
            {
                Console.WriteLine("Your Age is below 15, you cannot book ticket online. Please talk to your parent or guardian!!");
                exitLine();
            }
            if (intAge > 90)
            {
                Console.WriteLine("You are too old to watch a movie, sorry!");
                exitLine();
            }
            else
            {
                ticketOfferer(Name);
            }
        }



        public static void ticketOfferer(String Name)
        {
            var ticketsWanted = new List<int> { };
            int again = 1;
            while (again == 1)
            {
                if (ticketsWanted.Count < 3)
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
                    // while age is not an int and its not less than 3 or greater than 0
                    while (!(int.TryParse(moviePick, out intMoviePick)) && !(intMoviePick < 3 || intMoviePick > 0))
                    {
                        Console.WriteLine("the number must be between 1 and 3");
                        moviePick = Console.ReadLine();

                    }

                    if (intMoviePick == 3)
                    {
                        Console.WriteLine("do you want 3d glasses? (y/n)");
                        string pick = Console.ReadLine();
                        if (pick == "y")
                        {
                            ticketsWanted.Add(4);
                        }

                    }
                    // ask how many they want with a new function called howManyTickets
                    // max amount of tickets should be count of 3 - ticketsWanted
                    // for int i =0; i <= result of (howManyTickets);i++ then add the moviepick
                    ticketsWanted.Add(intMoviePick);

                    Console.WriteLine("Do you want to continue again (y/n)?");
                    var yesOrNo = Console.ReadLine();
                    if (yesOrNo == "n")
                    {
                        again = 0;

                    }


                }
                else
                {
                    Console.WriteLine("You can only buy 1 or 2 or 3 tickets per transaction. Sorry!!");
                    again = 0;
                }
            }
            totaler(Name, ticketsWanted);

        }

 


        public static void totaler(String Name, List<int> movieTickets)
        {
            Console.WriteLine(Name + " Total Number of Tickets are: " + movieTickets.Count);
            Double TotalAmount = 0;
            Decimal cost = 7.85m;
            foreach (int ticket in movieTickets)
            {
                if (ticket == 1) { TotalAmount += Decimal.ToDouble(cost); }
                if (ticket == 2) { TotalAmount += Decimal.ToDouble(cost); }
                if (ticket == 3) { TotalAmount += Decimal.ToDouble(cost); }
                if (ticket == 4) { TotalAmount += Decimal.ToDouble(cost) + 2.0; }
            }
            Console.WriteLine(Name + ", your total is: " + TotalAmount);
            exitLine();
        }

        public static void exitLine()
        {
            Console.WriteLine("Thank you! and have a nice day.");
        }





    }
}


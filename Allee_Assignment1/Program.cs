using System;
using System.Collections.Generic;

namespace Allee_Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            introLine();
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
            var ticketsWanted = new List<int> {};

            // use this variable to end the ticket offerer
            int again = 1;
            while (again == 1)
            {
                if (ticketsWanted.Count < 3)
                {

                    Console.WriteLine("1. Standard");
                    Console.WriteLine("2. Imax");
                    Console.WriteLine("3. Imax-3D");
                    Console.WriteLine("Please enter the number associated with the type of movie you would like to see?");
                    var moviePick = Console.ReadLine();

                    int intMoviePick = 0;
                    int.TryParse(moviePick, out intMoviePick);
                    while (string.IsNullOrEmpty(moviePick))
                    {
                        Console.WriteLine("Sorry, Please enter the number associated with the type of movie you would like to see?");
                        moviePick = Console.ReadLine();

                        
                        // while age is not an int and its not less than 3 or greater than 0
                        while (!(int.TryParse(moviePick, out intMoviePick)) && !(intMoviePick < 3 || intMoviePick > 0))
                        {
                            Console.WriteLine("the number must be between 1 and 3");
                            moviePick = Console.ReadLine();

                        }
                    }

                    string pick = "";

                    if (intMoviePick == 3)
                    {
                        Console.WriteLine("do you want 3d glasses? (y/n)");
                        pick = Console.ReadLine();
                        

                    }
                    // find out how many tickets the user wants of that particular type of movie
                    string amtOfTickets = howManyTickets(ticketsWanted);
                    int intAmtOfTickets = Int32.Parse(amtOfTickets);
                    // ask how many they want with a new function called howManyTickets
                    // max amount of tickets should be count of 3 - ticketsWanted
                    for (int i = 0; i < (intAmtOfTickets); i++)
                    {
                        if (pick == "y")
                        {
                            ticketsWanted.Add(4);
                        }
                        else
                        {
                            ticketsWanted.Add(intMoviePick);
                        }
                    }
                    Console.WriteLine("Do you want to continue again (y/n)?");
                    var yesOrNo = Console.ReadLine();
                    if (yesOrNo == "n")
                    {
                        again = 0;

                    }


                }
                else
                {
                    Console.WriteLine("You can only buy 1 or 2 or 3 tickets per transaction. Right now you have " + ticketsWanted.Count + " tickets in your cart.");
                    again = 0;
                }
            }
            totaler(Name, ticketsWanted);

        }

        public static string howManyTickets(List<int> ticketsWanted)
        {
            string numberOfTickets = "";
            while (string.IsNullOrEmpty(numberOfTickets))
            {
                Console.WriteLine("Enter number of tickets");
                numberOfTickets = Console.ReadLine();
            }
            int intNumOfTickets = Int32.Parse(numberOfTickets);
            while (intNumOfTickets > 3 - ticketsWanted.Count)
            {
                Console.WriteLine("cant have more than 3 total tickets. Right now you have " + ticketsWanted.Count + " tickets.");
                numberOfTickets = Console.ReadLine();
                intNumOfTickets = Int32.Parse(numberOfTickets);
            }
            return numberOfTickets;
        }
 


        public static void totaler(String Name, List<int> movieTickets)
        {
            Console.WriteLine("Total Number of Tickets you would like: " + movieTickets.Count);
            Double TotalAmount = 0;
            Decimal cost = 7.85m;
            foreach (int ticket in movieTickets)
            {
                if (ticket == 1) { TotalAmount += Decimal.ToDouble(cost);
                    Console.WriteLine("1 ticket for standard. --- $" + cost);
                }
                if (ticket == 2) { TotalAmount += Decimal.ToDouble(cost);
                    Console.WriteLine("1 ticket for Imax. --- $" + cost);
                }
                if (ticket == 3) { TotalAmount += Decimal.ToDouble(cost);
                    Console.WriteLine("1 ticket for Imax-3D with no 3D glasses. --- $" + cost);
                }
                if (ticket == 4) { TotalAmount += Decimal.ToDouble(cost) + 2.0;
                    Console.WriteLine("1 ticket for Imax-3D with 3D glasses. --- $" + (cost +2));
                }
            }
            Console.WriteLine(Name + ", your total cost is: $" + TotalAmount);
            exitLine();
        }

        public static void exitLine()
        {
            Console.WriteLine("Thank you! and have a nice day. \n enter 1 to restart the program or anything else to exit");
            var restart = Console.ReadLine();
            if (restart == "1")
            {
                introLine();
            }
            else
            {
                Console.WriteLine("Goodbye!");
            }
        }





    }
}


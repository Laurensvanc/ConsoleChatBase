using System;

namespace CSEindOpdrachtSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Laurens Console.");
            Console.WriteLine("Press any key to start the program.");
            Console.ReadKey();

            Console.Clear();

            Console.WriteLine("Please enter your Username.");
            string userName = Console.ReadLine();

            Console.WriteLine("Username is: " + userName);


            Console.ReadKey();
        }
    }
}

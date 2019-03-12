using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ---------------------------------------------------------------------------
/// PART ONE:  PRINTING OUT PRIME NUMBERS BETWEEN SPECIFIED RANGE
// ---------------------------------------------------------------------------

namespace ISM6225_AssignmentOne
{   /// <summary>
    /// Class to check if intger values are prime numbers
    /// based on AKS Primality Test https://en.wikipedia.org/wiki/AKS_primality_test
    /// </summary>
    class CalculatePrime
    {
        // Store the first 100 prime numbers for speed purposes
        private int[] first_primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29
                                    , 31, 37, 41, 43, 47, 53, 59, 61, 67
                                    , 71, 73, 79, 83, 89, 97 };


        public CalculatePrime()
        {
            //constructor
        }

        /// <summary>
        /// Will calculate if the number is a prime number
        /// checks against the list for the prime number between 1 and 100 first
        /// if greater than 100 manually calculates the prime number
        /// </summary>
        /// <param name="CheckNumber">Integer</param>
        /// <returns>Boolean indicating if number is prime or not</returns>
        private Boolean IsPrime(int CheckNumber)
        {
            // check if the number is below 100
            if (CheckNumber <= 100)
            {
                // check if the number is in the list of prime numbers
                return ((first_primes.Contains(CheckNumber) ? true : false));
            }

            // for numbers greater than 100
            // check if value can be divided by 2 or 3
            if(CheckNumber % 2 == 0 || CheckNumber % 3 == 0)
            {
                return (false);
            }

            // now need to brute force if we get a mod == 0
            // variant of O(sqrt(n))
            int incrementer = 5;
            int baseval = 2;
            while(incrementer * incrementer <= CheckNumber)
            {
                // if mod == 0 then we know it isn't a prime
                if (CheckNumber % incrementer == 0)
                {
                    return (false);
                }
                incrementer += baseval;
                baseval = 6 - baseval;
            }
            return (true);
        }

        /// <summary>
        /// Make sure the value entered by the user is a valid integer
        /// </summary>
        /// <param name="test_number">String</param>
        /// <returns>Boolean</returns>
        public Boolean CheckValidInput(string test_number)
        {
            if(Int32.TryParse(test_number, out int valid_number))
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        /// <summary>
        /// Print out the prime numbers between the start and end of the range
        /// </summary>
        /// <param name="x">Integer value - start of range</param>
        /// <param name="y">Integer value - end of range</param>
        public void PrintPrimeNumbers(int x, int y)
        {
            // list to hold all the values that are prime
            List<String> prime_list = new List<String>();

            // string to output to the user
            var prime_numbers = new System.Text.StringBuilder();

            // check to make sure x < y; otherwise use a tuple reorder 
            if (y < x)
            {
                (x, y) = (y, x);
            }

            // Loop from x to y incrementing by 1
            while (x < y)
            {
                if(IsPrime(x) == true)
                {
                    prime_list.Add(x.ToString());
                }
                x++;
            }

            // concat the string if we find 1 or more prime numbers
            if (prime_list.Count() >= 1)
            {
                // build the list into one string
                prime_numbers.AppendJoin(",", prime_list);

                // output the list to the console window
                Console.WriteLine(prime_numbers);
            }
            // let user know, that no prime numbers were found
            else
            {
                Console.WriteLine("No prime numbers found.");
            }
        }


        /// <summary>
        /// Get the user input; two integers 
        /// Test if the values are integers; else throw an exception
        /// </summary>
        public void RunCalculatePrime()
        {
            // get the user input for the first and second number
            Console.WriteLine("Enter in first number");
            string first_number = Console.ReadLine();

            Console.WriteLine("Enter in second number");
            string second_number = Console.ReadLine();


            // check if the values are integers; else throw an exception
            try
            {
                if (CheckValidInput(first_number) && CheckValidInput(first_number))
                {
                    // pass the values to the method to print out the prime numbers
                    PrintPrimeNumbers(Int32.Parse(first_number), Int32.Parse(second_number));
                }
                else
                {
                    // throw the exception and exit to the menu loop
                    throw new FormatException();
                }
            }
            catch (FormatException)
            {
                // throw the exception and exit to the menu loop
                Console.WriteLine("Invalid User Input; values are not integers");
            }
        }

    }
}

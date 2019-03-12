using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

// ---------------------------------------------------------------------------
/// PART TWO:  PRINTING OUT VALUE FROM THE SERIES OF NUMBERS
// ---------------------------------------------------------------------------

namespace ISM6225_AssignmentOne
{
    class SumSeries
    {
        /// <summary>
        /// Calculate the factorial of the number
        /// </summary>
        /// <param name="fact_number">double</param>
        /// <returns>double</returns>
        private double CalcFactorial(double fact_number)
        {
            double calc_factorial = 1;
            // loop through in reverse order to calculate factorial
            while (fact_number > 1)
            {
                calc_factorial = calc_factorial * fact_number;
                fact_number--;
            }
            return (calc_factorial);
        }

        /// <summary>
        /// Make sure the value entered by the user is a valid integer
        /// </summary>
        /// <param name="test_number">String</param>
        /// <returns>Boolean</returns>
        public Boolean CheckValidInput(string test_number)
        {
            if (Int32.TryParse(test_number, out int valid_number))
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        /// <summary>
        /// Calculate the series value specified
        /// </summary>
        /// <param name="n">integer</param>
        /// <returns>double</returns>
        public double GetSeriesResult(int n)
        {
            // assign the base values for the nominator and denominator in the series
            double nominator = 1;
            double denominator = 2;
            double series_sum = 0;

            // if user entered in 1; immediately exit with a value of 1
            if (n == 1)
            {
                return 1;
            }

            // loop through n times alternating between adding or subtracting to the series sum
            while(nominator <= n)
            {
                if (denominator % 2 == 0)
                {
                    series_sum = series_sum + (CalcFactorial(nominator) / denominator);
                }
                else
                {
                    series_sum = series_sum - (CalcFactorial(nominator) / denominator);
                }
                nominator++;
                denominator++;
            }
            return (series_sum);
        }

        /// <summary>
        /// Get the user input; one integers 
        /// Test if the value is an integer; else throw an exception
        /// </summary>
        public void RunSumSeries()
        {
            // get the user input 
            Console.WriteLine("Enter in series number");
            string series_number = Console.ReadLine();
            try
            {
                // if a valid input sum up the series number
                if (CheckValidInput(series_number))
                {
                    double sum_result = 0;
                    sum_result = GetSeriesResult(Int32.Parse(series_number));

                    // output to the console and format the string with 3 decimal places
                    Console.WriteLine("Sum of series: " + sum_result.ToString(format: "#.000"));
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

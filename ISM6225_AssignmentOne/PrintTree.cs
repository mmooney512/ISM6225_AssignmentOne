using System;
using System.Collections.Generic;
using System.Text;

// ---------------------------------------------------------------------------
// PART THREE:  PRINTING OUT STAR TREE
// ---------------------------------------------------------------------------

namespace ISM6225_AssignmentOne
{
    class PrintTree
    {
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
        /// Print out the values to console
        /// </summary>
        /// <param name="n"></param>
        private static void PrintTriangle(int n)
        {
            StringBuilder printStars = new StringBuilder();
            int row_counter = n - 1;

            // loop through and append spaces and astericks 
            for(int loop_counter =1; loop_counter <= n; loop_counter++ )
            {
                printStars.Append(' ', row_counter);
                printStars.Append('*', 2 * loop_counter - 1);
                printStars.Append(Environment.NewLine);
                row_counter--;
            }
            Console.WriteLine(printStars);
        }

        /// <summary>
        /// Get the user input; one integers 
        /// Test if the value is an integer; else throw an exception
        /// </summary>
        public void RunPrintTree()
        {
            Console.WriteLine("Enter in number of rows for the tree");
            string tree_rows = Console.ReadLine();
            try
            {
                // if a valid input sum up the series number
                if (CheckValidInput(tree_rows))
                {
                    PrintTriangle(Int32.Parse(tree_rows));
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

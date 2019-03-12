using System;
using System.Collections.Generic;
using System.Text;

namespace ISM6225_AssignmentOne
{
    /// <summary>
    /// create a text based menu -- looping through 
    /// until the user decides to exit
    /// </summary>
    class ProgramMenu
    {
        /// <summary>
        /// Parse the user's input making sure it is an integer value
        /// and between value of 1 and 4
        /// </summary>
        /// <param name="menu_option"></param>
        /// <returns></returns>
        private int ParseMenuOption(string menu_option)
        {
            try
            {
                // check if user entered in an integer
                if (Int32.TryParse(menu_option, out int valid_number))
                {
                    if (valid_number >= 1 && valid_number <= 4)
                    {
                        return (valid_number);
                    }
                }
                else
                {
                    throw new FormatException();
                }
                return (0);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid User Input; values are not integers; exiting program.");
                return (0);
            }
        }
        
        /// <summary>
        /// Parse the user input selection; if valid run the appropriate sub-program
        /// </summary>
        /// <param name="menu_option"></param>
        private void RunProgram(int menu_option)
        {
            switch(menu_option)
            {
                case 1:
                    Console.WriteLine("Option 1 Calculate range of prime numbers");
                    CalculatePrime calc_prime = new CalculatePrime();
                    calc_prime.RunCalculatePrime();
                    break;
                case 2:
                    Console.WriteLine("Option 2 Sum of the Series");
                    SumSeries sumSeries = new SumSeries();
                    sumSeries.RunSumSeries();
                    break;
                case 3:
                    Console.WriteLine("Option 3 Print Star Tree");
                    PrintTree printTree = new PrintTree();
                    printTree.RunPrintTree();
                    break;
                case 4:
                    Console.WriteLine("Option 4 Frequency of Array Elements");
                    ShowFrequency showFrequency = new ShowFrequency();
                    showFrequency.RunShowFrequency();
                    break;
                default:
                    break;
            }

        }
        /// <summary>
        /// show the menu to the user with the available options
        /// </summary>
        public void ShowMenu()
        {
            StringBuilder main_menu = new StringBuilder();
            var newline = Environment.NewLine;
            int menu_option = 1;

            main_menu.Append("Please enter in a menu option (1-4)" + newline);
            main_menu.Append("Option 1 Calculate range of prime numbers" + newline);
            main_menu.Append("Option 2 Sum of the Series" + newline);
            main_menu.Append("Option 3 Print Star Tree" + newline);
            main_menu.Append("Option 4 Frequency of Array Elements" + newline);
            main_menu.Append("Option 0 End Program");

            // loop through so user can select multiple programs
            while (menu_option >= 1 && menu_option <= 4)
            {
                // get the user input on the menu option
                Console.WriteLine(main_menu);
                string menu_input = Console.ReadLine();

                // verify user entered in a valid menu option
                menu_option = ParseMenuOption(menu_input);
                RunProgram(menu_option);
            }
        }
    }
}

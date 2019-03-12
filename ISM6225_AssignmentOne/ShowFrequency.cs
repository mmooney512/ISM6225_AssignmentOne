using System;
using System.Collections.Generic;
using System.Text;

// ---------------------------------------------------------------------------
// PART THREE:  PRINTING OUT HISTOGRAM
// ---------------------------------------------------------------------------

namespace ISM6225_AssignmentOne
{
    /// <summary>
    /// Creates a histogram stored in a dictionary object 
    /// based on input in a comma separated array
    /// </summary>
    class ShowFrequency
    {
        private Dictionary<int, int> userValues = new Dictionary<int, int>();
        /// <summary>
        /// use a dictionary object to create the histogram of values
        /// </summary>
        /// <param name="a"></param>
        public void ComputeFrequency(List<int> a)
        {
            
            foreach (int userinput in a)
            {
                // if the value exists update the count in the value of the dictionary
                // else add the value to the dictionary
                if (userValues.ContainsKey(userinput))
                {
                    userValues[userinput] = userValues[userinput] + 1;
                }
                else
                {
                    userValues.Add(userinput, 1);
                }
            }
        }

        /// <summary>
        /// output the histogram to the console using foreach loop
        /// </summary>
        private void OutputCounts()
        {
            Console.WriteLine("Number\t\tFrequency");
            foreach(KeyValuePair<int,int> userValue in userValues)
            {
                Console.WriteLine("{0}\t\t{1}", userValue.Key, userValue.Value);
            }
        }


        /// <summary>
        /// Get the user input; array of integers separated by commas 
        /// Test if each of the values are an integer; else throw an exception
        /// </summary>
        public void RunShowFrequency()
        {
            List<int> user_numbers = new List<int>();

            // get the user's input 
            Console.WriteLine("Enter in integer array separated by commas ex:  1,5,4,1,2,1");
            string user_array = Console.ReadLine();

            // split user's input into tokens based on the comma separator
            string[] user_tokens = user_array.Split(",");

            try
            {
                // add to the list; checking if an integer
                foreach (string input in user_tokens)
                {
                    user_numbers.Add(Int32.Parse(input));
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid User Input; values are not integers");
            }

            // add to the dictionary object
            ComputeFrequency(user_numbers);

            // print out the histogram
            OutputCounts();
        }
    }
}

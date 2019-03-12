using System;
using System.Diagnostics;


namespace ISM6225_AssignmentOne
{
    class Program
    {
        static void Main(string[] args)
        {
            // will use the program menu to allow user to select sub-programs
            // and loop back and re-run sub-programs if they want.

            ProgramMenu programMenu = new ProgramMenu();
            programMenu.ShowMenu();

            // exit the program and goodbye
            Console.WriteLine("Goodbye");
        }
    }
}

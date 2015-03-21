using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment5_fileIO_Exception
{
    class Program
    {
        static void Main(string[] args)
        {
            menuMethod();
        }
        //++++++++++++++++++++Menu Method++++++++++++++++++++++++++++++++++++++++++++++++
        private static void menuMethod()
        {
            string pathName = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName; //declear the current path as a pathName
            string fileName = "GradeFile.txt"; //declear the file name

            int choice = 0; //declear local variable for choice

            while (choice != 2) //while loop menu
            {
                Console.WriteLine("+++++++++++++++++++++++++++");
                Console.WriteLine("+           Menu          +");
                Console.WriteLine("+     1.Display Grades    +");
                Console.WriteLine("+     2.Exit              +");
                Console.WriteLine("+++++++++++++++++++++++++++");
                Console.Write("Enter your choice: ");

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception error)
                {
                    choice = 0;
                    Console.WriteLine(error.Message);
                }
                switch (choice)
                {
                    case 1:
                        WriteFileMethod(pathName, fileName); //created the text file
                        fileCheck(); //check file if exist
                        ReadFileMethod(pathName, fileName); //display the file on console
                        break;
                    case 2://select to exit
                        Console.WriteLine();
                        break;
                    default: //display incorrect input message
                        Console.WriteLine();
                        Console.WriteLine("Incorrect input, please try again!");
                        Console.WriteLine();
                        WaitForKey(); //if incorrect input, then display wait for key info
                        break;
                }
                Console.Clear(); //clear the screen

            }
        }
        //++++++++++++++++++++++FileCheck Method++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private static void fileCheck()
        {
            string prompt;
            Console.Write("Please enter a file name: ");
            prompt = Console.ReadLine();
            Console.WriteLine();

            if (File.Exists(prompt))
            {
                Console.WriteLine("The File Exists");
                Console.WriteLine();
                Console.WriteLine("File Stats:");
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("Create Time: " + File.GetCreationTime(prompt));
                Console.WriteLine("Last Access: " + File.GetLastAccessTime(prompt));
                Console.WriteLine("Last Write : " + File.GetLastWriteTime(prompt));
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++");

            }
            else
            {
                Console.WriteLine("No such file");
            }
            WaitForKey();
        }

    }
}

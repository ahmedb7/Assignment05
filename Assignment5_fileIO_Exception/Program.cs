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
        //Menu Method
        private static void menuMethod()
        {
            string pathName = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName; //declares the current path as pathName
            string fileName = "GradeFile.txt"; //declares the file name

            int choice = 0; 

            while (choice != 2) 
            {
                Console.WriteLine("+++++++++++++++++++++++++++");
                Console.WriteLine("+          Menu           +");
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
                        fileWriteMethod(pathName, fileName); //created the text file
                        fileCheck(); //check file
                        fileReadMethod(pathName, fileName); //display the file on console
                        break;
                    case 2:
                        Console.WriteLine();
                        break;
                    default: 
                        Console.WriteLine();
                        Console.WriteLine("Incorrect entry, please try again!");
                        Console.WriteLine();
                        WaitForKey(); 
                        break;
                }
                Console.Clear(); 

            }
        }
        //FileCheck Method
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

        //WriteFile Method
        private static void fileWriteMethod(string pathName, string fileName)
        {

            try
            {
                FileStream outFile = new FileStream(pathName + fileName, FileMode.Create, FileAccess.Write); //created a outFile in current path
                StreamWriter writer = new StreamWriter(outFile); //declares a wirter variable

                
                string[] firstName = { "Jones", "Johnson", "Smith" };
                string[] lastName = { "Bob", "Sarah", "Sam" };
                int[] ID = { 1, 2, 3 };
                string[] classes = { "Introduction to Computer Science", "Data Structures", "Data Structures" };
                string[] grade = { "A-", "B+", "C" };

                
                for (int i = 0; i < 3; i++)
                {
                    writer.WriteLine("{0}, {1}: {2} {3}, {4}", firstName[i], lastName[i], ID[i], classes[i], grade[i]);
                }

                writer.Close(); // closes the file
                outFile.Close(); // closes the  file stream
            }
            catch (Exception error)
            {
                Console.WriteLine("Your code caused has caused an error!!!");
                Console.WriteLine("Error: {0} ", error.Message);
            }
        }

        //File Read Method
        private static void fileReadMethod(string pathName, string fileName)
        {
            string fileData = "";
            string[] fileArray = new string[10];
            try
            {
                FileStream inFile = new FileStream(pathName + fileName, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);

                for (int row = 0; row < 10; row++)
                {
                    fileData = reader.ReadLine();
                    fileArray[row] = fileData;

                    Console.WriteLine("Your Data: {0}", fileData);
                } 
                reader.Close(); // closes the file
                inFile.Close(); // closes the  file stream
            }
            catch (Exception error)
            {
                Console.WriteLine("Your code caused a darn error!!!");
                Console.WriteLine("Error: {0} ", error.Message);

            }
        }


        
        private static void WaitForKey()
        {
            Console.WriteLine();
            Console.WriteLine("++++++++++++++++++++++++++++++++++");
            Console.WriteLine("   Press any key to continue...   ");
            Console.WriteLine("++++++++++++++++++++++++++++++++++");
            Console.ReadKey();
            Console.Clear();
        }



    }

    
}

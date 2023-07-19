using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day_8_assign10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = "D:\\Training File\\File Nancy\\";

            while (true)
            {
                Console.WriteLine("Choose an operation:");
                Console.WriteLine("1. Create a new file");
                Console.WriteLine("2. Read a file");
                Console.WriteLine("3. Append to a file");
                Console.WriteLine("4. Delete a file");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter the file name: ");
                        string newFileName = Console.ReadLine();
                        Console.Write("Enter the content: ");
                        string content = Console.ReadLine();
                        string newFilePath = Path.Combine(directoryPath, newFileName);
                        CreateFile(newFilePath, content);
                        break;

                    case "2":
                        Console.Write("Enter the file name to read: ");
                        string readFileName = Console.ReadLine();
                        string readFilePath = Path.Combine(directoryPath, readFileName);
                        ReadFile(readFilePath);
                        break;

                    case "3":
                        Console.Write("Enter the file name to append: ");
                        string appendFileName = Console.ReadLine();
                        Console.Write("Enter the content to append: ");
                        string contentToAppend = Console.ReadLine();
                        string appendFilePath = Path.Combine(directoryPath, appendFileName);
                        AppendToFile(appendFilePath, contentToAppend);
                        break;

                    case "4":
                        Console.Write("Enter the file name to delete: ");
                        string deleteFileName = Console.ReadLine();
                        string deleteFilePath = Path.Combine(directoryPath, deleteFileName);
                        DeleteFile(deleteFilePath);
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void CreateFile(string filePath, string content)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.Write(content);
                }

                Console.WriteLine($"File '{filePath}' created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while creating file: {ex.Message}");
            }
        }

        static void ReadFile(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string content = reader.ReadToEnd();
                    Console.WriteLine($"Content of file '{filePath}':");
                    Console.WriteLine(content);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File '{filePath}' not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while reading file: {ex.Message}");
            }
        }

        static void AppendToFile(string filePath, string content)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.Write(content);
                }

                Console.WriteLine($"Content appended to file '{filePath}' successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while appending to file: {ex.Message}");
            }
        }

        static void DeleteFile(string filePath)
        {
            try
            {
                File.Delete(filePath);
                Console.WriteLine($"File '{filePath}' deleted successfully.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File '{filePath}' not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while deleting file: {ex.Message}");
            }
        }
    }
         
}

    


    


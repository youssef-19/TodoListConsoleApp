using System;
namespace Todo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the To do list program !");
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("What do you want to do !");
                Console.WriteLine("1. Add Activity ? ");
                Console.WriteLine("2. View Activities ? ");
                Console.WriteLine("3. Delete Activity ? ");
                Console.WriteLine("4. Update Activity ? ");
                Console.WriteLine("5. --->Exit");
                string inn= Console.ReadLine();
                if (inn == "2")
                {
                    Console.WriteLine("------------------------------------");
                    View();
                    Console.WriteLine("------------------------------------");

                }
                else if (inn=="1")
                {
                    Console.Write("Enter the activity you want to add: ");
                    string s= Console.ReadLine();
                    Insert(s);
                }else if (inn=="3")
                {
                    Delete();
                }else if (inn=="5")
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Thanks for using App...");
                    Console.ResetColor();
                    break;
                }else if (inn=="4")
                {    
                    Update();
                }
            }
        }

        private static void Update()
        {
            string flpath = "todo.txt";
            try
            {
                string[] lines = File.ReadAllLines(flpath);
                Console.Write("Enter the line number to update: ");
                if (int.TryParse(Console.ReadLine(), out int liup) && liup >= 1 && liup <= lines.Length)
                {
                    Console.Write("Enter the new text: ");
                    string newText = Console.ReadLine();

                    lines[liup - 1] = newText;
                    File.WriteAllLines(flpath, lines);
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Activity updated successfully.");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid line number.");
                    Console.ResetColor();
                    Console.WriteLine();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
        }
        private static void Delete()
        {
            string flpath = "todo.txt";
            try
            {
                string[] li = File.ReadAllLines(flpath);
                Console.Write("Enter the line number to delete: ");
                Console.WriteLine();
                if (int.TryParse(Console.ReadLine(), out int lide) && lide >= 1 && lide <= li.Length)
                {
                    string[] newl = new string[li.Length - 1];
                    int newind = 0;
                    for (int i = 0; i < li.Length; i++)
                    {
                        if (i + 1 != lide)
                        {
                            newl[newind] = li[i];
                            newind++;
                        }
                    }
                    File.WriteAllLines(flpath, newl);
                    Console.BackgroundColor= ConsoleColor.Green;
                    Console.WriteLine("Activity deleted successfully..");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid line number..");
                    Console.ResetColor();
                    Console.WriteLine();
                }
            } catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }

        }
        private static void Insert(string s)
        {
            string flpath = "todo.txt";
            File.AppendAllText(flpath, s+ Environment.NewLine);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Added successfully ..");
            Console.WriteLine();
            Console.ResetColor();
        }
        private static void View()
        {
            string flpath = "todo.txt";
            try
            {
                int j = 1;
                string[] li = File.ReadAllLines(flpath);
                foreach (var i in li)
                {
                    Console.BackgroundColor=ConsoleColor.Blue;
                    Console.WriteLine($"{j}-{i}");
                    j++;
                }
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
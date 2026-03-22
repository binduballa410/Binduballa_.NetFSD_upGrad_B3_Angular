using System;
namespace ConsoleApp2
{
    class Class1
    {
        static List<string> tasks = new List<string>();
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nTo-Do List Manager");
                Console.WriteLine("1.Add Task");
                Console.WriteLine("2.View Task");
                Console.WriteLine("3.Remove Task");
                Console.WriteLine("Exit");
                Console.WriteLine("Coose an option:");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        ViewTask();
                        break;
                    case "3":
                        RemoveTask();
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.Please try again.");
                        break;

                }
            }
        }
        static void AddTask()
        {
            Console.WriteLine("Enter task: ");
            string task = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(task))
            {
                tasks.Add(task);
                Console.WriteLine("Task added!");
            }
            else
            {
                Console.WriteLine("Error: Task description cannot be empty.");
            }

        }
        static void ViewTask()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("The list is empty.");
                return;
            }
            Console.WriteLine("\nTasks: ");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1} {tasks[i]}");
            }
        }
        static void RemoveTask()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Nothing to remove.The list is empty.");
                return;
            }
            Console.WriteLine("Enter task number to remove: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int taskNumber))
            {
                int index = taskNumber - 1;
                if (index >= 0 && index < tasks.Count)
                {
                    string removedTask = tasks[index];
                    tasks.RemoveAt(index);
                    Console.WriteLine($"Removed: {removedTask}");
                }
                else
                {
                    Console.WriteLine("Invalid task number.");
                }
            }
            else
            {
                Console.WriteLine("Error: Please enter a valid numeric task number.");
            }
        }
    }
}
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();

            int id = 0;
            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Add a task");
                Console.WriteLine("2. View tasks");
                Console.WriteLine("3. Edit a task");
                Console.WriteLine("4. Mark a task as completed");
                Console.WriteLine("0. Exit");
                string response = Console.ReadLine();

                switch (response)
                {
                    case "1":
                        Console.WriteLine("Enter the title of your task:");
                        string title = Console.ReadLine();
                        Console.WriteLine("Enter the description of your task:");
                        string description = Console.ReadLine();
                        taskManager.AddTask(new Task(id++, title, description));
                        break;
                    case "2":
                        Console.WriteLine("Viewing task list...");
                        taskManager.ViewTasks();
                        break;
                    case "3":
                        Console.WriteLine("Enter the ID of the task you want to edit:");
                        if (int.TryParse(Console.ReadLine(), out int taskId))
                        {
                            Console.WriteLine("Enter the new title of the task:");
                            string newTitle = Console.ReadLine();
                            Console.WriteLine("Enter the new description of the task:");
                            string newDescription = Console.ReadLine();
                            taskManager.EditTask(taskId, newTitle, newDescription);
                        }
                        else
                        {
                            Console.WriteLine("Invalid task ID.");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Viewing task list...");
                        taskManager.ViewTasks();
                        Console.WriteLine("Enter the ID of the task you want to mark as completed:");
                        if (int.TryParse(Console.ReadLine(), out int completeTaskId))
                        {
                            taskManager.MarkTaskAsCompleted(completeTaskId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid task ID.");
                        }
                        break;
                    case "0":
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }
        }
    }

    class TaskManager
    {
        List<Task> tasks = new List<Task>();

        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

        public void ViewTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks found.");
            }
            else
            {
                Console.WriteLine("All tasks:");
                foreach (var task in tasks)
                {
                    Console.WriteLine($"ID: {task.Id} \nTitle: {task.Title}\nDescription: {task.Description}\nStatus: {(task.IsCompleted ? "Completed" : "Pending")}\n");
                }
            }
        }

        public void EditTask(int taskId, string newTitle, string newDescription)
        {
            Task task = tasks.Find(t => t.Id == taskId);
            if (task != null)
            {
                task.Title = newTitle;
                task.Description = newDescription;
                Console.WriteLine("Task edited successfully!");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }

        public void MarkTaskAsCompleted(int taskId)
        {
            Task task = tasks.Find(t => t.Id == taskId);

            if (task != null)
            {
                task.IsCompleted = true;
                Console.WriteLine("Task marked as completed!");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }
    }

    class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public Task(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
            IsCompleted = false; // By default, tasks are initialized as not completed
        }
    }
}

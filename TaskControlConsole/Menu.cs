using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskControl.Services;

namespace TaskControlConsole
{
    internal class Menu
    {
        TaskServices taskServices;
        PersonServices personServices;

        public Menu()
        {
            taskServices = new TaskServices();
            personServices = new PersonServices();
        }

        public void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========= Task Control =========");
                Console.WriteLine("| [1] Create Task              |");
                Console.WriteLine("| [2] Add Person               |");
                Console.WriteLine("| [3] Search Task              |");
                Console.WriteLine("| [4] Check Assigned Person    |");
                Console.WriteLine("| [5] Assign Person to Task    |");
                Console.WriteLine("| [6] Complete Task            |");
                Console.WriteLine("| [7] Remove Task              |");
                Console.WriteLine("| [8] Remove Person            |");
                Console.WriteLine("| [0] Exit App                 |");
                Console.WriteLine("================================");
                Console.Write("\nSelect Option: ");
                int option;
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.Write("- Invalid Option! Press Enter to Continue -");
                    Console.ReadLine();
                    continue;
                }
                switch (option)
                {
                    default:
                        Console.Write("- Invalid Option! Press Enter to Continue -");
                        Console.ReadLine();
                        continue;
                    case 1:
                        CreateTask();
                        continue;
                }
            }
        }

        public void CreateTask()
        {
            Console.Clear();
            Console.WriteLine("========= Creating Task =========");

            bool valid = false;
            string task = "";
            string priority = "";
            string category = "";
            DateOnly dueDate = new DateOnly(1111,1,1);

            while (valid == false)
            {
                Console.Write("Enter Task: ");
                task = Console.ReadLine();
                if (task == "")
                {
                    Console.WriteLine("- The Task cannot be empty! -");
                    continue;
                }
                valid = true;
            }
            valid = false;

            while (valid == false)
            {
                Console.Write("Enter Priority (Low, Medium, High) : ");
                priority = Console.ReadLine().ToLower();
                if (priority != "low" && priority != "medium" && priority != "high")
                {
                    Console.WriteLine("You have not selected one of the options!");
                    continue;
                }
                valid = true;
            }
            valid = false;

            while (valid == false)
            {
                Console.Write("Enter Category (Work, Personal, Home) : ");
                category = Console.ReadLine().ToLower();
                if (category != "work" && category != "personal" && category != "home")
                {
                    Console.WriteLine("- You have not selected one of the options! -");
                    continue;
                }
                valid = true;
            }
            valid = false;

            while (valid == false)
            {
                Console.Write("Enter Due Date (FORMAT: YYYY-MM-DD) : ");
                try
                {
                    dueDate = DateOnly.Parse(Console.ReadLine());
                    if (dueDate < DateOnly.FromDateTime(DateTime.Now))
                    {
                        Console.WriteLine("- The Due Date cannot be before today! -");
                        continue;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("- You have not entered a valid date! -");
                    continue; ;
                }
                valid = true;
            }

            taskServices.AddTask(task, priority, category, dueDate);

            Console.WriteLine("- You have successfully created the Task! -");
            Console.Write("- Press Enter to go back! -");
            Console.ReadLine();
            MainMenu();
           
        }
    }
}
